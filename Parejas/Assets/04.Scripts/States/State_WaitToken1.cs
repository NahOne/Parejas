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
		SM.m_EverLoopController.GetComponent<AudioSource> ().PlayOneShot(SM.m_ssb.m_TokenSelected);
	}
	
	public override void Update ()
	{
        Debug.DrawRay(SM.m_ssb.player.gameObject.transform.position, SM.m_ssb.player.gameObject.transform.forward);
        if (Input.GetKeyDown(KeyCode.S))
		{
            RaycastHit hit;

            if (Physics.Raycast(SM.m_ssb.player.gameObject.transform.position, SM.m_ssb.player.gameObject.transform.forward, out hit))
            {
                if (hit.transform.gameObject.name.Equals("Cube"))
                {
					SM.m_Pieza1 = hit.collider.gameObject;
                    hit.transform.gameObject.GetComponentInParent<Animator>().SetInteger("girar", 1);
                    DoTransition(typeof(State_WaitToken2));
                }
            }
        }
	}
}
