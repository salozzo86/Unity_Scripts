using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Manager : MonoBehaviour {

    //enemy gameobject
    [SerializeField]
    private GameObject _enemy;


    //array of powerup gameobjects
    [SerializeField]
    private GameObject[] _powerUps;

    //variable for game manager
    private GameManager _gameManager;
 

    // Use this for initialization
    public void Start () {

        //get the game manager component
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        StartCoroutine(EnemySpawnRoutine());
        StartCoroutine(PowerUpSpawnRoutine());
         		
	}

    public void StartSpawnRoutines()
    {
        StartCoroutine(EnemySpawnRoutine());
        StartCoroutine(PowerUpSpawnRoutine());
    }

    //spawn enemies
    public IEnumerator EnemySpawnRoutine()
    {
        while (_gameManager.gameOver == false)
        {

            //random float for x position
            float randomX = Random.Range(9.4f, -9.4f);

            //enemy spawn
            Instantiate(_enemy, new Vector3(randomX, 5.0f, 0f), Quaternion.identity);

            //5 second pause
            yield return new WaitForSeconds(5);
        }
    }

    //spawn powerups
    public IEnumerator PowerUpSpawnRoutine()
    {
        while(_gameManager.gameOver == false)
        {
            //random float for x position
            float randomX = Random.Range(9.4f, -9.4f);

            //randomize the array index 
            int randomIndex = Random.Range(0, _powerUps.Length); 

            //powerup spawn
            Instantiate(_powerUps[randomIndex], new Vector3(randomX, 7.0f, 0), Quaternion.identity);

            //escape the while loop
            yield return new WaitForSeconds(5);
        }
    }

}
