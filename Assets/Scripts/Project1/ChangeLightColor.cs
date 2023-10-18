using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLightColor : MonoBehaviour
{
    public Color newColor;

    //Changes the light to a selected color when the function is called
    public void ChangeColor()
    {
        GetComponent<Light>().color = newColor;
    }
}
