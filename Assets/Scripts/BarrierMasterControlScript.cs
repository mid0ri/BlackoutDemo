using UnityEngine;
using System.Collections;

public class BarrierMasterControlScript : MonoBehaviour {
	
	public Collider2D[] redBarriers, yellowBarriers, purpleBarriers;
	private int currentActiveBarrierId; //determine which barrier is currently active
	//-1 means all are active and 0 none are active; 1 - red | 2 - yellow | 3 - purple
	private KeyCode[] barriersKeys = {
		KeyCode.Alpha1,
		KeyCode.Alpha2,
		KeyCode.Alpha3,
		KeyCode.Keypad1,
		KeyCode.Keypad2,
		KeyCode.Keypad3
	};
		
	void Start () {		
		currentActiveBarrierId = -1;
	}

	void Update () {
		if (Input.GetKeyDown (barriersKeys [0]) || Input.GetKeyDown (barriersKeys [3]))
			EnableBarriers (1);
		
		if (Input.GetKeyDown (barriersKeys [1]) || Input.GetKeyDown (barriersKeys [4]))
			EnableBarriers (2);

		if (Input.GetKeyDown (barriersKeys [2]) || Input.GetKeyDown (barriersKeys [5])) 
			EnableBarriers (3);
		
	}
	void EnableAll(){
		foreach (Collider2D aBarrier in redBarriers)
			aBarrier.enabled = true;
		foreach (Collider2D aBarrier in yellowBarriers)
			aBarrier.enabled = true;
		foreach (Collider2D aBarrier in purpleBarriers)
			aBarrier.enabled = true;
	}
	void EnableBarriers(int barrierID){
		if (barrierID != currentActiveBarrierId) {
			Debug.Log ("react barrier" + barrierID);
			//reactivating current
			EnableAll();

			//deactivating barrier
			switch (barrierID) {
			case 1:
				Debug.Log ("+red");
				foreach (Collider2D aBarrier in redBarriers)
					aBarrier.enabled = false;
				break;
			case 2:
				Debug.Log ("+yellow");
				foreach (Collider2D aBarrier in yellowBarriers)
					aBarrier.enabled = false;
				break;
			case 3:
				Debug.Log ("+purple");
				foreach (Collider2D aBarrier in purpleBarriers)
					aBarrier.enabled = false;
				break;
			}
		}
	}

}