using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
This classifies children as items with specfic ids, and controlls when they appear to some degree.
if classState = 0, assign ids for items that needs to be collected by playerScript
if classState = 1, assign ids for items that exists in inventory
if classState = 2, assign ids for items that exists in player's hands
*/
public class itemController : MonoBehaviour
{
	public int classState = 0; // which set of objects are classified
	private int[] originalStates; // to detect changes in item's states
	private List<GameObject> items = new List<GameObject>(); // quicker method
	private int itemsLength = 0; // how many items assigned by player script
	private Player playerScript; // player script
	private bool gone = false; // unknown
    // Start is called before the first frame update
    void Start()
    {
		var temp = GameObject.FindGameObjectsWithTag("Player")[0];
        playerScript = temp.GetComponent<Player>(); // get core player script
		itemsLength = playerScript.items; // get items that are availble
		originalStates = new int[itemsLength];
		for(int i = 0; i < itemsLength; i++) 
		{
			items.Add(this.gameObject.transform.GetChild(i).gameObject);
			items[i].GetComponent<grabScript>().id = i;
			items[i].GetComponent<grabScript>().state = classState;
			if(classState > 0) //if it is inventory or in hand make sure it is inactive, since player doesn't have it. 
			{
				items[i].SetActive(false);
			}
			originalStates[i] = 0;
		}
    }

    // Update is called once per frame
    void Update()
    {
		if(classState > 0) // if it exists in inventory or hand
		{
			for(int i = 0; i < itemsLength; i++) // check all items for changes in state
			{
				if((playerScript.itemStatus[i] - originalStates[i]) != 0) // if state of item changes
				{
					if(classState == playerScript.itemStatus[i]) //SetActive if it is correct state with classState
					{
						items[i].SetActive(true);
					}
					else  //Set not active otherwise
					{
						items[i].SetActive(false);
					}
					originalStates[i] = playerScript.itemStatus[i]; // record state
				}
			}
		}
    }
	//
}
