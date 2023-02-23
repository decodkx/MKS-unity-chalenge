using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MatchTimeDisplay : MonoBehaviour
{
    [SerializeField] Slider duration_slider;
    [SerializeField] TMP_Text duration_text;

    [SerializeField] Slider spawn_slider;
    [SerializeField] TMP_Text spawn_text;
    void Start()
    {
        duration_slider.value = GameManagment.gameManager.GetTimer();
        spawn_slider.value = GameManagment.gameManager.GetInterval();
    }

    // Update is called once per frame
    void Update()
    {
        duration_text.text = $"Tempo de partida: {(int)duration_slider.value/60}:{(duration_slider.value%60).ToString("00")} min";
        spawn_text.text = $"Intervalo do spawn: {(spawn_slider.value).ToString()} s";
        GameManagment.gameManager.SetTimer((int)duration_slider.value);
        GameManagment.gameManager.SetInterval((int)spawn_slider.value);
    }
}
