using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightSwitch : MonoBehaviour
{ // turn on or off light if clicked on
	public GameObject lightSourceOn;
	public GameObject lightSourceOff;
	public bool lightOn;
	public bool isLightSwitch;
	private Light light;
	private Animator animator;
	private Renderer lightOnRenderer;
	private Renderer lightOffRenderer;
    // Start is called before the first frame update
    void Start()
    {
		
		if(isLightSwitch)
		{
			animator = GetComponent<Animator>();
			animator.updateMode = AnimatorUpdateMode.AnimatePhysics;
			lightOnRenderer = lightSourceOn.GetComponent<Renderer>();
			lightOffRenderer = lightSourceOff.GetComponent<Renderer>();
		}
        light = lightSourceOn.GetComponent<Light>();
        if(lightOn) 
		{
			light.enabled = true;
			if(isLightSwitch) 
			{
				animator.SetBool("isOn", true);
				lightOnRenderer.enabled = true;
				lightOffRenderer.enabled = false;
			}
		}
		else
		{
			light.enabled = false;
			if(isLightSwitch) 
			{
				animator.SetBool("isOn", false);
				lightOnRenderer.enabled = false;
				lightOffRenderer.enabled = true;
			}
		}
        
    }

    // Update is called once per frame
    void OnMouseDown()
    {
        if(lightOn) 
		{
			light.enabled = false;
			lightOn = false;
			if(isLightSwitch) 
			{
				GetComponent<AudioSource>().Play();
				animator.SetBool("isOn", false);
				lightOnRenderer.enabled = false;
				lightOffRenderer.enabled = true;
			}
		}
		else
		{
			light.enabled = true;
			lightOn = true;
			if(isLightSwitch)
			{
				GetComponent<AudioSource>().Play();
				animator.SetBool("isOn", true);
				lightOnRenderer.enabled = true;
				lightOffRenderer.enabled = false;
			}
		}
    }
}
