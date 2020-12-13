using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarControl : MonoBehaviour
{
    public GameObject [] stars;
    public string [] variaveis;

    private const int LEVEL_1 = 3;
    private const int LEVEL_2 = 6;
    private const int LEVEL_3 = 9;

    private void Update()
    {
        float amountStar1 = PlayerPrefs.GetFloat(variaveis[0]);
        float amountStar2 = PlayerPrefs.GetFloat(variaveis[1]);
        float amountStar3 = PlayerPrefs.GetFloat(variaveis[2]);

        lightUpStar(amountStar1, LEVEL_1);
        lightUpStar(amountStar2, LEVEL_2);
        lightUpStar(amountStar3, LEVEL_3);
    }

    void lightUpStar(float amauntStarLevel, int i)
    {
        if (amauntStarLevel >= 0.1f && amauntStarLevel < 33.0f)
        {
            stars[i - 3].SetActive(true);
        } else if (amauntStarLevel >= 33.0f && amauntStarLevel < 66.0f)
        {
            stars[i - 3].SetActive(true);
            stars[i - 2].SetActive(true);
        }
        else if (amauntStarLevel >= 66.0f && amauntStarLevel <= 100.0f)
        {
            stars[i - 3].SetActive(true);
            stars[i - 2].SetActive(true);
            stars[i - 1].SetActive(true);
        }
    }
}
