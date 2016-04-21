using UnityEngine;
using System.Collections;
using FSMHelper;

public class State_CorrectTokens : BaseFSMState {
	ParejasBehaviourStateMachine SM;
	float m_Timer;

	public override void Enter ()
	{
		SM = (ParejasBehaviourStateMachine)GetStateMachine();
		SM.m_ssb.texto.text = "GREAT!!";
		m_Timer = 0;
		SM.m_Pieza1.SetActive (false);
		SM.m_Pieza2.SetActive (false);
		SM.m_ssb.m_Correctas++;
		SM.m_ssb.m_CorrectasText.text = SM.m_ssb.m_Correctas + " / 12";
		SM.m_EverLoopController.GetComponent<AudioSource> ().PlayOneShot(SM.m_ssb.m_Correct);
		if (SM.m_ssb.m_Correctas < 12)
		{
			SM.m_EverLoopController.GetComponent<EverloopController> ().FadeInLayer (SM.m_EverLoopController.GetComponents<AudioSource> () [SM.m_ssb.m_Correctas],3.0f);
		}
	}
	
	public override void Exit ()
	{
		
	}
	
	public override void Update ()
	{
		m_Timer += Time.deltaTime;

		if (m_Timer >= 0.5f) {
	
			if (SM.m_ssb.m_Correctas == 12) {
				DoTransition(typeof(State_GameFinished));
			} else {
				DoTransition(typeof(State_WaitToken1));
			}
		
		}	
	}


}
