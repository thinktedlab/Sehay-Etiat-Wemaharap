using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SearchWordSelectLevel : MonoBehaviour
{
    void LoadScene(string nameScene)
    {
        SceneManager.LoadScene(nameScene);
    }
}
