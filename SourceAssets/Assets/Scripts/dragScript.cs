using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dragScript : MonoBehaviour
{
	public int distanceFromPlayer = 2;
	private bool drag = false; // object has been grabbed
    // Start is called before the first frame update
    void Start()
    {
    }
	
	void OnMouseDrag()
	{ // Drag object
		transform.position = Camera.main.transform.position + (Camera.main.transform.forward * distanceFromPlayer);
	}
}
