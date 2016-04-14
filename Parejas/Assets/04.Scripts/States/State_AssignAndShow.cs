using UnityEngine;
using System.Collections;
using FSMHelper;
using System.Collections.Generic;

public class State_AssignAndShow : BaseFSMState {
	ParejasBehaviourStateMachine SM;
	float timer;
	GameObject[] quads;
	List<int> materialIndex = new List<int>();

	public override void Enter ()
	{
		int indexMaterial;
		int sizeList = 12;
		materialIndex.Add (0);
		materialIndex.Add (1);
		materialIndex.Add (2);
		materialIndex.Add (3);
		materialIndex.Add (4);
		materialIndex.Add (5);
		materialIndex.Add (0);
		materialIndex.Add (1);
		materialIndex.Add (2);
		materialIndex.Add (3);
		materialIndex.Add (4);
		materialIndex.Add (5);

		SM = (ParejasBehaviourStateMachine)GetStateMachine();
		SM.m_ssb.texto.text = "Press S to select First Token";
		timer = 0;
		//materialIndex = new int[] {0,1,2,3,4,5,0,1,2,3,4,5};
		quads = GameObject.FindGameObjectsWithTag ("Quad");
		for (int i = 0; i<quads.Length; ++i)
		{
			indexMaterial = Random.Range(0, sizeList);
			quads[i].GetComponent<MeshRenderer>().material = SM.m_ssb.materials[materialIndex[indexMaterial]];
			materialIndex.RemoveAt(indexMaterial);
			sizeList--;
		}
	}
	
	public override void Exit ()
	{
		
	}
	
	public override void Update ()
	{
		timer += Time.deltaTime;
		if(timer>=5)
		{
			// volver a rotar
		}

		if(timer >= 7)
		{
			DoTransition(typeof(State_WaitToken1));
		}
	}
}
