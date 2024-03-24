using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Vida : MonoBehaviour
{
    private Slider slider;
    private void Awake()
    {
        slider = GetComponent<Slider>();
    }
    public void quitarvida(float quita)
    {
        slider.value = quita;
    }
    public void Full(float quita)
    {
        quitarvida(quita);
    }
}
