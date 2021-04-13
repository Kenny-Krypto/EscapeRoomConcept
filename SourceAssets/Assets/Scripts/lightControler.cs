using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightControler : MonoBehaviour
{
    public GameObject[] lights;
    public GameObject specialLight;
    public GameObject exitDoor;
    private interactionScript target;
    private bool lightsOn = false;


    // Start is called before the first frame update
    void Start()
    {
        exitDoor.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        target = GetComponent<interactionScript>();
        specialLight.transform.GetChild(0).GetComponent<Light>().enabled = false;
        specialLight.transform.GetChild(0).GetComponent<Renderer>().enabled = false;
        for (int i = 0; i < lights.Length; i++)
        {
            lights[i].transform.GetChild(0).GetComponent<Light>().enabled = false;
            lights[i].transform.GetChild(0).GetComponent<Renderer>().enabled = false;
            lights[i].transform.GetChild(1).GetComponent<Renderer>().enabled = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!lightsOn && target.animationDone)
        {
            exitDoor.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            exitDoor.GetComponent<textResponder>().invalidResponse = "";
            specialLight.transform.GetChild(0).GetComponent<Light>().enabled = true;
            specialLight.transform.GetChild(0).GetComponent<Renderer>().enabled = true;
            for (int i = 0; i < lights.Length; i++)
            {
                lights[i].transform.GetChild(0).GetComponent<Light>().enabled = true;
                lights[i].transform.GetChild(0).GetComponent<Renderer>().enabled = true;
                lights[i].transform.GetChild(1).GetComponent<Renderer>().enabled = false;
            }
        }
    }
}
