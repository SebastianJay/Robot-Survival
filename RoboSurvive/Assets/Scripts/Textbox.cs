using UnityEngine;
using System.Collections;

public class Textbox : MonoBehaviour {
	
	public NavBarManager manager;

	//window0
	//Skip tutorial button
	public Rect startUpRect = new Rect (335,230,200,200);
	public string startUpString = "This tutorial will guide you through the functions of your systems.";

	//window1
	public Rect robotRect = new Rect (490,130,200,230);
	public string robotString = "This is the number of robots currently functioning. Robots are the tools by which " +
		"you will perform any and all tasks. Though you start with a relatively low number of Mk I's, you will be " +
		"able to degrade these into a higher quantity of lower-tier robots. Be warned that once lost, you will never " +
		"be able to regain your Mk I's. ";

	public Rect robotBRect = new Rect (490,130,200,230);
	public string robotBString = "There are three classes of robots. " +
		"Top-Tier: Mk I - high maintenance, high efficiency; able to perform all tasks " +
		"Mid-Tier: Mk II - medium maintenance, medium efficiency; high level tasks locked " +
		"Bottom-Tier: Mk III - low maintenance, low efficiency; only able to perform base functions ";

	//window2
	public Rect materialsRect = new Rect (490,290,200,230);
	public string materialsString = "These are the materials which you will manage. Components are used for developing the " +
		"systems your currently have. " +
		"Metal is used for the conversion process as well as building developments. " +
		"Oil is used every turn to replenish your energy. If you run out of oil, you will be forced to terminate.";

	//window3
	public Rect tabsRect = new Rect (325,45,250,110);
	public string tabsString = "The tabs above will allow you to switch between the various screens in order to plan " +
		"our your turn.";

	//window4
	//Go into the tab then do window
	public Rect factoryRect = new Rect (10,225,200,150);
	public string factoryString = "This is the factory screen. It will allow you to degrade upper-tier robots to " +
		"lower-tier robots.";

	//window5
	//Go to developments
	public Rect developmentsRect = new Rect (10,225,200,150);
	public string developmentsString = "This is the developments screen. You will manage the development of your various " +
		"systems.";

	//window6
	public Rect messagesRect = new Rect (350,225,200,140);
	public string messagesString = "This is the messages screen. It will alert you to new tasks and developments, as well " +
		"as keep a record of previous turns.";

	//window7
	public Rect tasksRect = new Rect (350,225,200,125);
	public string tasksString = "This is the tasks screen. You assign robots to various tasks necessary for " +
		"survival and expansion.";

	//window8
	//Go home
	public Rect energyRect = new Rect (20,370,200,170);
	public string energyString = "This is the energy which is allotted to you to activate robots. It will replenish " +
		"each turn at the expense of oil. It, like many other things, can be upgraded in the developments screen.";

	//window9
	public Rect executeRect = new Rect (325,240,200,95);
	public string executeString = "This will end your turn and execute all planned functions.";

	//window10
	//Button - exit tutorial
	public Rect playRect = new Rect (365,250,124,80);
	public string playString = "Tutorial complete.";

	public string currentMenu = "";

