using UnityEngine;
using System.Collections;

public class BarrierLeverScript : MonoBehaviour {

	public int BarrierID;
	public BarrierMasterControlScript barrierMaster;
	private bool isOff, canActivate;
	private Animator LeverAnimator;

	// Use this for initialization
	void Start () {
		isOff = false;
		canActivate = false;
		LeverAnimator = GetComponent<Animator> ();
	}

	/*void OnTriggerStay2D(Collider2D other){
		if(other.gameObject.CompareTag("Player")){
			if(Input.GetKeyDown(KeyCode.E)){
				barrierMaster.EnableBarriers (BarrierID);
				LeverAnimator.SetBool ("isOff", true);
			}				
		}
	}*/

	void Update(){
		if(canActivate){
			if(Input.GetKeyDown(KeyCode.E)){
				Debug.Log ("id = " + BarrierID);
				barrierMaster.EnableBarriers (BarrierID);
				LeverAnimator.SetBool ("isOff", true);
			}
		}			
	}
	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.CompareTag("Player"))
			canActivate = true;     
	}

	void OnTriggerExit2D(Collider2D other){
		if (other.gameObject.CompareTag ("Player"))
			canActivate = false;
	}
}
