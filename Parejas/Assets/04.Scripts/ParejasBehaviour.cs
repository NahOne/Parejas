using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ParejasBehaviour : MonoBehaviour {
    private ParejasBehaviourStateMachine m_ParejasSM = null;

	public Text texto;
	public GameObject[] piezas; 
	public Material[] materials;


    // Use this for initialization
    void Start () {
        // create the state machine and start it
		m_ParejasSM = new ParejasBehaviourStateMachine(this.gameObject);
        m_ParejasSM.StartSM();
    }
	
	// Update is called once per frame
	void Update () {
        // update the state machine very frame
        if (m_ParejasSM != null)
        {
            m_ParejasSM.UpdateSM();
        }

        // this is how you can print the current active state tree to the log for debugging
        if (Input.GetKeyDown(KeyCode.Space))
        {
            m_ParejasSM.PrintActiveStateTree();
        }
    }
}
