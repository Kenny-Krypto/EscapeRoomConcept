using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerDetectorDoor : MonoBehaviour
{
	private Animator animator;
	private Transform fpc;
	public GameObject targetObject;
	public float dectectdist = 5f;

	// Start is called before the first frame update
	void Start()
	{
		fpc = targetObject.transform;
		animator = GetComponent<Animator>();
		animator.updateMode = AnimatorUpdateMode.AnimatePhysics;
	}
	// Update is called once per frame
	void Update()
	{

		if (Vector3.Distance(transform.position, fpc.position) < dectectdist)
		{
			animator.SetBool("opened", true);
		}
		else
		{
			animator.SetBool("opened", false);
		}


	}
}

