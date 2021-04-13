using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialInteractionScript : MonoBehaviour
{
    public int diamondID = 0;
    public int candleID = 0;
    public int bellCoreID = 0;
    public GameObject drawer;
    public GameObject glass;
    public GameObject diamondShow;
    public GameObject candleShow;
    public GameObject bellCoreShow;
    private bool hasAll = false;
    private bool hasDiamond = false;
    private bool hasCandle = false;
    private bool hasBellCore = false;
    private bool checkedDiamond = false;
    private bool checkedCandle = false;
    private bool checkedBellCore = false;
    private Player playerScript; // get player script
    private textResponder playerText; // get player text script
    private int itemCount = 0;
    public string invalidStr = "";
    public string validStr = ""; // repsonse
    // Start is called before the first frame update
    void Start()
    {
        var temp = GameObject.FindGameObjectsWithTag("Player")[0];
        playerScript = temp.GetComponent<Player>(); // get core player script
        playerText = GetComponent<textResponder>();
        playerText.invalidResponse = invalidStr;
}

    // Update is called once per frame
    void Update()
    {
        if (hasDiamond && hasCandle && hasBellCore && !hasAll) 
        { // if user has all three objects
            hasAll = true;
            playerText.invalidResponse = validStr;
        }
        if (!checkedDiamond && playerScript.itemStatus[diamondID] > 0)
        { //check if user got diamond
            checkedDiamond = true;
            hasDiamond = true;
        }
        if (!checkedCandle && playerScript.itemStatus[candleID] > 0)
        { //check if user got candle
            checkedCandle = true;
            hasCandle = true;
        }
        if (!checkedBellCore && playerScript.itemStatus[bellCoreID] > 0)
        { //check if user got bellcore
            checkedBellCore = true;
            hasBellCore = true;
        }
        if (itemCount == 3) 
        {// if user used all 3 items
            itemCount = 0;
            StartCoroutine(animateFinal());
        }
        /*
        if (!oldString.Equals(newString)) 
        {

        }
        */
    }
    private IEnumerator animateFinal() 
    {
        glass.GetComponent<Animator>().SetBool("use", true);
        glass.GetComponent<BoxCollider>().enabled = true;
        yield return new WaitForSeconds(1.0f); //wait for animation to be done then do the rest:
        drawer.GetComponent<Animator>().SetBool("use", true);
    }

    private void OnMouseDown()
    {
        if (hasAll)
        {
            if (playerScript.itemEquipped == diamondID)
            {
                playerScript.itemStatus[diamondID] = 3; // set to be in use
                playerScript.itemEquipped = -1; // unequip
                diamondShow.SetActive(true);
                itemCount += 1;
            }
            if (playerScript.itemEquipped == candleID)
            {
                playerScript.itemStatus[candleID] = 3; // set to be in use
                playerScript.itemEquipped = -1; // unequip
                candleShow.SetActive(true);
                itemCount += 1;

            }
            if (playerScript.itemEquipped == bellCoreID)
            {
                playerScript.itemStatus[bellCoreID] = 3; // set to be in use
                playerScript.itemEquipped = -1; // unequip
                bellCoreShow.SetActive(true);
                itemCount += 1;

            }

        }
    }
}
