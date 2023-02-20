using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MatchTimeDisplay : MonoBehaviour
{
    [SerializeField] Slider slider;
    [SerializeField] TMP_Text mText;
    void Start()
    {
        slider.value = GameManagment.gameManager.GetTimer();
    }

    // Update is called once per frame
    void Update()
    {
        mText.text = $"Tempo de partida: {(int)slider.value/60}:{(slider.value%60).ToString("00")} min";
        GameManagment.gameManager.SetTimer((int)slider.value);
    }
}
