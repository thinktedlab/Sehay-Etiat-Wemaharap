using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetGamememoryGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetString("game", "LevelList_MemoryGame");
    }
}
