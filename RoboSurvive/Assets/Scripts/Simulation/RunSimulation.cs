using UnityEngine;
using System.Collections;

// The main class of the simulation.
public class RunSimulation : MonoBehaviour {

	// Use this for initialization
    void Start()
    {
        // Copies preturn model for afterturn
        Transform preTurn = transform.Find("PreTurn");
        Transform afterTurn = (Transform)Instantiate(preTurn);
        afterTurn.parent = transform;
        afterTurn.name = "AfterTurn";
        afterTurn.tag = "AfterTurn";
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    // Called on the Execute step of the simulation
    public void Run()
    {
        // Fetches two model types
        Transform preTurn = transform.Find("PreTurn");
        Transform afterTurn = transform.Find("AfterTurn");
        
        // Creates a result object
        Transform result = (Transform) Instantiate(afterTurn);
        result.parent = transform;
        
        // Iterates over each script in the simulation
        foreach (SimScript script in this.GetComponents<SimScript>())
        {
            script.RunSimulation(preTurn, afterTurn, result);
        }

        // Destroys old models
        Destroy(preTurn.gameObject);
        Destroy(afterTurn.gameObject);

        // Sets result to be new preturn
        preTurn = result;
        preTurn.name = "PreTurn";
        preTurn.tag = "PreTurn";

        // Copies preturn model for afterturn
        afterTurn = (Transform)Instantiate(preTurn);
        afterTurn.parent = transform;
        afterTurn.name = "AfterTurn";
        afterTurn.tag = "AfterTurn";
    }
}
