using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicDoorUnlockScript : MonoBehaviour
{
	public int InteractObjectID; // which object can unlock object
	public GameObject InteractObject; // object used in animation
	public bool locked = true;
	public string lockedText = "locked";
	public string unlockedText = "";
	private Player playerScript; // get player script
	private Animator animator;
	private Rigidbody rigidbody;
    // Start is called before the first frame update
    void Start()
    {
		GetComponent<textResponder>().invalidResponse = lockedText;
		var temp = GameObject.FindGameObjectsWithTag("Player")[0];
        playerScript = temp.GetComponent<Player>(); // get core player script
		animator = GetComponent<Animator>();
		animator.updateMode = AnimatorUpdateMode.AnimatePhysics;
		rigidbody = GetComponent<Rigidbody>();
		rigidbody.constraints = RigidbodyConstraints.FreezeAll;
		InteractObject.SetActive(false);
    }

    // Update is called once per frame
    void OnMouseDown()
    {
		if(locked && playerScript.itemEquipped == InteractObjectID) 
		{
			locked = false;
			GetComponent<textResponder>().invalidResponse = unlockedText;
			playerScript.itemStatus[InteractObjectID] = 3; // put in use to despawn object from hand or field
			animateAction();
			GetComponent<AudioSource>().Play();
		} 
    }
	
	private void animateAction() 
	{
		InteractObject.SetActive(true);
		animator.SetBool("Unlock", true);
		StartCoroutine(wait()); // wait 
	}
	
	private IEnumerator wait()
	{
        yield return new WaitForSeconds(1.5f); //wait for 1.5s for animation to be done then do the rest:
		rigidbody.constraints = RigidbodyConstraints.None;
		InteractObject.SetActive(false);
		playerScript.itemStatus[InteractObjectID] = 2;
	}
}
