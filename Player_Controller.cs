using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour {

    //speed variable
    [SerializeField]
    private float _speed = 5.0f;

    //variable for laser prefab
    [SerializeField]
    private GameObject _laserPrefab;

    //variables for cool down system
    [SerializeField]
    private float _fireRate = 0.25f;
    private float _canFire = 0.0f;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

        //initialize the movement method
        Movement();

        //initialize the shooting method
        Shoot();
	}

    //method that handles movement
    private void Movement () {
        
        //float for the player's horizontal and vertical input
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        //moveright and left 
        transform.Translate(Vector3.right* horizontalInput * _speed * Time.deltaTime);

        //move up and down
        transform.Translate((Vector3.up* verticalInput * _speed * Time.deltaTime));

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
    private void Shoot () {
        //if statement for the firing system and the cool down
        if (Input.GetKeyDown((KeyCode.Space)))
        {

            //check to see if the player can fire
            if (Time.time > _canFire)
            {

                //instantiate the laser
                Instantiate(_laserPrefab, transform.position + new Vector3(0, 0.88f, 0), Quaternion.identity);

                //reassign canFire to game time and fire rate, for control
                _canFire = Time.time + _fireRate;
            }
        }
    }
}
