﻿using UnityEngine;
using System.Collections;
using FSMHelper;

public class State_ClueLife : BaseFSMState {
	ParejasBehaviourStateMachine SM;

	public override void Enter ()
	{
		SM = (ParejasBehaviourStateMachine)GetStateMachine();
	}
	
	public override void Exit ()
	{
		
	}
	
	public override void Update ()
	{
		
	}
}
