using UnityEngine;
using System.Collections;
using FSMHelper;
using UnityEngine.SceneManagement;

public class State_GameFinished : BaseFSMState {
	ParejasBehaviourStateMachine SM;

	public override void Enter ()
	{
		SM = (ParejasBehaviourStateMachine)GetStateMachine();
		SceneManager.LoadScene (0);
	}
	
	public override void Exit ()
	{
		
	}
	
	public override void Update ()
	{
		
	}
}
