using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class restart : MonoBehaviour
{
    static public void ButtonFunction()
    {
        SceneManager.LoadScene("Loading Scene");

    }

    IEnumerator DelaySceneLoad()
    {
        yield return new WaitForSeconds(7f);
        SceneManager.LoadScene("Gamescene");
    }


}
