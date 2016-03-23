﻿using UnityEngine;
using System.Collections;

public class CheckpointScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D collider){		
		if (collider.tag == "Player"){
			collider.SendMessage ("SetCheckpointPosition", gameObject.transform.position);
			Destroy (gameObject);
		}			
	}
}
