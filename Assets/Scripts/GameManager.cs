using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public SpikeInstantiator spikeSpawner;
    bool gameOver = false;
    int score = 0;
    public Text scoreText;
    public Text scoreTextPanel;
    public GameObject panel;


    void Awake(){
        if(instance == null){
            instance = this;
        }
    }

    public void GameOver(){
        gameOver = true;
        spikeSpawner.StopSpawning();
        panel.SetActive(true);
        scoreTextPanel.text = this.score.ToString();
    }

    public void IncrementScore(){
        if(!gameOver){
            this.score++;
            scoreText.text = this.score.ToString();
        }else{
            scoreText.text = "";
        }
        print(score);
    }

    public void Restart(){
        SceneManager.LoadScene("Game");
    }
    public void Menu(){
        SceneManager.LoadScene("Menu");
    }
}
