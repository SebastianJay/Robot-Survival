using UnityEngine;
using System.Collections.Generic;

public class Fortify : SimScript {

	public int oilCost, metalCost, ComponentsCost;
	public float mk1Rate, mk2Rate, mk3Rate;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public override void RunSimulation(Transform preTurn, Transform afterTurn, Transform result) {
		Task[] tasks = afterTurn.GetComponents<Task> ();
		List<Task> forts = new List<Task>();
		foreach (Task task in tasks) {
			if (task.type == "fortify") {
				forts.Add(task);
			}
		}

		foreach (Task fort in forts) {
			MetaModel mM = result.GetComponent<MetaModel>();
			float toFort = fort.mk1 * mk1Rate + fort.mk2 * mk2Rate + fort.mk3 * mk3Rate;
			mM.fortification = Mathf.Min(mM.fortification + toFort, 1.0f);

			RobotModel rM = result.GetComponent<RobotModel>();
			rM.SetMarkOne(rM.GetMarkOne() - fort.mk1);
			rM.SetMarkTwo(rM.GetMarkTwo() - fort.mk2);
			rM.SetMarkThree(rM.GetMarkThree() - fort.mk3);

			ResourceModel resM = result.GetComponent<ResourceModel>();
			resM.SetOil(resM.GetOil() - oilCost);
			resM.SetMetal(resM.GetMetal() - metalCost);
			resM.SetComponents(resM.GetMetal() - metalCost);
		}
	}
}
