using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetGamesearchScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetString("game", "LevelList_CacaPalavras");
    }
}
