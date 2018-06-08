using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_AI : MonoBehaviour {

    //enemy speed
    [SerializeField]
    private float _enemySpeed = 3.0f;

    //enemy explosion
    [SerializeField]
    private GameObject _enemyExplosion;

    //variable for UI manager
    private UI_Manager _UImanager;

    //variable for explosion audio clip
    [SerializeField]
    private AudioClip _explosionSound;


	// Use this for initialization
	void Start () {

        //get the ui manager component of the only gameobject named canvas
        _UImanager = GameObject.Find("Canvas").GetComponent<UI_Manager>();


		
	}
	
	// Update is called once per frame
	void Update () {

        //movement downwards
        transform.Translate(Vector3.down * _enemySpeed * Time.deltaTime);

        //wrapping feature
        if (transform.position.y < -6.0f)
        {
            //randomized float
            float randomX = Random.Range(-8.0f, 8.0f);

            //randomly wrap feature
            transform.position = new Vector3(randomX, 5.0f, 0);
        }
		
	}

    //collision with the laser
    public void OnTriggerEnter2D(Collider2D other)
    {
        //tag check for Laser
        if (other.tag == "Laser")
        {
            //access the laser
            Laser laser = other.GetComponent<Laser>();

            //nullcheck
            if (laser != null) 
            {
                //destroy the laser
                Destroy(laser.gameObject);
            }

            //enemy explosion animation
            Instantiate(_enemyExplosion, transform.position, Quaternion.identity);

            //update the score and destroy enemy with an explosion
            //AudioSource.PlayClipAtPoint(_explosionSound, transform.position);
            _UImanager.UpdateScore();
            Destroy(this.gameObject);
        }

        //tag check for Player
        if (other.tag == "Player")
        {

            //access the player
            Player_Controller player = other.GetComponent<Player_Controller>();

            //nullcheck
            if (player != null)
            {
                player.Damage();
            }

            //enemy explosion animation
            Instantiate(_enemyExplosion, transform.position, Quaternion.identity);


            //update the score and destroy the enemy with an explosion
            _UImanager.UpdateScore();
            Destroy(this.gameObject);


        }
    }


}
