using UnityEngine;
using System.Collections;

public class LabelManager : MonoBehaviour {

	//a big list of text labels to be assigned within the editor

	//Resource labels
	public UnityEngine.UI.Text oil;
	public UnityEngine.UI.Text metal;
	public UnityEngine.UI.Text components;

	//robot
	public UnityEngine.UI.Text robo1;
	public UnityEngine.UI.Text robo2;
	public UnityEngine.UI.Text robo3;

	//development
	public UnityEngine.UI.Text power;
	public UnityEngine.UI.Text weapon;
	public UnityEngine.UI.Text defense;
	
	private Model info;
	public void UpdateText()
	{
		oil.text = ""+info.oil;
		metal.text = ""+info.metal;
		components.text = ""+info.components;

		robo1.text = ""+info.robots1;
		robo2.text = ""+info.robots2;
		robo3.text = ""+info.robots3;

		//we can have mappings to words here
		power.text = ""+info.improvedCollect;
		weapon.text = ""+info.improvedExpand;
		defense.text = ""+info.improvedUpkeep;
	}

	// Use this for initialization
	void Start () {	
		info = GetComponent<Model> ();
	}

	
	// Update is called once per frame
	void Update () {
	}
}
