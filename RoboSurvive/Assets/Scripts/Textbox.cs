using UnityEngine;
using System.Collections;

public class Textbox : MonoBehaviour {
	
	private Rect windowRect = new Rect(20, 200, 200, 200);

	private string factoryString = "This is the factory tab. Change robots between Mk I, Mk II, and Mk III";
	private string tasksString = "In this tab, you assign robots to various tasks necessary for survival and expansion";
	private string developmentsString = "In this tab, you will manage the development of your various systems";
	private string resourceString = "These are your resources: Oil does this. Components do this. Metal does this";
	private string robotString = "There are three types of robots. Mk I robots are good at this. Mk II are good at this." +
		"Mk III are good at this.";
	private string executeString = "Click this button to end the simulation";
	public string playString = "You're all set! Click play to start the game!";

	public string currentMenu = "";

	public Texture background;
	public GUIStyle myStyle;
	public GUIContent title;
	
	void Start () {
		currentMenu = "window1";
	}
	void NavigateTo(string nextmenu) {
		currentMenu = nextmenu;
	}
	void OnGUI() {
		Color colGui = GUI.color;
		colGui.a = 1f;
		GUI.color = colGui;

		//GUI.backgroundColor = Color.black;
		if (currentMenu == "window1") 
			Factory();
		if (currentMenu == "window2") 
			Tasks();
		if (currentMenu == "window3") 
			Developments ();
		if (currentMenu == "window4")
			Resources ();
		if (currentMenu == "window5")
			Robots ();
		if (currentMenu == "window6")
			Execute ();
		if (currentMenu == "window7")
			Play ();

	}

	void Factory() {
		if (GUI.Button (new Rect (140, 250, 55, 25), "Next")) {
			NavigateTo ("window2");
		}
		if (GUI.Button (new Rect (200, 250, 65, 25), "Previous")) {
		}
		GUI.Window (0, new Rect (100, 100, 200, 200), WindowFunction, "Factory");
	}

	void Tasks() {
		if (GUI.Button (new Rect (440, 550, 55, 25), "Next")) {
			NavigateTo("window3");
		}
		if (GUI.Button (new Rect (500, 550, 65, 25), "Previous")) {
			NavigateTo("window1");
		}
		GUI.Window (0, new Rect (400, 400, 200, 200), WindowFunction, "Tasks");
	}

	void Developments() {
		if (GUI.Button (new Rect (240, 350, 55, 25), "Next")) {
			NavigateTo("window4");
		}
		if (GUI.Button (new Rect (300, 350, 65, 25), "Previous")) {
			NavigateTo("window2");
		}
		GUI.Window (0, new Rect (200, 200, 200, 200), WindowFunction, "Developments");
	}

	void Resources() {

		if (GUI.Button (new Rect (540, 350, 55, 25), "Next")) {
			NavigateTo("window5");
		}
		if (GUI.Button (new Rect (600, 350, 65, 25), "Previous")) {
			NavigateTo("window3");
		}
		GUI.Window (0, new Rect (500, 200, 200, 200), WindowFunction, "Resources");
	}

	void Robots() {
		if (GUI.Button (new Rect (540, 350, 55, 25), "Next")) {
			NavigateTo("window6");
		}
		if (GUI.Button (new Rect (600, 350, 65, 25), "Previous")) {
			NavigateTo("window4");
		}
		GUI.Window (0, new Rect (500, 200, 200, 200), WindowFunction, "Robots");
	}
	void Execute() {
		if (GUI.Button (new Rect (540, 350, 55, 25), "Next")) {
			NavigateTo("window7");
		}
		if (GUI.Button (new Rect (600, 350, 65, 25), "Previous")) {
			NavigateTo("window5");
		}
		GUI.Window (0, new Rect (500, 200, 200, 200), WindowFunction, "Execute");
	}
	void Play() {
		if (GUI.Button (new Rect (540, 350, 75, 25), "Play Now")) {
			enabled = false;
		}
		GUI.Window (0, new Rect (500, 200, 200, 200), WindowFunction, "Time to Play!");
	}

	void WindowFunction(int windowID) {
		if (currentMenu == "window1") {
			GUI.Label (new Rect(10,20,180,180), factoryString);
		}
		if (currentMenu == "window2") {
			GUI.Label (new Rect(10,20,180,180),tasksString);
		}
		if (currentMenu == "window3") {
			GUI.Label (new Rect(10,20,180,180),developmentsString);
		}
		if (currentMenu == "window4") {
			GUI.Label (new Rect(10,20,180,180),resourceString);
		}
		if (currentMenu == "window5") {
			GUI.Label (new Rect (10, 20, 180, 180), robotString);
		}
		if (currentMenu == "window6") {
			GUI.Label (new Rect (10,20,180,180),executeString);
		}
		if (currentMenu == "window7") {
			GUI.Label (new Rect (10, 20, 180, 180), playString);
		}
	}
	
	void Update () {
	}
}
