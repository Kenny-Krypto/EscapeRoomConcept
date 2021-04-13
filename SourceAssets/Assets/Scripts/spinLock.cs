using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spinLock : MonoBehaviour
{
    public int state = 0;
    private string[] states = { "90","01","12","23","34","45","56","67","78","89" };
    private Animator animator;
    private bool spinning = false;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.updateMode = AnimatorUpdateMode.AnimatePhysics;
    }

    // Update is called once per frame
    void OnMouseDown()
    {
        if (!spinning)
        {
            spinning = true;
            animator.SetBool(states[(state + 1) % 10], true);
            animator.SetBool(states[(state+2) % 10], false);
            state = (state + 1) % 10;
            StartCoroutine(wait()); // wait 
        }
    }
    private IEnumerator wait()
    {
        yield return new WaitForSeconds(0.1f); //wait for 0.1s for animation to be done then do the rest:
        spinning = false;
    }
}
