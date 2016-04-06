using UnityEngine;
using System.Collections;

public class HealthBarManager : MonoBehaviour {
    //Health system based on hearts and not a percentage. Possibly Change?
    //Hey Khanh, I'm modifying this script so the hearts can be decremented in more ways than just colliding
    //with objects that have "Danger" tags. Basically so external scripts can call a method to decrease the
    //hearts from there. Probably need more hearts too but three is fine for now. Limited by sprites currently.

	public GameObject[] hearts;
	public int numberOfHearts;


	private PlayerController thePlayer;

	void Start () {
		numberOfHearts = hearts.Length;
		thePlayer = GetComponent<PlayerController> ();
	}

	public void OnCollisionEnter2D(Collision2D coll){
        //For some reason this sometimes takes more than one heart from the player. Not sure why.
		if(coll.gameObject.tag == "Danger")
        {
			SendKnockBackMessage (coll.transform.position);
			numberOfHearts--;
			hearts [numberOfHearts].SetActive (false);
		}

        if(coll.gameObject.tag == "Kill") //Tyler here, creating auto kill areas.
        {
            numberOfHearts = 0;
            foreach (GameObject go in hearts)
                go.SetActive(false);
        }

		if (numberOfHearts == 0){
			thePlayer.SendMessage ("SetDeath", true);
			Reset ();
		}			
	}

    public void OnTriggerEnter2D(Collider2D coll)
    {
        //For some reason this sometimes takes more than one heart from the player. Not sure why.
        if (coll.gameObject.tag == "EnemyProjectile")
        {
            SendKnockBackMessage(coll.transform.position);
            numberOfHearts--;
            hearts[numberOfHearts].SetActive(false);
        }

        if (coll.gameObject.tag == "Kill") //Tyler here, creating auto kill areas.
        {
            numberOfHearts = 0;
            foreach (GameObject go in hearts)
                go.SetActive(false);
        }

        if (numberOfHearts == 0)
        {
            thePlayer.SendMessage("SetDeath", true);
            Reset();
        }
    }

    private void Reset(){
		numberOfHearts = hearts.Length;
		foreach(GameObject go in hearts)
			go.SetActive (true);		
	}

	private void SetupScene(int resumeNumberOfHearts){
		numberOfHearts = resumeNumberOfHearts;
		for(int i=0; i<hearts.Length; i++){
			if (i < resumeNumberOfHearts)
				hearts [i].SetActive (true);
			else
				hearts [i].SetActive (false);
		}
	}
	IEnumerator haltMovement(){
		thePlayer.movementEnabled = false;
		yield return new WaitForSeconds (1f);
		thePlayer.movementEnabled = true;
	}

	public void SendKnockBackMessage(Vector3 hazardObjPos){
		StartCoroutine ("haltMovement"); 
		Vector3 heading = transform.position - hazardObjPos;
		heading /= (heading.magnitude);
		Vector2 directionConverted = new Vector2 (heading.x, heading.y);
		thePlayer.SendMessage ("RecieveKnockBackMessage", directionConverted);
	}

	public int getNumberOfActiveHearts(){
		return numberOfHearts; //Hey cool a get method.
	}

    //Eventually want to make methods to add health, reset health(Have that^), and deal specific damage(Here)
    public void hurtPlayer (int damageAmount) //Tyler: This is used when the player activates devices that need energy.
    {
        numberOfHearts = numberOfHearts-damageAmount;

        if (numberOfHearts < 0)//Just in case, making sure it can't go under 0 hearts/energy units.         
            numberOfHearts = 0;
		SetupScene (numberOfHearts);

        //heartUpdate();
    }

	/*
    //This individually updates every object in the heart array.
    private void heartUpdate()
    {
        for (int heartSlot = 1; heartSlot <= hearts.Length; heartSlot++)//heartSlot = 1 represents array space 0 and so on.
        {

            if (numberOfHearts >= heartSlot)
            {
                hearts[heartSlot - 1].SetActive(true);
            }
            else
            {
                hearts[heartSlot - 1].SetActive(false);
            }
        }

        if (numberOfHearts == 0) //Checking for death.
        {
            thePlayer.SendMessage("SetDeath", true);
            Reset();
        }
    }*/
}
