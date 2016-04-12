using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LogicMenu : MonoBehaviour {
    public GameObject gamePanel;
    public GameObject scorePanel;
    public AudioClip soundNext;
    public AudioClip soundBack;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void StartGame()
    {
        GetComponent<AudioSource>().PlayOneShot(soundNext);
        Application.LoadLevel(1);
    }

    public void ShowRanking(bool show)
    {
        GetComponent<AudioSource>().PlayOneShot(show?soundNext:soundBack);
        gamePanel.SetActive(!show);
        scorePanel.SetActive(show);
    }

    public void Exit()
    {
        GetComponent<AudioSource>().PlayOneShot(soundBack);
        Application.Quit();
    }
}
