using UnityEngine;
using System.Collections;

// Tests the simulation. Will step the simulation on click.
public class TestRunSimulation : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        // Runs the simulation on mouse click.
        if (Input.GetMouseButtonDown(0))
        {
            this.GetComponent<RunSimulation>().Run();
        }
	}
}
