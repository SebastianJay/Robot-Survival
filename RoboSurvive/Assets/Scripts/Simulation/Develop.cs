using UnityEngine;
using System.Collections.Generic;

public class Develop : SimScript {

	public int oilCost, metalCost, ComponentsCost;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public override void RunSimulation(Transform preTurn, Transform afterTurn, Transform result) {
		Task[] tasks = afterTurn.GetComponents<Task> ();
		List<Task> devs = new List<Task>();
		foreach (Task task in tasks) {
			if (task.type == "develop") {
				devs.Add(task);
			}
		}
		
		foreach (Task dev in devs) {			
			RobotModel rM = result.GetComponent<RobotModel>();
			rM.SetMarkOne(rM.GetMarkOne() - dev.mk1);
			rM.SetMarkTwo(rM.GetMarkTwo() - dev.mk2);
			rM.SetMarkThree(rM.GetMarkThree() - dev.mk3);
			
			ResourceModel resM = result.GetComponent<ResourceModel>();
			resM.SetOil(resM.GetOil() - oilCost);
			resM.SetMetal(resM.GetMetal() - metalCost);
			resM.SetComponents(resM.GetMetal() - metalCost);

			result.GetComponent<DevelopmentsModel>().Develop(dev.name);
		}
	}
}
