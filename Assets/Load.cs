using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Load : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(DelaySceneLoad());
    }
    IEnumerator DelaySceneLoad()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("Gamescene");
    }
}
