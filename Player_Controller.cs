using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour {

    //speed variable
    [SerializeField]
    private float _speed = 5.0f;

    //variables for laser prefabs
    [SerializeField]
    private GameObject _laserPrefab;
    [SerializeField]
    private GameObject _tripleLaser;

    //variables for cool down system
    [SerializeField]
    private float _fireRate = 0.25f;
    private float _canFire = 0.0f;

    //array for engines
    [SerializeField]
    private GameObject[] _engines;


    //boolean for triple shot
    public bool tripleShot = false;
    //boolean for speed boost
    public bool speedBoost = false;
        //speed when speedBoost active
        [SerializeField]
        private float _boostedSpeed = 10.0f;
    //boolean for shield boost
    public bool shieldBoost = false;

    //shield representation
    [SerializeField]
    private GameObject _shield;

    //player life counter
    public int playerLives = 3;

    //explosion animation
    [SerializeField]
    private GameObject _playerExplosion;

    //variable for the UIManager
    private UI_Manager _UIManager;

    //variable for the spawn manager
    private Spawn_Manager _spawnManager;

    //variable for audio source
    private AudioSource _laserSound;

	// Use this for initialization
	void Start () 
    {
        //get the ui manager component
        _UIManager = GameObject.Find("Canvas").GetComponent<UI_Manager>();

        //update the lives counter according to the player lives
        _UIManager.UpdateLives(playerLives);

        //get the spawn manager component
        _spawnManager = GameObject.Find("Spawn Manager").GetComponent<Spawn_Manager>();

        //get the audio source
        _laserSound = GetComponent<AudioSource>();

        //run the spawning coroutines after a nullcheck
        if(_spawnManager != null)
        {
            _spawnManager.StartSpawnRoutines();
        }

	}
	
	// Update is called once per frame
	void Update () {

        //initialize the movement method
        Movement();

        //initialize the shooting method if the player press the shoot button
        if (Input.GetKeyDown((KeyCode.Space))) {
            Shoot();
        }

	}

    //method that handles movement
    private void Movement () {
        
        //float for the player's horizontal and vertical input
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        //check if the speedboost is active
        if (speedBoost == true)
        {
            //move right and left 
            transform.Translate(Vector3.right * horizontalInput * _boostedSpeed * Time.deltaTime);

            //move up and down
            transform.Translate((Vector3.up * verticalInput * _boostedSpeed * Time.deltaTime));
        }
        else
        {
            //move right and left 
            transform.Translate(Vector3.right * horizontalInput * _speed * Time.deltaTime);

            //move up and down
            transform.Translate((Vector3.up * verticalInput * _speed * Time.deltaTime));
        }

        //player bounds on the y axis
        if (transform.position.y > 0) {
            transform.position = new Vector3(transform.position.x, 0, 0);
        } else if (transform.position.y< -4.2) {
            transform.position = new Vector3(transform.position.x, -4.2f, 0);
        }

        //player bounds on the x axis and wrapping feature
        if (transform.position.x > 9.5) {
            transform.position = new Vector3(-8.32f, transform.position.y, 0);
        } else if (transform.position.x< -9.4) {
            transform.position = new Vector3(8.36f, transform.position.y, 0);
        }
    }

    //method that handles shooting
    private void Shoot () 
    {

        //check to see if the player can fire
        if (Time.time > _canFire)
        {

            _laserSound.Play();
            if (tripleShot)
            {
                //instantiate triple shot
                Instantiate(_tripleLaser, transform.position, Quaternion.identity);

        } else
            //instantiate the laser
            Instantiate(_laserPrefab, transform.position + new Vector3(0, 0.88f, 0), Quaternion.identity);

            //reassign canFire to game time and fire rate, for control
            _canFire = Time.time + _fireRate;
        }
        
    }

    public void Damage ()
    {
        //shield up check 
        if (shieldBoost == true)
        {
            //deactivate the shield boost and return to the beginning of the method
            shieldBoost = false;

            //deactivate shield animation
            _shield.SetActive(false);

            //return to beginning of the method
            return;
        }
        //remove one life
        playerLives--;

        //update the lives counter
        _UIManager.UpdateLives(playerLives);

        //check if less than 1 life
        if (playerLives < 1)
        {
            //player explosion animation
            Instantiate(_playerExplosion, transform.position, Quaternion.identity);

            //main menu
            _UIManager.ShowMainMenu();

            //destroy the player
            Destroy(this.gameObject);
        }
        


    }

    //method for the triple shot power up
    public void TripleShotPowerUpOn()
    {
        //activate power up and the coroutine
        if(tripleShot == false)
        {
            tripleShot = true;
            StartCoroutine(TripleShotPowerDownRoutine());
        }

    }

    //method for the speed boost power up
    public void SpeedBoostPowerUpOn()
    {
        //activate power up and coroutine
        speedBoost = true;
        StartCoroutine(SpeedBoostPowerDownRoutine());

    }

    //method for the shield boost power up
    public void ShieldBoostPowerUpOn()
    {
        //activate shield up
        shieldBoost = true;

        //activate shield animation
        _shield.SetActive(true);
    }

    //power down coroutine for triple shot
    public IEnumerator TripleShotPowerDownRoutine()
    {
        //yield instruction
        yield return new WaitForSeconds(5.0f);

        //consequence
        tripleShot = false;
    }

    //power down coroutine for speed boost
    public IEnumerator SpeedBoostPowerDownRoutine()
    {
        //yield instruction
        yield return new WaitForSeconds(5.0f);

        //consequence
        speedBoost = false;
    }

}
