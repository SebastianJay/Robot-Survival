using UnityEngine;
using System.Collections;

/**
	Manages whether buttons should be active or not based on Model's resource counts
 */
public class ButtonActiveManager : MonoBehaviour {

	//A list of all the buttons
	public UnityEngine.UI.Button collectUp1;
	public UnityEngine.UI.Button collectDown1;
	public UnityEngine.UI.Button collectUp2;
	public UnityEngine.UI.Button collectDown2;
	public UnityEngine.UI.Button collectUp3;
	public UnityEngine.UI.Button collectDown3;

	public UnityEngine.UI.Button fortifyUp1;
	public UnityEngine.UI.Button fortifyDown1;
	public UnityEngine.UI.Button fortifyUp2;
	public UnityEngine.UI.Button fortifyDown2;

	public UnityEngine.UI.Button expandUp1;
	public UnityEngine.UI.Button expandDown1;

	public UnityEngine.UI.Toggle improveUpkeep;
	public UnityEngine.UI.Toggle improveCollection;
	public UnityEngine.UI.Toggle improveExpansion;
	public UnityEngine.UI.Toggle convert12;
	public UnityEngine.UI.Toggle convert23;
	
	public void UpdateButtons(Model currentInfo, Model mutatedInfo) {
		//set buttons enabled/disabled based on resource counts
		improveUpkeep.interactable = (currentInfo.robots1 >= 100 && currentInfo.components >= 50 && currentInfo.oil >= 25) || improveUpkeep.isOn;
		improveCollection.interactable = (currentInfo.robots1 >= 100 && currentInfo.components >= 30) || improveCollection.isOn;
		improveExpansion.interactable = (currentInfo.robots1 >= 100 && currentInfo.components >= 20) || improveExpansion.isOn;
		convert12.interactable = (currentInfo.robots1 >= 100 && currentInfo.metal >= 20) || convert12.isOn;
		convert23.interactable = (currentInfo.robots2 >= 100 && currentInfo.metal >= 30) || convert23.isOn;
		/*
		improveUpkeep.isOn = false;
		improveCollection.isOn = false;
		improveExpansion.isOn = false;
		convert12.isOn = false;
		convert23.isOn = false;
		*/
		collectUp1.interactable = currentInfo.robots1 >= 50;
//		collectDown1.interactable = 
		collectUp2.interactable = currentInfo.robots2 >= 50;
		collectUp3.interactable = currentInfo.robots3 >= 50;
		fortifyUp1.interactable = currentInfo.robots1 >= 50;
		fortifyUp2.interactable = currentInfo.robots2 >= 50;
		expandUp1.interactable = currentInfo.robots1 >= 50;
	}

	private Model info;
	// Use this for initialization
	void Start () {
		info = GetComponent<Model> ();
		UpdateButtons (info, info);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
