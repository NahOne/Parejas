using UnityEngine;
using System.Collections;
using FSMHelper;

public class State_GameFinished : BaseFSMState {
	ParejasBehaviourStateMachine SM;

	public override void Enter ()
	{
		SM = (ParejasBehaviourStateMachine)GetStateMachine();
        PlayerPrefs.SetFloat("CurrentScore", SM.m_ssb.m_Time);
        PlayerPrefs.Save();
		SM.m_EverLoopController.GetComponent<AudioSource> ().PlayOneShot(SM.m_ssb.m_Finish);
		SM.m_ssb.InvokeGoToMainMenu (2.0f);
	}
	
	public override void Exit ()
	{
		
	}
	
	public override void Update ()
	{
		
	}
}
