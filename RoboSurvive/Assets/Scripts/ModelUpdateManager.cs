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
	public void Convert12()
	{
		
	}
	public void Convert23()
	{

	}

	public void ImproveUpkeep()
	{
		//update labels
		currentState.GetComponent<LabelManager> ().UpdateText ();
		//update active/inactive of buttons
		currentState.GetComponent<ButtonActiveManager> ().UpdateButtons ();
	}

	public void ImproveCollection()
	{
	}

	public void ImproveExpansion()
	{
	}


	/*
	 * x = 
	 * 1st bit 0 -1
	 * 1st bit 1 +1
	 * 2,3rd bits M type
	 */
	public void ShiftCollect(int x)
	{
		//(optional) validate whether we have enough resources for this transaction

		int sign;
		if (x % 2 == 0)
			sign = -1;
		else
			sign = 1;
		int type = x >> 1;
		Debug.Log (sign + " " + type);
		//update the state
				
		//update labels
		currentState.GetComponent<LabelManager> ().UpdateText ();
		//update active/inactive of buttons
		currentState.GetComponent<ButtonActiveManager> ().UpdateButtons ();
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
