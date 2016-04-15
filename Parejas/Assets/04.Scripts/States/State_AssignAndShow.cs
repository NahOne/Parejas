using UnityEngine;
using System.Collections;
using FSMHelper;
using System.Collections.Generic;

public class State_AssignAndShow : BaseFSMState {
	ParejasBehaviourStateMachine SM;
	float timer;
	GameObject[] quads;
	List<int> materialIndex = new List<int>(new int[] {0,1,2,3,4,5,6,7,8,9,10,11,0,1,2,3,4,5,6,7,8,9,10,11});

	public override void Enter ()
	{
		int indexMaterial;
		int sizeList = 24;

		SM = (ParejasBehaviourStateMachine)GetStateMachine();
		SM.m_ssb.texto.text = "Memoriza!!";
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
		for (int j = 0; j<SM.m_ssb.piezas.Length; ++j)
		{
			SM.m_ssb.piezas[j].GetComponent<Animator>().SetInteger("girar", 1);
		}
	}
	
	public override void Exit ()
	{
		for (int k = 0; k<SM.m_ssb.piezas.Length; ++k)
		{
			SM.m_ssb.piezas[k].GetComponent<Animator>().SetInteger("girar", -1);
		}
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
