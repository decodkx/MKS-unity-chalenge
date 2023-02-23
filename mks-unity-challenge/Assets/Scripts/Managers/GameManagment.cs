using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagment : MonoBehaviour
{
    public static GameManagment gameManager;
    private bool won = true;
    private int score;
    private int matchTime = 120;
    private int spawnInterval = 30;
    void Awake() 
    {
        if(gameManager == null) {
            DontDestroyOnLoad (this);
            gameManager = this; 
        }
    }

    //duração de uma partida
    public void SetTimer(int value){
        matchTime = value;
    }

    public int GetTimer(){
        return matchTime;
    }

    //intervalo entre cada surgimento dos inimigos
     public void SetInterval(int value){
        spawnInterval = value;
    }

    public int GetInterval(){
        return spawnInterval;
    }

    public void AddScore(int points){
        score += points;
    }

    public int GetScore(){
        return score;
    }

    public void EndGame(bool victory){
        won = victory;
        SceneManager.LoadScene("Jogar Novamente");
    }

    public bool GetVictory(){
        return won;
    }
}
