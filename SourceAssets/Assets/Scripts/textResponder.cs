using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class textResponder : MonoBehaviour
{
	public int itemTarget = -9;
	public string validResponse = "";
	public string invalidResponse = "";
	private Player playerScript; // get player script
	private UserUIText playerText; // get player Text
    // Start is called before the first frame update
    void Start()
    {
		var temp = GameObject.FindGameObjectsWithTag("Player")[0];
        playerScript = temp.GetComponent<Player>(); // get core player script
		var temp2 = GameObject.FindGameObjectsWithTag("UIText")[0];
        playerText = temp2.GetComponent<UserUIText>(); // get player Text
    }

    void OnMouseDown()
	{
		if(itemTarget > -1)
		{
			if (playerScript.itemStatus[itemTarget] > 2)
			{
				playerText.showText(validResponse);
			}
			else
			{
				playerText.showText(invalidResponse);
			}
		}
		else 
		{
			playerText.showText(invalidResponse);
		}
	}
}