	void Start () {
		manager.onClickHome ();
		currentMenu = "window0";
	}
	void NavigateTo(string nextmenu) {
		currentMenu = nextmenu;
	}
	void OnGUI() {
		if (currentMenu == "window0")
			Welcome ();
		if (currentMenu == "window1a") 
			Robots ();
		if (currentMenu == "window1b")
			RobotsB ();
		if (currentMenu == "window2") 
			Materials ();
		if (currentMenu == "window3") 
			Tabs ();
		if (currentMenu == "window4")
			Factory ();
		if (currentMenu == "window5")
			Developments ();
		if (currentMenu == "window6")
			Messages ();
		if (currentMenu == "window7")
			Tasks ();
		if (currentMenu == "window8")
			Energy ();
		if (currentMenu == "window9")
			Execute ();
		if (currentMenu == "window10")
			Play ();
	}
	void Welcome() {
		if (GUI.Button (new Rect (startUpRect.x + 20, startUpRect.y + startUpRect.height - 35, 55, 25), "Next")) {
			NavigateTo ("window1a");
		}
		if (GUI.Button (new Rect (startUpRect.x + 80, startUpRect.y + startUpRect.height - 35, 105, 25), "Skip Tutorial")) {
			enabled = false;
		}
		GUI.Window (0, startUpRect, WindowFunction, "Welcome");
	}
	void Robots() {
		if (GUI.Button (new Rect (robotRect.x + 40, robotRect.y + robotRect.height - 35, 55, 25), "Next")) {
			NavigateTo("window1b");
		}
		if (GUI.Button (new Rect (robotRect.x + 100, robotRect.y + robotRect.height - 35, 65, 25), "Previous")) {
			NavigateTo("window0");
		}
		GUI.Window (0, robotRect, WindowFunction, "Robots");
	}
	void RobotsB() {
		if (GUI.Button (new Rect (robotBRect.x + 40, robotBRect.y + robotBRect.height - 35, 55, 25), "Next")) {
			NavigateTo("window2");
		}
		if (GUI.Button (new Rect (robotBRect.x + 100, robotBRect.y + robotBRect.height - 35, 65, 25), "Previous")) {
			NavigateTo("window1a");
		}
		GUI.Window (0, robotBRect, WindowFunction, "Robots");

	}
	void Materials() {
		if (GUI.Button (new Rect (materialsRect.x + 40, materialsRect.y + materialsRect.height - 35, 55, 25), "Next")) {
			NavigateTo("window3");
		}
		if (GUI.Button (new Rect (materialsRect.x + 100, materialsRect.y + materialsRect.height - 35, 65, 25), "Previous")) {
			NavigateTo("window1b");
		}
		GUI.Window (0, materialsRect, WindowFunction, "Materials");
	}
	void Tabs() {
		if (GUI.Button (new Rect (tabsRect.x + tabsRect.width/2 - 57.5f, tabsRect.y + tabsRect.height - 35, 55, 25), "Next")) {
			manager.onClickFactory();
			NavigateTo("window4");
		}
		if (GUI.Button (new Rect (tabsRect.x + tabsRect.width/2 + 2.5f, tabsRect.y + tabsRect.height - 35, 65, 25), "Previous")) {
			NavigateTo("window2");
		}
		GUI.Window (0, tabsRect, WindowFunction, "Tabs");

	}
	void Factory() {
		if (GUI.Button (new Rect (factoryRect.x + 40, factoryRect.y + factoryRect.height - 35, 55, 25), "Next")) {
			manager.onClickDevelopments();
			NavigateTo("window5");
		}
		if (GUI.Button (new Rect (factoryRect.x + 100, factoryRect.y + factoryRect.height - 35, 65, 25), "Previous")) {
			manager.onClickHome();
			NavigateTo("window3");
		}
		GUI.Window (0, factoryRect, WindowFunction, "Factory");
	}

