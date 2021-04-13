using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	// 0 = not found, 1 = found, 2 = equiped, 3 = lost
	public int items = 4;
	public int[] itemStatus;
	// {Cube, Sphere, Cylinder, Key}
	public int itemEquipped = -1; // shows what item is equipped, -1 = nothing
	private itemBag inventory;
    // Start is called before the first frame update
    void Start()
    {
		itemStatus = new int[items];
		for(int i = 0; i < items; i++)
		{
			itemStatus[i] = 0;
		}
		var temp = GameObject.FindGameObjectsWithTag("Inventory")[0];
		inventory = temp.GetComponent<itemBag>();

        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("tab"))
        {
			if(inventory.isHidden()) 
			{
				print("inventory was opened");
				inventory.showInventory();
			}
			else 
			{
				print("inventory was closed");
				inventory.hideInventory();
			}
        }
    }
}
