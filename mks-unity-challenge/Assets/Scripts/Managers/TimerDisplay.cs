using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerDisplay : MonoBehaviour
{
    [SerializeField] TMP_Text mText;
    float time;
    void Start()
    {
        time = GameManagment.gameManager.GetTimer() + 1f;
    }

    void Update()
    {
        mText.text = $"{(int)time/60}:{((int)(time%60)).ToString("00")}";
        time -= Time.deltaTime;
        
        if(time <= 0)
            GameManagment.gameManager.EndGame(true);
    }
}
