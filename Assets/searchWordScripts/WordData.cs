using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;


public class WordData : MonoBehaviour {
	
	public WordGame game;
	
	[HideInInspector]
	public Dictionary<char, List<string>> wordsMap;
	
	private List<string> allWords;
	
	private List<string> allWordsUnique;


	public bool IsValidWord (string word)
	{
		if (!wordsMap.ContainsKey (word [0]))
			return false;
		var list = wordsMap [word [0]];
		if (list != null) 
		{
			return list.Contains(word);
			
		}
		return false;
	}

	public string GetRandomWord (int len = 0)
	{
		if (len != 0) {
			
			while (true)
			{
				var i = Random.Range (0, allWordsUnique.Count);
				var w = allWordsUnique [i].TrimEnd ();
				w = w.TrimStart ();
				allWordsUnique.RemoveAt (i);
				if (w.Length == len) {
					return w;
				}
			}
		}
		
		var index = Random.Range (0, allWordsUnique.Count);
		var word = allWordsUnique [index].TrimEnd ();
		word = word.TrimStart ();
		allWordsUnique.RemoveAt (index);
		return word;
	}

	void Start ()
	{
		wordsMap = new Dictionary<char, List<string>> ();
		StartCoroutine ("LoadWordData");
	}
	
	IEnumerator LoadWordData() {

        //string filePath = System.IO.Path.Combine(Application.streamingAssetsPath, "words.txt");
        ///Debug.Log(Application.dataPath+ "/searchWordStreamingAssets/new_words.txt");
        string folder = System.IO.Path.Combine("searchWordStreamingAssets", "new_words.txt");
        string filePath = System.IO.Path.Combine(Application.dataPath, folder);
        //.streamingAssetsPath, "new_words.txt");
        //Debug.Log(filePath);
        string result = null;

        if (filePath.Contains("://"))
        {
            WWW www = new WWW(filePath);
            yield return www;
            result = www.text;
        }
        else
        {
            result = System.IO.File.ReadAllText(filePath);
        }
		
		ProcessWordSource(result);

        //filePath = System.IO.Path.Combine(Application.streamingAssetsPath, "commonWords.txt");
        //filePath = System.IO.Path.Combine(Application.streamingAssetsPath, "new_words.txt");
        folder = System.IO.Path.Combine("searchWordStreamingAssets", "new_words.txt");
        filePath = System.IO.Path.Combine(Application.dataPath, folder);
        result = null;
		
		if (filePath.Contains("://")) {
			WWW www = new WWW(filePath);
			yield return www;
			result = www.text;
		} else
			result = System.IO.File.ReadAllText(filePath);

		ProcessWordData (result);
		
		game.InitGame ();
	}
	
	void ProcessWordSource (string data) {
		var words = data.Split('\n');
		foreach (var entry in words) 
		{
			var c = entry[0];
			if (!wordsMap.ContainsKey(c))
			{
				wordsMap.Add (c, new List<string>());
			}
			wordsMap[c].Add(entry.TrimEnd());
		}
	}
	
	void ProcessWordData (string data)
	{
		var words = data.Split('\n');
		allWords = new List<string> (words);
		
		ShuffleList (allWords);
		
		allWordsUnique = new List<string> ();
		allWordsUnique.AddRange (allWords);
	}

	
	private static System.Random random = new System.Random();
	
	public static void ShuffleList<T>(List<T> array)
	{
		int n = array.Count;
		for (int i = 0; i < n; i++)
		{
			int r = i + (int)(random.NextDouble() * (n - i));
			T t = array[r];
			array[r] = array[i];
			array[i] = t;
		}
	}
	
}
