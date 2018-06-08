using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion_destruction : MonoBehaviour {

    [SerializeField]
    private float _time = 2.0f;

    //variable for explosion audio clip
    [SerializeField]
    private AudioClip _explosionSound;

	// Use this for initialization
	void Start () {

        AudioSource.PlayClipAtPoint(_explosionSound, Camera.main.transform.position, 1f);
        Destroy(this.gameObject, _time);
		
	}
	

}
