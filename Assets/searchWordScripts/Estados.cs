using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Estados : MonoBehaviour
{
    public float time;
    public Text timeText;

    // Update is called once per frame
    void Update()
    {
        if (time > 0)
        { //se o tempo menor que 0
            time -= Time.deltaTime; //subtrai do Time.deltaTime.
            int tempoTexto = (int)time; //converte o valor float para int
            timeText.text = "Tempo: " + tempoTexto.ToString(); // configura o text
            //para o texto Tempo: 10
}
        if (time <= 0)
        {
            //Debug.Log("Game over");
            SceneManager.LoadScene("TelaFeedback"); 
        }
    }
}
