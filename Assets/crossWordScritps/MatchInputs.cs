using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MatchInputs : MonoBehaviour
{
    public List<InputField> characteres;
    public string nameFig;

    public Control gameController;

    private bool correct = false;

    private void Update()
    {
        if (isFill() && !correct)
        {
            Invoke("verifyInput", 1);
        }
    }

    private bool isFill()
    {
        foreach (var charac in characteres)
            if (String.IsNullOrEmpty(charac.text))
                return false;
        return true;
    }

    private void verifyInput()
    {
        int countCorrect = 0;
        string s2 = nameFig.ToUpper();

        for (int i = 0; i < characteres.Count; i++)
        {
            string s1 = characteres[i].text.ToUpper();
            if (s1.Length > 0)
                if (s1[0].Equals(s2[i]))
                    countCorrect++;
                else
                    characteres[i].text = null;
        }

        if (countCorrect == characteres.Count  && !correct) {
			correct = true;
			++gameController.score;
            Debug.Log(gameController.score);
        }
    }
}
