using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;
    private Animator anim;

    private void Start()
    {
        slider = GetComponent<Slider>();
        anim = GetComponent<Animator>();
    }

    public void SetMaxHealth(float maxHealth)
    {
        slider.maxValue = maxHealth;
        slider.value = maxHealth;
        fill.color = gradient.Evaluate(1f);
    }

    public void SetHealth(float health)
    {
        slider.value = health;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

    public void FadeIn()
    {
        anim.SetBool("HealthFade", true);
    }

    public void FadeOut()
    {
        anim.SetBool("HealthFade", false);
    }
}
