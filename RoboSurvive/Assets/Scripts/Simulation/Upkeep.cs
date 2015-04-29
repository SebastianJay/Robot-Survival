using UnityEngine;
using System.Collections;

public class Upkeep : SimScript {

	public float oilUsedMk1;
	public float oilUsedMk2;
	public float oilUsedMk3;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void RunSimulation(Transform preTurn, Transform afterTurn, Transform result) {
		int totMk1 = afterTurn.GetComponent<RobotModel> ().GetMarkOne ();
		int totMk2 = afterTurn.GetComponent<RobotModel> ().GetMarkTwo ();
		int totMk3 = afterTurn.GetComponent<RobotModel> ().GetMarkThree ();

		int oldOil = afterTurn.GetComponent<ResourceModel> ().GetOil ();
		int newOil = oldOil - (oilUsedMk1 * totMk1 + oilUsedMk2 * totMk2 + oilUsedMk3 * totMk3);

		result.GetComponent<ResourceModel> ().SetOil (newOil);
	}
}
