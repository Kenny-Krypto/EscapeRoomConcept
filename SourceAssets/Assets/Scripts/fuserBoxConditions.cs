using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fuserBoxConditions : MonoBehaviour
{
    public GameObject fuseBox;
    public GameObject fuseR;
    public GameObject fuseG;
    public GameObject fuseB;
    private interactionScript fuseRScript;
    private interactionScript fuseGScript;
    private interactionScript fuseBScript;
    private interactionScript currentScript;
    private bool onlyOnce = false;
    private bool audioOnce = false;
    // Start is called before the first frame update
    void Start()
    {
        fuseRScript = fuseR.GetComponent<interactionScript>();
        fuseGScript = fuseG.GetComponent<interactionScript>();
        fuseBScript = fuseB.GetComponent<interactionScript>();
        currentScript = GetComponent<interactionScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!onlyOnce && fuseRScript.used && fuseRScript.used && fuseRScript.used) 
        {
            onlyOnce = true;
            currentScript.usable = true;
            fuseBox.GetComponent<textResponder>().invalidResponse = "Great now i can flip the switch!";
        }
        if (!audioOnce && GetComponent<interactionScript>().used)
            GetComponent<AudioSource>().enabled = true;
    }
}
