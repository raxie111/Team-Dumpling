using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePause : MonoBehaviour

{
   [SerializeField] public GameObject PauseGame;


    public void PlayScene()
    {
        PauseGame.SetActive(false);
        Time.timeScale = 1;

    }

    public void PauseScene()
    {
        PauseGame.SetActive(true);
        Time.timeScale = 0;
    }
}
