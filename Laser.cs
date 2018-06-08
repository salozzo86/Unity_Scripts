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

        //destroy lasers or triple shot when out of the boundaries
        if (transform.position.y > 5.70f) {

            if (this.transform.parent)
            {
                Destroy(this.transform.parent.gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
		
	}
}
