using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuAnimationHandler : MonoBehaviour {
    public Button[] buttons;
    public Button spawnButton;
    public Button minimiseButton;
    public Text spawnText;
    private bool open;

	void Start () {
        //All buttons, except for the main one, are hidden when the game starts.
		foreach (Button b in buttons)
        {
            b.gameObject.SetActive(false);
        }
        open = false;
	}

    public void MenuClick()
    {
        if (open == false)
        {
            OpenMenu();
        } else
        {
            CloseMenu();
        }
    }

    public void OpenMenu()
    {
        StartCoroutine(ButtonShow());
        open = true;
    }

    public void CloseMenu()
    {
        StartCoroutine(ButtonHide());
        open = false;
    }

    public void MinimiseSpawnButton()
    {
        minimiseButton.gameObject.SetActive(false);
        spawnText.text = "";
        StartCoroutine(Minimise());
    }

    public void MaximiseSpawnButton()
    {

    }

    IEnumerator ButtonShow()
    {
        for (int count = 0; count < buttons.Length; count++)
        {
            yield return new WaitForSeconds(0.06f);
            buttons[count].gameObject.SetActive(true);
            
        }
    }

    IEnumerator ButtonHide()
    {
        Debug.Log("In hide");
        for (int count = buttons.Length - 1; count >= 0; count--)
        {
            yield return new WaitForSeconds(0.06f);
            buttons[count].gameObject.SetActive(false);

        }
    }

    IEnumerator Minimise()
    {
        for (float x = spawnButton.GetComponent<RectTransform>().sizeDelta.x; x > 100; x -= 20)
        {
            yield return new WaitForSeconds(0.02f);
            spawnButton.GetComponent<RectTransform>().sizeDelta = new Vector2(x, spawnButton.GetComponent<RectTransform>().sizeDelta.y);
        }
    }
	
}
