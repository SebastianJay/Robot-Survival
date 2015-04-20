using UnityEngine;
using System.Collections;

// Base class for all scripts which run during the Execute phase of gameplay.
public abstract class SimScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    // Called once per Execute step. Subclasses should put their update logic here.
    public abstract void RunSimulation(Transform preTurn, Transform afterTurn, Transform result);
}
