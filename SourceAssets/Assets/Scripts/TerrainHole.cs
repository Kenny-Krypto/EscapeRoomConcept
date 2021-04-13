using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainHole : MonoBehaviour
{
    public Collider terrain;
	public GameObject playerObject;
    private Rigidbody playerRB;
	private bool playerinside = false;
	
	void Start() 
	{
		playerRB = playerObject.GetComponent<Rigidbody>();
	}

    // When a new body enters the trigger,
    // make it start ignoring the terrain's collision.
    private void OnTriggerEnter(Collider other) {
        Rigidbody body = other.GetComponent<Rigidbody>();

        if (body == playerRB) {
			playerinside = true;
            Physics.IgnoreCollision(other, terrain);
        }
    }

    // When a new body enters the trigger,
    // do not ignore anymore
    private void OnTriggerExit(Collider other) {
        Rigidbody body = other.GetComponent<Rigidbody>();

        if(playerinside) {
            playerinside = false;
            Physics.IgnoreCollision(other, terrain, false);
        }       
    }
}
