using UnityEngine;
using System.Collections;
using FSMHelper;

public class State_FailTokens : BaseFSMState {
	ParejasBehaviourStateMachine SM;
	float m_Timer;
	public override void Enter ()
	{
		SM = (ParejasBehaviourStateMachine)GetStateMachine();
		SM.m_ssb.texto.text = "FAIL!!";
		SM.m_Pieza1.GetComponentInParent<Animator>().SetInteger("girar", -1);
		SM.m_Pieza2.GetComponentInParent<Animator>().SetInteger("girar", -1);
		m_Timer = 0;
	}
	
	public override void Exit ()
	{
		
	}
	
	public override void Update ()
	{
		m_Timer += Time.deltaTime;
		if (m_Timer >= 1.5f) {
			DoTransition(typeof(State_WaitToken1));
		}			
	}
}
