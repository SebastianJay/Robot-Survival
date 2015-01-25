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
	
	public void UpdateButtons() {
		//set buttons enabled/disabled based on resource counts
		improveUpkeep.interactable = info.robots1 >= 100 && info.components >= 50 && info.oil >= 25;
		improveCollection.interactable = info.robots1 >= 100 && info.components >= 30;
		improveExpansion.interactable = info.robots1 >= 100 && info.components >= 20;
		convert12.interactable = info.robots1 >= 100 && info.metal >= 20;
		convert23.interactable = info.robots2 >= 100 && info.metal >= 30;
		improveUpkeep.isOn = false;
		improveCollection.isOn = false;
		improveExpansion.isOn = false;
		convert12.isOn = false;
		convert23.isOn = false;

		collectUp1.interactable = info.robots1 >= 50;
		collectUp2.interactable = info.robots2 >= 50;
		collectUp3.interactable = info.robots3 >= 50;
		fortifyUp1.interactable = info.robots1 >= 50;
		fortifyUp2.interactable = info.robots2 >= 50;
		expandUp1.interactable = info.robots1 >= 50;
	}

	private Model info;
	// Use this for initialization
	void Start () {
		info = GetComponent<Model> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
