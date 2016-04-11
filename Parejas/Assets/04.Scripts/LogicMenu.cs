using UnityEngine;
using System.Collections;

public class LogicMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    private void StartGame()
    {
        Application.LoadLevel(1);
    }

    private void ShowRanking()
    {

    }

    private void Exit()
    {
        Application.Quit();
    }
}
