using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour {

    //laser speed
    [SerializeField]
    private float _speed = 10.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        //laser movement forward 
        transform.Translate(Vector3.up * _speed * Time.deltaTime);

        //laser disappears when off-screen
        if (transform.position.y > 5.70f) {
            Destroy(gameObject);
        }
		
	}
}
