using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unlockScriptor : MonoBehaviour
{
    public GameObject[] targets;
    private bool unlocked = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.activeSelf && !unlocked) 
        {
            unlocked = true;
            for (int i = 0; i < targets.Length; i++) 
            {
                targets[i].GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            }
        }
    }
}
