using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour {

    //speed variable
    [SerializeField]
    private float _speed = 3.0f;

    //create power up id variable
    [SerializeField]
    private int _powerUpID; //0 = triple shot, 1 = speed, 2 = shield

    //power up sound
    [SerializeField]
    private AudioClip _powerUpSound;

	// Use this for initialization
	void Start () {

		
	}
	
	// Update is called once per frame
	void Update () {

        //movement
        transform.Translate(Vector3.down * _speed * Time.deltaTime);

        //destroy when off screen
        if (transform.position.y < -7)
        {

            Destroy(this.gameObject);

        }

	}

    //collision method
    private void OnTriggerEnter2D(Collider2D other)
    {
        //check if the collided gameobject is the player
        if (other.tag == "Player")
        {

            //play power up sound
            AudioSource.PlayClipAtPoint(_powerUpSound, Camera.main.transform.position, 1f);
            //access to the player
            Player_Controller player = other.GetComponent<Player_Controller>();

            if (player != null)
            {
                //ifs to check which powerup we have on
                if (_powerUpID == 0)
                {
                    //call the triple shot power up enabler method
                    player.TripleShotPowerUpOn();
                }
                else if (_powerUpID == 1)
                {
                    //call the speed power up enabler method
                    player.SpeedBoostPowerUpOn();

                }
                else
                {
                    //call the shield power up enabler method
                    player.ShieldBoostPowerUpOn();
                }

                Destroy(this.gameObject);
            }
        }

    }
}
