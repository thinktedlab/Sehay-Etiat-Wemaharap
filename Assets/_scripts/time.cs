using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class time : MonoBehaviour {

    public float tempo;
    public Slider barTempo;


    // Start is called before the first frame update
    void Start()
    {
        //tempo = 100;
    }

    // Update is called once per frame
    void Update()
    {
        if (tempo > 0) {
            tempo -= Time.deltaTime;
            barTempo.value = tempo;
        }
        if (tempo <= 0)
        {
            
        }
    }
}
