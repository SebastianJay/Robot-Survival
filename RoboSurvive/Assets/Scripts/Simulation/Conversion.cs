using UnityEngine;
using System.Collections;

public class Conversion : SimScript {

	public float OneToTwoRate;
	public float TwoToThreeRate;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void RunSimulation(Transform preTurn, Transform afterTurn, Transform result) {
		int Mk1Used = afterTurn.GetComponent<RobotModel> ().OneToTwo;
		int MK2Created = Mk1Used * OneToTwoRate;

		int Mk2Used = afterTurn.GetComponent<RobotModel> ().TwoToThree;
		int Mk3Created = Mk2Used * TwoToThreeRate;

		RobotModel rM = result.GetComponent<RobotModel> ();
		rM.SetMarkOne (rM.GetMarkOne () - Mk1Used);
		rM.SetMarkTwo ((rM.GetMarkTwo () - Mk2Used) + MK2Created);
		rM.SetMarkThree (rM.GetMarkThree () + Mk3Created);
	}
}
