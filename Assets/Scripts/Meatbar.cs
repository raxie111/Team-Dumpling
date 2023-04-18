using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Meatbar : MonoBehaviour
{
    [SerializeField]
    public Slider slider;
    public int sta;
    
    void Start()
    {
        DecreaseSta();
       
    }

    public void SetMaxSta(int sta)
    {
        slider.maxValue = sta;
        slider.value = sta;
    }

    public void SetSta(int sta)
    {

        slider.value += sta;

    }

    public void DecreaseSta()
    {
        StartCoroutine(DecreaseSlider(slider));
    }

    IEnumerator DecreaseSlider(Slider slider)
    {
        SetMaxSta(sta);
        while (slider.value >= 0)
        {
            slider.value -= 1;
            yield return new WaitForSeconds(1);
            
            if(slider.value <= 0)
            {
                Destroy(GameObject.FindWithTag("Player"));
                SceneManager.LoadScene("GameOver");
                break;
            }
        }
        yield return null;
    }
}
