using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class glassLock : MonoBehaviour
{
    public GameObject[] locksRGB;
    public int[] passcode = {1,2,3};
    public string lockedText = "";
    public string unlockedText = "";
    private spinLock lockR;
    private spinLock lockG;
    private spinLock lockB;
   // private DragRigidbody grabItem;
    private Rigidbody itemRB;
    private bool locked = true;
    // Start is called before the first frame update
    void Start()
    {
        itemRB = GetComponent<Rigidbody>();
        itemRB.constraints = RigidbodyConstraints.FreezeAll;
        lockR = locksRGB[0].GetComponent<spinLock>();
        lockG = locksRGB[1].GetComponent<spinLock>();
        lockB = locksRGB[2].GetComponent<spinLock>();
        GetComponent<textResponder>().invalidResponse = lockedText;
    }

    // Update is called once per frame
    void Update()
    {
        if (locked && lockR.state == passcode[0] && lockG.state == passcode[1] && lockB.state == passcode[2]) 
        {
            locked = false;
            GetComponent<textResponder>().invalidResponse = unlockedText;
            itemRB.constraints = RigidbodyConstraints.None;
            locksRGB[0].GetComponent<AudioSource>().enabled = true;
        }
    }
}
