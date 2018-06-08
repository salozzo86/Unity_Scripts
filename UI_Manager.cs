using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour {

    //array for lives sprites
    public Sprite[] lives;
    //variable for image in the canvas for display
    public Image livesDisplay;
    //variable for main menu
    public GameObject mainMenu;

    //reference gamemanager
    private GameManager _gameManager;

    //player
    [SerializeField]
    private GameObject _player;


    //int to score the score;
    public int score;
    //variable for the text image
    public Text scoreDisplay;

    public void Start()
    {
        //find game manager
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }


    //method for the lives update with custom parameter
    public void UpdateLives(int currentLives)
    {
        livesDisplay.sprite = lives[currentLives];
    }

    //method for score update
    public void UpdateScore()
    {
        //add score
        score += 10;

        //display the current score
        scoreDisplay.text = "Score: " + score;
        Debug.Log(score);
        
    }

    //method to hide main menu
    public void HideMainMenu() 
    {
        //main menu disappears
        mainMenu.SetActive(false);

        //reset score
        score = 0;
        scoreDisplay.text= "Score: ";
    }

    //method to show main menu
    public void ShowMainMenu()
    {
        //main menu reappears
        mainMenu.SetActive(true);

        //gameover to true
        _gameManager.gameOver = true;
    }
   
}
