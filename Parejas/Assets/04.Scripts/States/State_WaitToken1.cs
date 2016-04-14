using UnityEngine;
using System.Collections;
using FSMHelper;

public class State_WaitToken1 : BaseFSMState {
	ParejasBehaviourStateMachine SM;

	public override void Enter ()
	{
		SM = (ParejasBehaviourStateMachine)GetStateMachine();
		SM.m_ssb.texto.text = "Press S to select First Token";
	}
	
	public override void Exit ()
	{
		
	}
	
	public override void Update ()
	{
		if (Input.GetKeyDown(KeyCode.S)
	}
}
