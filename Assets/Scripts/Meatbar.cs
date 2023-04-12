using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Meatbar : MonoBehaviour
{
    public Slider slider;

  

    public void SetMaxSta(int sta)
    {
        slider.maxValue = sta;
        slider.value = sta;
    }

    public void SetSta(int sta)
    {

        slider.value = sta;

    }

    public void DecreaseSta()
    {
        StartCoroutine(DecreaseSlider(slider));
    }

    IEnumerator DecreaseSlider(Slider slider)
    {
        while (slider.value >= 0)
        {
            slider.value -= 1;
            yield return new WaitForSeconds(1);
            if(slider.value <= 0)
            {
                break;
            }
        }
        yield return null;
    }
}