	void Developments() {
		if (GUI.Button (new Rect (developmentsRect.x + 40, developmentsRect.y + developmentsRect.height - 35, 55, 25), "Next")) {
			manager.onClickMessages();
			NavigateTo("window6");
		}
		if (GUI.Button (new Rect (developmentsRect.x + 100, developmentsRect.y + developmentsRect.height - 35, 65, 25), "Previous")) {
			manager.onClickFactory();
			NavigateTo("window4");
		}
		GUI.Window (0, developmentsRect, WindowFunction, "Developments");
	}
	void Messages() {
		if (GUI.Button (new Rect (messagesRect.x + 40, messagesRect.y + messagesRect.height - 35, 55, 25), "Next")) {
			manager.onClickTasks();
			NavigateTo("window7");
		}
		if (GUI.Button (new Rect (messagesRect.x + 100, messagesRect.y + messagesRect.height - 35, 65, 25), "Previous")) {
			manager.onClickDevelopments();
			NavigateTo("window5");
		}
		GUI.Window (0, messagesRect, WindowFunction, "Messages");

	}
	void Tasks() {
		if (GUI.Button (new Rect (tasksRect.x + 40, tasksRect.y + tasksRect.height - 35, 55, 25), "Next")) {
			manager.onClickHome();
			NavigateTo("window8");
		}
		if (GUI.Button (new Rect (tasksRect.x + 100, tasksRect.y + tasksRect.height - 35, 65, 25), "Previous")) {
			manager.onClickMessages();
			NavigateTo("window6");
		}
		GUI.Window (0, tasksRect, WindowFunction, "Tasks");
	}
	void Energy() {
		if (GUI.Button (new Rect (energyRect.x + 40, energyRect.y + energyRect.height - 35, 55, 25), "Next")) {
			NavigateTo("window9");
		}
		if (GUI.Button (new Rect (energyRect.x + 100, energyRect.y + energyRect.height - 35, 65, 25), "Previous")) {
			manager.onClickTasks();
			NavigateTo("window7");
		}
		GUI.Window (0, energyRect, WindowFunction, "Energy");

	}
	void Execute() {
		if (GUI.Button (new Rect (executeRect.x + 40, executeRect.y + executeRect.height - 35, 55, 25), "Next")) {
			NavigateTo("window10");
		}
		if (GUI.Button (new Rect (executeRect.x + 100, executeRect.y + executeRect.height - 35, 65, 25), "Previous")) {
			NavigateTo("window8");
		}
		GUI.Window (0, executeRect, WindowFunction, "Execute");
	}
	void Play() {
		if (GUI.Button (new Rect(playRect.x + playRect.width/2 - 40, playRect.y + playRect.height - 35, 80,25), "End Tutorial")) {
			enabled = false;
		}
		GUI.Window (0, playRect, WindowFunction, "Begin");
	}

	void WindowFunction(int windowID) {
		if (currentMenu == "window0") {
			GUI.Label (new Rect(10,20,startUpRect.width - 20,startUpRect.height - 20),startUpString);
		}
		if (currentMenu == "window1a") {
			GUI.Label (new Rect(10,20,robotRect.width - 20,robotRect.height - 20), robotString);
		}
		if (currentMenu == "window1b") {
			GUI.Label (new Rect (10, 20, robotBRect.width - 20, robotBRect.height - 20),robotBString);
		}
		if (currentMenu == "window2") {
			GUI.Label (new Rect(10,20,materialsRect.width - 20,materialsRect.height - 20),materialsString);
		}
		if (currentMenu == "window3") {
			GUI.Label (new Rect(10,20,tabsRect.width - 20,tabsRect.height - 20),tabsString);
		}
		if (currentMenu == "window4") {
			GUI.Label (new Rect(10,20,factoryRect.width - 20,factoryRect.height - 20),factoryString);
		}
		if (currentMenu == "window5") {
			GUI.Label (new Rect (10, 20, developmentsRect.width - 20, developmentsRect.height - 20),developmentsString);
		}
		if (currentMenu == "window6") {
			GUI.Label (new Rect (10,20,messagesRect.width - 20,messagesRect.height - 20),messagesString);
		}
		if (currentMenu == "window7") {
			GUI.Label (new Rect (10, 20, tasksRect.width - 20, tasksRect.height - 20),tasksString);
		}
		if (currentMenu == "window8") {
			GUI.Label (new Rect (10, 20, energyRect.width - 20, energyRect.height - 20),energyString);
		}
		if (currentMenu == "window9") {
			GUI.Label (new Rect (10, 20, executeRect.width - 20, executeRect.height - 20),executeString);
		}
		if (currentMenu == "window10") {
			GUI.Label (new Rect (10, 20, playRect.width - 20, playRect.height - 20),playString);
		}
	}
	
	void Update () {

	}
}
