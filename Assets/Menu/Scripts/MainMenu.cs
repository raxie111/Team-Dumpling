using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    static public void ButtonFunction()
    {
        SceneManager.LoadScene("Loading Scene");
        
    }

    IEnumerator DelaySceneLoad()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("Gamescene");
    }

}
