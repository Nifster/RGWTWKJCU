using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine.UI;
public class MenuManager : MonoBehaviour {

    public List<Sprite> Cutscene;
    public List<string> texts;
    int index = 0;

    public GameObject creditsPanel;
    public GameObject cutscenesPanel;
    public GameObject cutsceneImage;
    public GameObject cutsceneText;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void StartGame()
    {
        cutscenesPanel.SetActive(true);
        //SceneManager.LoadScene("main");
    }

    public void cutscenesButton()
    {
        index++;
        if (index > 2)
        {
            SceneManager.LoadScene("main");
        }
        else
        {
            cutsceneImage.GetComponent<Image>().sprite = Cutscene[index];
            cutsceneText.GetComponent<Text>().text = texts[index];
            
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Credits()
    {
        creditsPanel.SetActive(true);
    }

    public void ExitCredits()
    {
        creditsPanel.SetActive(false);
    }
}
