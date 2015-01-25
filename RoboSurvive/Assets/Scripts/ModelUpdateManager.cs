using UnityEngine;
using System.Collections;

/**
 * In charge of receiving input about tasks, factory, and development to execute
 * 
 */
public class ModelUpdateManager : MonoBehaviour {

	public static GameObject currentState;

	private Model info;

	//fixed cost stuff
	public void Convert12(bool b)
	{
		info.robots1 -= 100 * BoolToSign(b);
		info.metal -= 20 * BoolToSign(b);
		info.robots2 += 250 * BoolToSign(b);
		PostUpdate ();
	}
	public void Convert23(bool b)
	{
		info.robots1 -= 100 * BoolToSign(b);
		info.metal -= 30 * BoolToSign(b);
		info.robots2 += 250 * BoolToSign(b);
		PostUpdate ();
	}

	public void ImproveUpkeep(bool b)
	{
		info.robots1 -= 100 * BoolToSign(b);
		info.components -= 50 * BoolToSign(b);
		info.oil -= 25 * BoolToSign(b);
		info.improvedUpkeep += 1 * BoolToSign(b);
		PostUpdate ();
	}

	public void ImproveCollection(bool b)
	{
		info.robots1 -= 100 * BoolToSign(b);
		info.components -= 30 * BoolToSign(b);
		info.improvedCollect += 1 * BoolToSign(b);
		PostUpdate ();
	}

	public void ImproveExpansion(bool b)
	{
		info.robots1 -= 100 * BoolToSign(b);
		info.components -= 20 * BoolToSign(b);
		info.improvedExpand += 1 * BoolToSign(b);
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
				info.robots1 -= 50 * sign;
		else if (type == 2)
				info.robots2 -= 50 * sign;
		else
				info.robots3 -= 50 * sign;
			
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
			info.robots1 -= 50 * sign;
		else if (type == 2)
			info.robots2 -= 50 * sign;
		else
			info.robots3 -= 50 * sign;
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
			info.robots1 -= 50 * sign;
		else if (type == 2)
			info.robots2 -= 50 * sign;
		else
			info.robots3 -= 50 * sign;
		PostUpdate ();
	}

	private void PostUpdate()
	{
		//update labels
		currentState.GetComponent<LabelManager> ().UpdateText ();
		//update active/inactive of buttons
		currentState.GetComponent<ButtonActiveManager> ().UpdateButtons ();
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
		currentState = GameObject.FindGameObjectWithTag ("Model");
		info = currentState.GetComponent<Model> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
