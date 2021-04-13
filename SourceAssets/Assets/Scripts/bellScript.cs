using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bellScript : MonoBehaviour
{
    public GameObject bellCore;
    public GameObject roofFull;
    public GameObject roofTiles;
    public GameObject BellSourceObject;
    public GameObject CrashSourceObject;
    private interactionScript objectScript;
    private bool runOnce = false;
    // Start is called before the first frame update
    void Start()
    {
        objectScript = GetComponent<interactionScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!runOnce && objectScript.used)
        {
            roofFull.SetActive(false);
            roofTiles.SetActive(true);
            bellCore.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            BellSourceObject.GetComponent<AudioSource>().enabled = true;
            StartCoroutine(crash()); // crash 

        }
    }

    private IEnumerator crash()
    {
        yield return new WaitForSeconds(3f); //wait
        CrashSourceObject.GetComponent<AudioSource>().enabled = true;

    }
}
