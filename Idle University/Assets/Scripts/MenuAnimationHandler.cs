using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuAnimationHandler : MonoBehaviour {
    public Button[] buttons;

	void Start () {
        //All buttons, except for the main one, are hidden when the game starts.
		foreach (Button b in buttons)
        {
            b.gameObject.SetActive(false);
        }
	}

    public void OpenMenu()
    {
        Debug.Log("Here");
        StartCoroutine(ButtonShow());
    }

    IEnumerator ButtonShow()
    {
        for (int count = 0; count < buttons.Length; count++)
        {
            yield return new WaitForSeconds(0.075f);
            buttons[count].gameObject.SetActive(true);
            
        }
    }
	
}
