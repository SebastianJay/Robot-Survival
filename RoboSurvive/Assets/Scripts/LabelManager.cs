using UnityEngine;
using System.Collections;

public class LabelManager : MonoBehaviour {

	//a big list of text labels to be assigned within the editor

	//Resource labels
	public UnityEngine.UI.Text oil;
	public UnityEngine.UI.Text metal;
	public UnityEngine.UI.Text components;
	public UnityEngine.UI.Text dOil;
	public UnityEngine.UI.Text dMetal;
	public UnityEngine.UI.Text dComponents;

	//robot
	public UnityEngine.UI.Text robo1;
	public UnityEngine.UI.Text robo2;
	public UnityEngine.UI.Text robo3;
	public UnityEngine.UI.Text dRobo1;
	public UnityEngine.UI.Text dRobo2;
	public UnityEngine.UI.Text dRobo3;

	//development
	public UnityEngine.UI.Text collect;
	public UnityEngine.UI.Text expand;
	public UnityEngine.UI.Text upkeep;
	public UnityEngine.UI.Text dCollect;
	public UnityEngine.UI.Text dExpand;
	public UnityEngine.UI.Text dUpkeep;

	private Model info;
	public void UpdateText(Model currentModel, Model futureModel)
	{
		oil.text = ""+currentModel.oil;
		metal.text = ""+currentModel.metal;
		components.text = ""+currentModel.components;
		dOil.text = "("+futureModel.oil+")";
		dMetal.text = "("+futureModel.metal+")";
		dComponents.text = "("+futureModel.components+")";

		robo1.text = ""+currentModel.robots1;
		robo2.text = ""+currentModel.robots2;
		robo3.text = ""+currentModel.robots3;
		dRobo1.text = "("+futureModel.robots1+")";
		dRobo2.text = "("+futureModel.robots2+")";
		dRobo3.text = "("+futureModel.robots3+")";

		//we can have mappings to words here
		collect.text = ""+currentModel.improvedCollect;
		expand.text = ""+currentModel.improvedExpand;
		upkeep.text = ""+currentModel.improvedUpkeep;
		dCollect.text = "("+futureModel.improvedCollect+")";
		dExpand.text = "("+futureModel.improvedExpand+")";
		dUpkeep.text = "("+futureModel.improvedUpkeep+")";
	}

	// Use this for initialization
	void Start () {	
		info = GetComponent<Model> ();
		UpdateText (info, info);
	}

	
	// Update is called once per frame
	void Update () {
	}
}
