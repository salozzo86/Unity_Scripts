using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour {

    //speed variable
    public float speed = 5.0f;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

        //initialize the movement function
        Movement();
	}

    //method that handles movement
    private void Movement () {
        
        //float for the player's horizontal and vertical input
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        //moveright and left 
        transform.Translate(Vector3.right* horizontalInput * speed * Time.deltaTime);

        //move up and down
        transform.Translate((Vector3.up* verticalInput * speed * Time.deltaTime));

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
}
