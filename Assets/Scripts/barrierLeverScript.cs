using UnityEngine;
using System.Collections;

public class barrierLeverScript : MonoBehaviour {

	public int BarrierID;
	public BarrierMasterControlScript barrierMaster;

	// Use this for initialization
	void Start () {
	}

	void OnTriggerStay2D(Collider2D other){
		if(Input.GetKey(KeyCode.X) && other.gameObject.tag == "Player"){
			barrierMaster.SendMessage ("EnableBarriers", BarrierID);
			Debug.Log ("turn off");
		}
	} 
}
