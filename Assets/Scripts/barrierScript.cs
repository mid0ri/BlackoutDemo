using UnityEngine;
using System.Collections;

public class barrierScript : MonoBehaviour {

	public Collider2D barrierCollider;
	public bool isNear;

	// Use this for initialization
	void Start () {
		isNear = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (isNear && Input.GetKey (KeyCode.X)) {
			barrierCollider.enabled = false;
			Debug.Log ("turn off");
		}
	}
	void OnTriggerStay2D(Collider2D other){
		if(Input.GetKey(KeyCode.X)){
			barrierCollider.enabled = false;
			Debug.Log ("turn off");
		}
	} 
	/*
	void OnTriggerEnter2D(Collider2D other){
		Debug.Log ("enter");
		if (other.gameObject.tag == "player")
			isNear = true;
	}

	void OnTriggerExit2D(Collider2D other){
		Debug.Log ("exit");
		if (other.gameObject.tag == "player")
			isNear = false;
	}
	*/

}
