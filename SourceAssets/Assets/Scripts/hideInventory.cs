using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hideInventory : MonoBehaviour
{
    private itemBag inventory;
    // Start is called before the first frame update
    void Start()
    {
        var temp = GameObject.FindGameObjectsWithTag("Inventory")[0];
        inventory = temp.GetComponent<itemBag>();

    }

    void OnMouseDown()
    {
        inventory.hideInventory();
    }
}
