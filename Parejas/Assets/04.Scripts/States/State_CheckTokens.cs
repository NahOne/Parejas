using UnityEngine;
using System.Collections;
using FSMHelper;

public class State_CheckTokens : BaseFSMState {
	ParejasBehaviourStateMachine SM;
	float m_Timer;

	public override void Enter ()
	{
		SM = (ParejasBehaviourStateMachine)GetStateMachine();
		SM.m_ssb.texto.text = "Revisando";
		m_Timer = 0;
	}

	public override void Exit ()
	{
		
	}

	public override void Update ()
	{
		m_Timer += Time.deltaTime;
		if (m_Timer >= 1.5f) {
			if(SM.m_Pieza1.GetComponentsInChildren<MeshRenderer> () [1].material.name == SM.m_Pieza2.GetComponentsInChildren<MeshRenderer> () [1].material.name)
			{
				DoTransition(typeof(State_CorrectTokens));
			}
			else
			{
				DoTransition(typeof(State_FailTokens));
			}
		}	
	}
}
