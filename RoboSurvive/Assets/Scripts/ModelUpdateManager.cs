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
	}
	public void ShiftExpand(int x)
	{
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
