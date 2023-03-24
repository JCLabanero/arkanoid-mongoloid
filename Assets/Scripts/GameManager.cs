using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int lives;
    // public Text livesText;
    public TextMeshProUGUI livesText;
    public bool isGameOver;
    public GameObject gameOverPanel;
    // Start is called before the first frame update
    void Start()
    {
        livesText.text = "Lives: " + lives;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void decreaseLifeByOne(){
        lives-=1;
        livesText.text = "Lives: " + lives;
        if(lives<=0){
            isGameOver = true;
            gameOverPanel.SetActive(true);
        }
    }
}
