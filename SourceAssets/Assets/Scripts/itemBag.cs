using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemBag : MonoBehaviour
{
	private Vector3 originalpos; // hiding spot location
	private GameObject player; // core script
	private bool hidden = true; // if hidden
	public float dectectdist = 3f; // range to exit inventory
    // Start is called before the first frame update
    void Start()
    {
		player = GameObject.FindGameObjectsWithTag("Player")[0];
		originalpos = transform.position;
    }
	// get hidden state
	public bool isHidden()
	{
		return hidden;
	}
	// Show inventory
	public void showInventory() 
	{// move inventory to user
		transform.position = Camera.main.transform.position +(Camera.main.transform.forward * 2);
		transform.rotation = Camera.main.transform.rotation;
		hidden = false;
	}
	
	public void hideInventory() 
	{// move inventory to user
		transform.position = originalpos; // return to hidden spot
		hidden = true;
	}
	
    // Update is called once per frame
    void Update()
    {
		if(!hidden) 
		{
			if(Vector3.Distance(transform.position, Camera.main.transform.position) > dectectdist)
			{
				hideInventory();
			}
			else 
			{//face the player
				transform.rotation = Camera.main.transform.rotation;
			}
		}
    }
	//
	void OnMouseDown() 
	{

	}
}
