using UnityEngine;
using System.Collections;

/**
 * In charge of receiving input about tasks, factory, and development to execute
 * 
 */
public class ModelUpdateManager : MonoBehaviour {

	public static GameObject currentState;

	public void ShiftConvert12(int x)
	{
	}
	public void ShiftConvert23(int x)
	{
	}

	public void ShiftCollect(int x)
	{
		//(optional) validate whether we have enough resources for this transaction

		//update the state

		//update labels
		currentState.GetComponent<LabelManager> ().UpdateText ();
		//update active/inactive of buttons
		currentState.GetComponent<ButtonActiveManager> ().UpdateButtons ();
	}
	public void ShiftExpand(int x)
	{
	}
	public void ShiftImprove(int x)
	{
	}

	public void ExecuteSimulation()
	{
		//mirror for controller's Run()
	}

	//methods for special tasks

	// Use this for initialization
	void Start () {
		currentState = GameObject.FindGameObjectWithTag ("Model");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
