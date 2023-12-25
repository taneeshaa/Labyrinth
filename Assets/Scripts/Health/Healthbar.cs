using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    //public Slider slider;
    public Image image; 
    //public Gradient gradient;
    //public Image fill;
    public void SetMaxHealth(float health)
    {
        //slider.maxValue = health;
        //slider.value = health;
        image.fillAmount = health;
        //fill.color = gradient.Evaluate(1f);
        
    }
    public void SetHealth(float health)
    {
        //slider.value = health;
        Debug.Log(image.fillAmount);
        image.fillAmount = health;
        //fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
