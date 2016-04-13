using UnityEngine;
using System.Collections;

public class barrierLeverScript : MonoBehaviour {

	public int BarrierID;
	public BarrierMasterControlScript barrierMaster;
	private bool isOff;
	private Animator LeverAnimator;

	// Use this for initialization
	void Start () {
		isOff = false;
		LeverAnimator = GetComponent<Animator> ();
	}

	void OnTriggerStay2D(Collider2D other){
		if(Input.GetKey(KeyCode.X) && other.gameObject.tag == "Player"){
			barrierMaster.SendMessage ("EnableBarriers", BarrierID);
			Debug.Log ("turn off");
			LeverAnimator.SetBool ("isOff", true);
		}
	} 
}
