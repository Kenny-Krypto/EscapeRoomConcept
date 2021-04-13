using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorlockScript : MonoBehaviour
{
    public GameObject[] planks;
    private bool locked = true;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
    }

    // Update is called once per frame
    void Update()
    {
        if (locked) 
        {
            var temp = 0;
            for (int i = 0; i < planks.Length; i++) 
            {
                if (!planks[i].activeSelf) 
                {
                    temp += 1;
                }
            }
            if (temp == planks.Length)
                GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        }
    }
}
