using System.Collections.Generic;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Sprite[] cardFace;
    public Sprite[] cardNome;
    public Sprite cardBack;
    public GameObject[] cards;
    public Text matchText;

    private bool _init = false;
    public int _matches;
    public int maxMatches;
    public int matches_ = 0;
    public string level;

    private int [] posi = new int [200];
    
    private void Update()
    {
        if (!_init) initializeCards();
        if (Input.GetMouseButtonUp(0)) checkCards();
    }

    void initializeCards()
    {
        for (int id = 0; id < 2; id++)
        {
            for (int i = 1; i <= _matches; i++)
            { 
                bool test = false;
                int choice = 0;

                while (!test)
                {
                    choice = Random.Range(0, cards.Length);
                    test = !(cards[choice].GetComponent<Card>().initialized);
                }
                cards[choice].GetComponent<Card>().cardValue = i;
                cards[choice].GetComponent<Card>().initialized = true;
                posi[choice] = 0;
            }
        }      

        foreach (GameObject c in cards) c.GetComponent<Card>().setupGraphics();

        if (!_init) _init = true;
    }

    public Sprite getCardBack()
    {
        return cardBack;
    }

    public Sprite getCardFace(int i)
    {
        if (posi[i - 1] == 0) {
            posi[i - 1] = 1;
            return cardFace[i - 1];
        }
        else {
            return cardNome[i - 1];
        }
    }

    void checkCards()
    {
        List<int> c = new List<int>();

        for (int i = 0; i < cards.Length; i++)
        {
            if (cards[i].GetComponent<Card>().state == 1) c.Add(i);
        }

        if (c.Count == 2) cardComparison(c);
    }
    

    void cardComparison(List<int> c)
    {
        Card.DO_NOT = true;
        int x = 0;

        if (cards[c[0]].GetComponent<Card>().cardValue == cards[c[1]].GetComponent<Card>().cardValue)
        {
            matches_++;

            string key = "memory_" + level;
            float perCurr = ((1.0f * matches_) / maxMatches) * 100.0f;
            PlayerPrefs.SetFloat(key, perCurr);
            PlayerPrefs.SetString("prevLevel", key);

            Debug.Log("Per: " + PlayerPrefs.GetFloat(key));
            Debug.Log("prevLevel: " + PlayerPrefs.GetString("prevLevel"));
            
            if (maxMatches == matches_)
            {
                StartCoroutine("MudarLevel");
            }


            x = 2;
            _matches--;
            matchText.text = "Number of matches: " + _matches;
            if (_matches == 0){
                StartCoroutine("MudarLevel");
            }

        }

        for (int i = 0; i < c.Count; i++)
        {
            cards[c[i]].GetComponent<Card>().state = x;
            cards[c[i]].GetComponent<Card>().falseCheck();
        }
    }
    IEnumerator MudarLevel()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("TelaFeedback");

    }
}
