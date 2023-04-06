using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class gamemanager : MonoBehaviour
{
    public TextMeshProUGUI GameoverText;
    public button RestartButton;
    private PauseMenu pausemenu;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GameOver()
    {
        GameoverText.gameObject.SetActive(true);
        RestartButton.gameObject.SetActive(true);
        pausemenu.Pause();
    }

}
