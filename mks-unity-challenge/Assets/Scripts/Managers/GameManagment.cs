using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagment : MonoBehaviour
{
    public static GameManagment gameManager;
    private int matchTime = 120;
    void Awake() 
    {
        if(gameManager == null) {
            DontDestroyOnLoad (this);
            gameManager = this; 
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetTimer(int value){
        matchTime = value;
    }

    public int GetTimer(){
        return matchTime;
    }
}
