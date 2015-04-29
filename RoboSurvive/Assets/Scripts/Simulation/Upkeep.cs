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
	
	public override void RunSimulation(Transform preTurn, Transform afterTurn, Transform result) {
		RobotModel rM = afterTurn.GetComponent<RobotModel> ();
		int totMk1 = rM.GetMarkOne ();
		int totMk2 = rM.GetMarkTwo ();
		int totMk3 = rM.GetMarkThree ();
		
		int oldOil = afterTurn.GetComponent<ResourceModel> ().GetOil ();
		int newOil = oldOil - (int)(oilUsedMk1 * totMk1 + oilUsedMk2 * totMk2 + oilUsedMk3 * totMk3);
		
		result.GetComponent<ResourceModel> ().SetOil (newOil);
	}
}