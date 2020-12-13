using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComandosBasicos : MonoBehaviour
{
    
    public void carregaCena(string nomeCena)
    {
        Application.LoadLevel(nomeCena);
    }

}

