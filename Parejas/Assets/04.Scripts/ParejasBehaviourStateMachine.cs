using UnityEngine;
using System.Collections.Generic;
using FSMHelper;

public class ParejasBehaviourStateMachine : FSMStateMachine {
    public GameObject m_GameObject = null;

    public ParejasBehaviourStateMachine(GameObject characterObj)
    {
        m_GameObject = characterObj;
    }

    // here we define the structure of the state machine's first layer
    public override void SetupDefinition(ref FSMStateType stateType, ref List<System.Type> children)
    {
        // default is an ORtype state
        // the first child added will be the inital state
        children.Add(typeof(State_AssignAndShow));
        children.Add(typeof(State_CheckTokens));
        children.Add(typeof(State_ClueLife));
        children.Add(typeof(State_CorrectTokens));
        children.Add(typeof(State_FailTokens));
        children.Add(typeof(State_GameFinished));
        children.Add(typeof(State_WaitToken1));
        children.Add(typeof(State_WaitToken2));
        children.Add(typeof(State_WaitToPlay));
    }
}
