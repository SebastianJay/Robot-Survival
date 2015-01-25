using UnityEngine;
using System.Collections;

/**
 * In charge of receiving input about tasks, factory, and development to execute
 * 
 */
public class ModelUpdateManager : MonoBehaviour {

	public static GameObject modelObj;

	public Model currentInfo;
	public Model mutatedInfo;

	//fixed cost stuff
	public void Convert12(bool b)
	{
		mutatedInfo.robots1 -= 100 * BoolToSign(b);
		mutatedInfo.metal -= 20 * BoolToSign(b);
		mutatedInfo.robots2 += 250 * BoolToSign(b);
		mutatedInfo.electricity -= 100 * BoolToSign(b);
		PostUpdate ();
	}
	public void Convert23(bool b)
	{
		mutatedInfo.robots2 -= 100 * BoolToSign(b);
		mutatedInfo.metal -= 30 * BoolToSign(b);
		mutatedInfo.robots3 += 250 * BoolToSign(b);
		mutatedInfo.electricity -= 100 * BoolToSign(b);
		PostUpdate ();
	}

	public void ImproveUpkeep(bool b)
	{
		mutatedInfo.robots1 -= 100 * BoolToSign(b);
		mutatedInfo.components -= 50 * BoolToSign(b);
		mutatedInfo.oil -= 25 * BoolToSign(b);
		mutatedInfo.improvedUpkeep += 1 * BoolToSign(b);
		mutatedInfo.electricity -= 100 * BoolToSign(b);
		PostUpdate ();
	}

	public void ImproveCollection(bool b)
	{
		mutatedInfo.robots1 -= 100 * BoolToSign(b);
		mutatedInfo.components -= 30 * BoolToSign(b);
		mutatedInfo.improvedCollect += 1 * BoolToSign(b);
		mutatedInfo.electricity -= 100 * BoolToSign(b);
		PostUpdate ();
	}

	public void ImproveExpansion(bool b)
	{
		mutatedInfo.robots1 -= 100 * BoolToSign(b);
		mutatedInfo.components -= 20 * BoolToSign(b);
		mutatedInfo.improvedExpand += 1 * BoolToSign(b);
		mutatedInfo.electricity -= 100 * BoolToSign(b);
		PostUpdate ();
	}


	/*
	 * x = 
	 * 1st bit 0 -1
	 * 1st bit 1 +1
	 * 2,3rd bits M type
	 */
	public void ShiftCollect(int x)
	{
		//validate whether we have enough resources for this transaction

		int sign;
		if (x % 2 == 0)
			sign = -1;
		else
			sign = 1;
		int type = x >> 1;
		Debug.Log (sign + " " + type);

		//update the state
		if (type == 1)
		{
			mutatedInfo.robots1 -= 50 * sign;
			mutatedInfo.robots1Collect += 50 * sign;
			mutatedInfo.electricity -= 50 * sign;

		}
		else if (type == 2)
		{
			mutatedInfo.robots2 -= 50 * sign;
			mutatedInfo.robots2Collect += 50 * sign;
			mutatedInfo.electricity -= 50 * sign;
		}
		else
		{
			mutatedInfo.robots3 -= 50 * sign;
			mutatedInfo.robots3Collect += 50 * sign;
			mutatedInfo.electricity -= 50 * sign;
		}
			
		PostUpdate();
	}

	//
	public void ShiftExpand(int x)
	{
		int sign;
		if (x % 2 == 0)
			sign = -1;
		else
			sign = 1;
		int type = x >> 1;
		Debug.Log (sign + " " + type);

		if (type == 1)
		{
			mutatedInfo.robots1 -= 50 * sign;
			mutatedInfo.robots1Expand += 50 * sign;
			mutatedInfo.electricity -= 50 * sign;

		}
		PostUpdate ();
	}

	//
	public void ShiftFortify(int x)
	{
		int sign;
		if (x % 2 == 0)
			sign = -1;
		else
			sign = 1;
		int type = x >> 1;
		Debug.Log (sign + " " + type);

		if (type == 1)
		{
			mutatedInfo.robots1 -= 50 * sign;
			mutatedInfo.robots1Fortify += 50 * sign;
			mutatedInfo.electricity -= 50 * sign;

		}
		else if (type == 2)
		{
			mutatedInfo.robots2 -= 50 * sign;
			mutatedInfo.robots2Fortify += 50 * sign;
			mutatedInfo.electricity -= 50 * sign;

		}
		PostUpdate ();
	}

	private void PostUpdate()
	{
		//update labels
		modelObj.GetComponent<LabelManager> ().UpdateText (currentInfo, mutatedInfo);
		//update active/inactive of buttons
		modelObj.GetComponent<ButtonActiveManager> ().UpdateButtons (currentInfo, mutatedInfo);
	}

	private int BoolToSign(bool b)
	{
		return b ? 1 : -1;
	}

	public void ExecuteSimulation()
	{
		//mirror for controller's Run()
	}

	//methods for special tasks

	// Use this for initialization
	void Start () {
		modelObj = GameObject.FindGameObjectWithTag ("Model");
		currentInfo = modelObj.GetComponent<Model> ();
		mutatedInfo = currentInfo.clone ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
