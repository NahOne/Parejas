﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LogicMenu : MonoBehaviour {
    public GameObject gamePanel;
    public GameObject scorePanel;
    public AudioClip soundNext;
    public AudioClip soundBack;
    public Text score1;
    public Text score2;
    public Text score3;
    public Text score4;
    public Text score5;
    
    int[] scoreValues;

    // Use this for initialization
    void Start () {
        scoreValues = new int[6];
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

        for (int i = 0; i < 5; ++i)
            scoreValues[i] = PlayerPrefs.GetInt("bestScore" + (i+1), 99999);
        scoreValues[5] = (int)PlayerPrefs.GetFloat("CurrentScore", 99999);

        InsertSort();

        for (int i = 0; i < 5; ++i)
        {
            PlayerPrefs.SetInt("bestScore" + (i+1), scoreValues[i]);
            Debug.Log("Score2 " + i + ": " + scoreValues[i]);
        }

        if (PlayerPrefs.GetInt("bestScore1", 0) < 99999)
        {
            score1.gameObject.SetActive(true);
            score1.text = "1- " + GetFormatTime(PlayerPrefs.GetInt("bestScore1", 0));
        }
        else
            score1.gameObject.SetActive(false);

        if (PlayerPrefs.GetInt("bestScore2", 0) < 99999)
        {
            score2.gameObject.SetActive(true);
            score2.text = "2- " + GetFormatTime(PlayerPrefs.GetInt("bestScore2", 0));
        }
        else
            score2.gameObject.SetActive(false);

        if (PlayerPrefs.GetInt("bestScore3", 0) < 99999)
        {
            score3.gameObject.SetActive(true);
            score3.text = "3- " + GetFormatTime(PlayerPrefs.GetInt("bestScore3", 0));
        }
        else
            score3.gameObject.SetActive(false);

        if (PlayerPrefs.GetInt("bestScore4", 0) < 99999)
        {
            score4.gameObject.SetActive(true);
            score4.text = "4- " + GetFormatTime(PlayerPrefs.GetInt("bestScore4", 0));
        }
        else
            score4.gameObject.SetActive(false);

        if (PlayerPrefs.GetInt("bestScore5", 0) < 99999)
        {
            score5.gameObject.SetActive(true);
            score5.text = "5- " + GetFormatTime(PlayerPrefs.GetInt("bestScore5", 0));
        }
        else
            score5.gameObject.SetActive(false);

        gamePanel.SetActive(!show);
        scorePanel.SetActive(show);
    }

    public void Exit()
    {
        GetComponent<AudioSource>().PlayOneShot(soundBack);
        Application.Quit();
    }

    void InsertSort()
    {
        int i, j;
        int tmp;
        for (i = 1; i < scoreValues.Length; ++i)
        {
            j = i;
            while (j > 0 && scoreValues[j - 1] > scoreValues[j])
            {
                tmp = scoreValues[j];
                scoreValues[j] = scoreValues[j - 1];
                scoreValues[j - 1] = tmp;
                --j;
            }            
        }
    }

    string GetFormatTime(int time)
    {
        float minutes = Mathf.Floor(time / 60);
        float seconds = Mathf.RoundToInt(time % 60);

        return (minutes < 10.0f ? ("0" + minutes.ToString()) : minutes.ToString())
            + ":" + (seconds < 10.0f ? ("0" + seconds.ToString()) : seconds.ToString());
    }
}
