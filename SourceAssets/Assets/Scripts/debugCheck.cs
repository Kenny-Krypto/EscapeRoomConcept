using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class debugCheck : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // OnDisable
    void OnDisable()
    {
         Debug.Log("PrintOnDisable: script was disabled");
    }
}
