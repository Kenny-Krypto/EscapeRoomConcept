using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grabScript : MonoBehaviour
{
	public int id = 0; // item's identifier, will likely be edited by ItemController
	// Negative numbers are used for special cases, ex: -1 is to empty hand
	public int state = 0; // state type, if it is in the field, in inventory, or in hand
	private Player playerScript; // get player script
    // Start is called before the first frame update
    void Start()
    {
		var temp = GameObject.FindGameObjectsWithTag("Player")[0];
        playerScript = temp.GetComponent<Player>(); // get core player script
    }

    // Update is called once per frame
	void OnMouseDown()
	{
		if(state == -1) 
		{//if it is -1 special case for empty hand.
			if(playerScript.itemEquipped != -1) 
			{
				playerScript.itemStatus[playerScript.itemEquipped] = 1;
			}
			playerScript.itemEquipped = -1; 
		}
		else if(state == 0) 
		{ // if in state 0, pick up and put into inventory
			playerScript.itemStatus[id] = 1;
			gameObject.SetActive(false);
		}
		else if(state == 1)
		{ // if in state 1, put it in hand and unequip current item
			if (playerScript.itemEquipped != -1)
			{ // if hand is non-empty
				if (!(playerScript.itemStatus[playerScript.itemEquipped] == 3)) // check if item is in use do not allow user to change equipment
				{
					playerScript.itemStatus[playerScript.itemEquipped] = 1;
					playerScript.itemStatus[id] = 2;
					playerScript.itemEquipped = id;
					gameObject.SetActive(false);
				}
			}
			else
			{
				playerScript.itemStatus[id] = 2;
				playerScript.itemEquipped = id;
				gameObject.SetActive(false);
			}
		}
	}
}
