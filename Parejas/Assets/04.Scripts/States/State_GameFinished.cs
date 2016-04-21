using UnityEngine;
using System.Collections;
using FSMHelper;
using UnityEngine.SceneManagement;

public class State_GameFinished : BaseFSMState {
	ParejasBehaviourStateMachine SM;

	public override void Enter ()
	{
		SM = (ParejasBehaviourStateMachine)GetStateMachine();
        PlayerPrefs.SetFloat("CurrentScore", SM.m_ssb.m_Time);
        PlayerPrefs.Save();
		SceneManager.LoadScene (0);
	}
	
	public override void Exit ()
	{
		
	}
	
	public override void Update ()
	{
		
	}
}
