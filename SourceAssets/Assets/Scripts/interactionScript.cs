using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactionScript : MonoBehaviour
{
	public int InteractObjectID = -2; // which object can unlock object
	public bool loseObject = false; // lose object if used
	public bool locked = false; // if item is locked in place
	public GameObject InteractObject; // object used in animation
	public bool used = false; // shows object has been used on this item
	public string validTxt = ""; // text if item has been used
	public string unvalidTxt = ""; // text if item has not been used
	public string unusableValidTxt = ""; // text if item has been used on object
	public string unusableInvalidTxt = ""; // text if item can't be used
	public bool usable = true; // stops item from being usable.
	public float animationTime = 0.0f;
	public bool animationDone = false;
	public bool selfAnimation = false;
	public bool switchObject = false; //replace current item once used
	public GameObject[] objectsSwitching;  // replace with.
	private bool usableChanged; // checking if it has been changed
	private bool hasAnimator = false; // check if it has an animator
	private bool hasRB = false; // check if it has an RigidBody
	private Player playerScript; // get player script
	private Animator animator; // get current object animator
	private Rigidbody rigidbody; // get current object rigidbody
	private textResponder playerText; // get player text script
	private bool isText; // has text script
	// Start is called before the first frame update
	void Start()
    {
		usableChanged = !usable;
		if(InteractObjectID == -2)
		{
			print(gameObject.name + "does not have interact Object ID");
		}
		playerText = GetComponent<textResponder>();
		if (playerText == null)
		{
			isText = false;
		}
		else 
		{
			playerText.itemTarget = InteractObjectID;
			if (usable)
			{
				playerText.invalidResponse = unvalidTxt;
				playerText.validResponse = validTxt;
			}
			else
			{
				playerText.invalidResponse = unusableInvalidTxt;
				playerText.validResponse = unusableValidTxt;
			}
		}
		var temp = GameObject.FindGameObjectsWithTag("Player")[0];
        playerScript = temp.GetComponent<Player>(); // get core player script
		rigidbody = GetComponent<Rigidbody>();
		if(rigidbody == null)
		{
			hasRB = false;
		}
		else 
		{
			hasRB = true;
			if(locked) 
			{
				rigidbody.constraints = RigidbodyConstraints.FreezeAll;
			}
		}
		if (InteractObject != null)
		{ 
			animator = InteractObject.GetComponent<Animator>();
			InteractObject.SetActive(false);
		}
		if(selfAnimation)
			animator = GetComponent<Animator>();
		if (animator == null)
		{
			hasAnimator = false;
		}
		else
		{
			hasAnimator = true;
			animator.updateMode = AnimatorUpdateMode.AnimatePhysics;
		}
	}

    // Update is called once per frame
    private void Update()
    {
		if (usable == usableChanged)
		{
			usableChanged = !usable;
			if (usable)
			{
				playerText.invalidResponse = unvalidTxt;
				if (InteractObjectID < 0 && used)
					playerText.invalidResponse = validTxt;
				else
					playerText.validResponse = validTxt;
			}
			else
			{
				playerText.invalidResponse = unusableInvalidTxt;
				if (InteractObjectID < 0 && used)
					playerText.invalidResponse = unusableValidTxt;
				else
					playerText.validResponse = unusableValidTxt;
			}
		}
    }
    void OnMouseDown()
    {
		if (usable)
		{
			if (!used && playerScript.itemEquipped == InteractObjectID)
			{
				used = true;
				playerScript.itemStatus[InteractObjectID] = 3; // put in use to despawn object from hand or field
				if (hasAnimator)
				{
					animateAction();
				}
				else
				{
					if (switchObject)
						replacementShow();
					if (InteractObject != null)
						InteractObject.SetActive(true);
					if (loseObject)
					{
						usable = false;
						playerScript.itemEquipped = -1;
					}
					else
					{
						if (InteractObject != null)
							InteractObject.SetActive(false);
						playerScript.itemStatus[InteractObjectID] = 2;
					}
					if (switchObject)
						gameObject.SetActive(false);
				}
			}
			else if (!used && InteractObjectID < 0)
			{
				used = true;
				if (hasAnimator)
				{
					animateAction();
				}
				else
				{
					if(switchObject)
						replacementShow();
					if (InteractObject != null)
						InteractObject.SetActive(true);
					if (loseObject)
					{
						usable = false;
					}
					else
					{
						if (InteractObject != null)
							InteractObject.SetActive(false);
					}
					if (switchObject)
						gameObject.SetActive(false);
				}
			}
		}
    }

	private void animateAction()
	{
		if (InteractObject != null)
		{
			InteractObject.SetActive(true);
			if (InteractObject.GetComponent<AudioSource>() != null)
				InteractObject.GetComponent<AudioSource>().Play();
		}
		animator.SetBool("use", true);
		StartCoroutine(wait()); // wait 
	}
	private void replacementShow()
	{
		for (int i = 0; i < objectsSwitching.Length; i++) 
		{
			objectsSwitching[i].SetActive(true);
		}
	}

	private IEnumerator wait()
	{
		yield return new WaitForSeconds(animationTime); //wait for 1.5s for animation to be done then do the rest:
		animationDone = true;
		if (hasRB)
		{
			rigidbody.constraints = RigidbodyConstraints.None;
		}
		if (loseObject)
		{
			if(InteractObjectID > -1)
				playerScript.itemEquipped = -1;
			usable = false;
		}
		else
		{
			if (InteractObject != null)
				InteractObject.SetActive(false);
			if (InteractObjectID > -1)
				playerScript.itemStatus[InteractObjectID] = 2;
		}
		if (switchObject)
		{
			replacementShow();
			gameObject.SetActive(false);
		}
	}
}
