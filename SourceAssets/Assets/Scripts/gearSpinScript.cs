using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gearSpinScript : MonoBehaviour
{
    public float rpm = 30f;
    public float[] forkscale = { 1, 6, 3, 1};
    public GameObject[] gears;
    public GameObject gearBox;
    private float[] alternate = { 1, -1 };
    private interactionScript gearBoxScript;
    // Start is called before the first frame update
    void Start()
    {
        gearBoxScript = gearBox.GetComponent<interactionScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gearBoxScript.used) 
        {//rotate gears
            for (int i = 0; i < gears.Length; i++) 
            {
                gears[i].transform.Rotate(0, 0, 6.0f * rpm * Time.deltaTime * alternate[i%2]*forkscale[i]);
            }
            
        }
    }
}
