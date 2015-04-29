using UnityEngine;
using System.Collections;

public class Collections : SimScript {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    private void Collect(Task t, Transform result)
    {

    }

    public override void RunSimulation(Transform preTurn, Transform afterTurn, Transform result)
    {
        foreach (Task t in afterTurn.GetComponents<Task>())
        {
            if (t.type.Equals("collect"))
            {
                Collect(t, result);
            }
        }
    }
}
