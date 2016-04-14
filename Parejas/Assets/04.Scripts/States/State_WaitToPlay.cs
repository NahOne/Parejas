using UnityEngine;
using System.Collections;
using FSMHelper;


public class State_WaitToPlay : BaseFSMState {
	ParejasBehaviourStateMachine SM;
	float timer;
	public override void Enter ()
	{
		SM = (ParejasBehaviourStateMachine)GetStateMachine();
		timer = 3;
		SM.m_ssb.texto.text = "Game in " + System.Math.Round(timer,2) + " seconds...";
	}
	
	public override void Exit ()
	{
		
	}
	
	public override void Update ()
	{
		timer -= Time.deltaTime;
		SM.m_ssb.texto.text = "Game in " + System.Math.Round(timer) + " seconds...";
		if (timer <= 0) 
		{
			DoTransition(typeof(State_AssignAndShow));
		}
	}
}
