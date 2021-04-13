using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UserUIText : MonoBehaviour
{
	private TextMeshPro textField;
	private bool isTicking = false;
	private int ticks = 5;
    // Start is called before the first frame update
    void Start()
    {
		textField = GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
	void Update() 
	{
		if(ticks > 0)
		{
			if(!isTicking)
			{
				isTicking = true;
				StartCoroutine( tick() );
			}
		}
	}
	
	private IEnumerator tick()
	{
        yield return new WaitForSeconds(1);
        ticks = ticks-1;
		if(ticks < 1) 
		{
			textField.text = "";
		}
		isTicking = false;
	}
	
    public void showText(string inputText)
	{
		ticks = 5;
		textField.text = inputText;
	}
	
	
}
