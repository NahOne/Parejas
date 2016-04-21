using UnityEngine;
using System.Collections.Generic;
using FSMHelper;
using UnityEngine.UI;

public class ParejasBehaviourStateMachine : FSMStateMachine {
    public GameObject m_GameObject = null;
	public ParejasBehaviour m_ssb = null;
	public GameObject m_Pieza1;
	public GameObject m_Pieza2;
	public int m_Correctas;

	public GameObject m_EverLoopController;

    public ParejasBehaviourStateMachine(GameObject characterObj)
    {
        m_GameObject = characterObj;
		m_ssb = m_GameObject.GetComponent<ParejasBehaviour>();
		m_EverLoopController = GameObject.Find ("EverloopController");
    }

    // here we define the structure of the state machine's first layer
    public override void SetupDefinition(ref FSMStateType stateType, ref List<System.Type> children)
    {
        // default is an ORtype state
        // the first child added will be the inital state
		children.Add(typeof(State_WaitToPlay));
        children.Add(typeof(State_AssignAndShow));
        children.Add(typeof(State_CheckTokens));
        children.Add(typeof(State_ClueLife));
        children.Add(typeof(State_CorrectTokens));
        children.Add(typeof(State_FailTokens));
        children.Add(typeof(State_GameFinished));
        children.Add(typeof(State_WaitToken1));
        children.Add(typeof(State_WaitToken2));    
    }
}
