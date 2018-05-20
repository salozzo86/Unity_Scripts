using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour {

    //speed variable
    [SerializeField]
    private float _speed = 3.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        //movement
        transform.Translate(Vector3.down * _speed * Time.deltaTime);
		
	}

    //collision method
    private void OnTriggerEnter2D(Collider2D other)
    {
        //check if the collided gameobject is the player
        if (other.tag == "Player")
        {
            //access to the player
            Player_Controller player = other.GetComponent<Player_Controller>();

            if (player != null)
            {
                //call the power up on enabler method
                player.TripleShotPowerUpOn();

                Destroy(this.gameObject);
            }
        }

    }
}
