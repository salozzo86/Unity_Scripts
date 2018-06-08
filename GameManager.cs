using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    //bool for gameover
    public bool gameOver = true;

    //prefab for player
    [SerializeField]
    private GameObject _player;

    //variable for ui manager
    private UI_Manager _UIManager;

    //variable for main menu
    public GameObject mainMenu;


	// Use this for initialization
	void Start () {

        //get ui manager component
        _UIManager = GameObject.Find("Canvas").GetComponent<UI_Manager>();

		
	}
	
	// Update is called once per frame
	void Update () {

        if(gameOver)
        {
            if(Input.GetKeyDown(KeyCode.P))
            {
                //spawn the player
                Instantiate(_player, new Vector3(0, -3, 0), Quaternion.identity);

                //set gameover to false
                gameOver = false;

                //hide the main menu
                _UIManager.HideMainMenu();


            }
        }
		
	}

}
