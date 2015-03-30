using UnityEngine;
using System.Collections;

public class TestSimScript : SimScript {

	// Use this for initialization
    void Start()
    {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public override void RunSimulation(Transform preTurn, Transform afterTurn, Transform result)
    {

        result.GetComponent<DumbData>().count = afterTurn.GetComponent<DumbData>().count+1;
    }
}
