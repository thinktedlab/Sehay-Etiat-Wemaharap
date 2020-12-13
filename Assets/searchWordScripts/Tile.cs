using UnityEngine;
using System;
using System.Collections;


public class Tile : MonoBehaviour {
	
	public GameObject[] charsGO;
	
	public GameObject tileBg;
	
	[HideInInspector]
	public int row;

	[HideInInspector]
	public int column;

	[HideInInspector]
	public int type;
	
	[HideInInspector]
	public bool selected;
	
	[HideInInspector]
	public bool touched;
	
	private Vector3 tilePosition;
	
	private static char[] chars = new char[] {'a','b','c','d','e','f','g','h','i','j','k','l',
		'm','n','o','p','q','r','s','t','u','v','w','x','y','z'};
	
	private static char[] vowels = new char[] {'a','e','i','o','u'};
	
	private static char[] consonants = new char[] {'b','c','d','f','g','h','j','k','l','m','n',
		'p','q','r','s','t','v','w','x','y','z'};
	
	private bool updatePosition;
	
	public char TypeChar {
		get { return chars [type]; }
		private set{}
	}

	public static float size;

	private Grid grid;

	public void SetTileData (char c) 
	{
		charsGO [type].SetActive (false);

		var index = Array.IndexOf (chars, c);

		charsGO [index].SetActive (true);

		type = index;

		//tileBg.GetComponent<Renderer> ().material.color =  Color.black;

		//charsGO [index].GetComponent<Renderer> ().material.color = Color.white;
	}
	
	public void SetTilePosition (Grid grid, int column, int row)
	{
		this.grid = grid;
		size = tileBg.GetComponent<SpriteRenderer> ().bounds.size.x;
		this.column = column;
		this.row = row;
		tilePosition = new Vector3 ( (column * size) - grid.GRID_OFFSET_X, grid.GRID_OFFSET_Y + (-row * size)  , 0);
		transform.position = tilePosition;
		
		foreach (var go in charsGO) {
			go.SetActive(false);
		}
		
		Select (false);
	}
	
	public void Select (bool value)
	{
		selected = value;
		
		if (selected) {
			//tileBg.GetComponent<Renderer> ().material.color = Color.white;
			//charsGO [type].GetComponent<Renderer> ().material.color = Color.black;
            charsGO[type].GetComponent<Renderer>().material.color = Color.green;
        } else {
			//tileBg.GetComponent<Renderer> ().material.color = Color.black;
			charsGO [type].GetComponent<Renderer> ().material.color = Color.white;
		}
	}
	
	public void UpdateData ()
	{
		if (!gameObject.activeSelf) 
		{
			char c;
			if (Array.IndexOf (consonants, chars [type]) == -1) {
				c = vowels [UnityEngine.Random.Range (0, vowels.Length)];
			} else {
				c = consonants [UnityEngine.Random.Range (0, consonants.Length)];
			}
			charsGO [type].SetActive (false);
			type = Array.IndexOf (chars, c);
			charsGO [type].SetActive (true);
		}
		
		if (transform.position.y != grid.GRID_OFFSET_Y + (-row * size)) 
		{
			updatePosition = true;
		}
		
		gameObject.SetActive(true);
		
	}
	
	void Update ()
	{
		if (updatePosition) {
			var targetY = grid.GRID_OFFSET_Y + (-row * size);
			var nowPosition = transform.position;
			nowPosition.y -= 0.4f;
			
			if (nowPosition.y < targetY)
			{
				nowPosition.y = targetY;
				updatePosition = false;
			}
			
			transform.position = nowPosition;
		}
	}
	
}
