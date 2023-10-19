using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Slider slider;
    public Gradient Gradient;
    public Image Fill;
    private Animator anim;

    //Gets the slider and animator of the object script is attached too and sets them to variables.
    private void Awake()
    {
        slider = GetComponent<Slider>();
        anim = GetComponent<Animator>();
    }

    //Sets the health bar slider to be equal to be equal to max health and updates the bar accordingly.
    public void SetMaxHealth(float maxHealth)
    {
        //Sets the value of the slider to be equal to the passed variable maxhealth
        slider.maxValue = maxHealth;
        //Sets the value of the slider equal to the value input of max health
        slider.value = maxHealth;
        //Changes the gradient color based on the position of the health bar slider
        Fill.color = Gradient.Evaluate(1f);
    }

    //Updates the player health bar to be equal to the players current health
    public void SetHealth(float health)
    {
        //Sets the value of the slider equal to the value input of health
        slider.value = health;

        //Changes the gradient color based on the position of the health bar slider
        Fill.color = Gradient.Evaluate(slider.normalizedValue);
    }

    //Function sets bool to true, this variable in the animator so that the healthbar can fade in
    public void FadeIn()
    {
        anim.SetBool("HealthFade", true);
    }

    //Function sets bool to true, this variable in the animator so that the healthbar can't fade in anymore
    public void FadeOut()
    {
        anim.SetBool("HealthFade", false);
    }
}
