using UnityEngine;
using System.Collections;

public class EnemyProjectileController : MonoBehaviour {

    public float speed;
    public PlayerController player;
    public GameObject impactEffect;
    public int damageToGive;
    private Rigidbody2D myrigidbody2D;
    private HealthBarManager hurtPlayer;
    

	// Use this for initialization
	void Start ()
    {
        player = FindObjectOfType<PlayerController>();

        myrigidbody2D = GetComponent<Rigidbody2D>();

        if(player.transform.position.x < transform.position.x)
        {
            speed = -speed;

        }
	}
	
	// Update is called once per frame
	void Update ()
    {
        myrigidbody2D.velocity = new Vector2(speed, myrigidbody2D.velocity.y);
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            //hurtPlayer.OnCollisionEnter2D();

            //hurtPlayer.SendKnockBackMessage(other.transform.position);
            //hurtPlayer.numberOfHearts--;
            //hurtPlayer.hearts[hurtPlayer.numberOfHearts].SetActive(false);
            //Destroy(gameObject);
        }
        //Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
