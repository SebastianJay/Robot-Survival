using UnityEngine;
using System.Collections;

/**
	Manages whether buttons should be active or not based on Model's resource counts
 */
public class ButtonActiveManager : MonoBehaviour {
	
	//A list of all the buttons
	UnityEngine.UI.Button collectUp;
	UnityEngine.UI.Button collectDown;

	UnityEngine.UI.Button expandUp;
	UnityEngine.UI.Button expandDown;
	

	public void UpdateButtons() {
		//set buttons enabled/disabled based on resource counts
		collectUp.interactable = info.oil > 9000;
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
