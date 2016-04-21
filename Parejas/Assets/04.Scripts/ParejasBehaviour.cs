using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ParejasBehaviour : MonoBehaviour {
    private ParejasBehaviourStateMachine m_ParejasSM = null;

	public Text texto;
	public GameObject[] piezas; 
	public Material[] materials;
    public GameObject player;
	public int m_Correctas;
	public Text m_CorrectasText;
	public Text m_TimerText;

	[HideInInspector]
	public float m_Time;
    [HideInInspector]
    public bool m_StartTimer;

	private GameObject m_EverLoopController;

    // Use this for initialization
    void Start () {
        // create the state machine and start it
		m_ParejasSM = new ParejasBehaviourStateMachine(this.gameObject);
        m_ParejasSM.StartSM();
		m_Time = 0;
        m_StartTimer = false;
        m_TimerText.text = "00:00";

		m_EverLoopController = GameObject.Find ("EverloopController");
		m_EverLoopController.GetComponent<EverloopController> ().StopAll ();
		m_EverLoopController.GetComponent<EverloopController> ().FadeInLayer (m_EverLoopController.GetComponents<AudioSource> () [0], 0);
    }
	
	// Update is called once per frame
	void Update () {
        if (m_StartTimer)
        {
            m_Time += Time.deltaTime;

            float minutes = Mathf.Floor(m_Time / 60); 
		    float seconds = Mathf.RoundToInt(m_Time%60);

		    m_TimerText.text =  (minutes < 10.0f ? ("0" + minutes.ToString()) : minutes.ToString()) 
                + ":" + (seconds < 10.0f ? ("0" + seconds.ToString()) : seconds.ToString());
        }
        
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
