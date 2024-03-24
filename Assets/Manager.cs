using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    public TextMeshProUGUI contador;
    private float timeElapsed = 0f;

    void Update()
    {
        timeElapsed += Time.deltaTime;
        contador.text = "Tiempo transcurrido: " + timeElapsed.ToString("F2") + " segundos";
    }

    void OnDisable()
    {
        GuardarTiempo();
    }

    void GuardarTiempo()
    {
        PlayerPrefs.SetFloat("TiempoTranscurrido", timeElapsed);
    }
}
