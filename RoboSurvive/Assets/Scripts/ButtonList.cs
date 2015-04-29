using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ButtonList : MonoBehaviour {

	public DevelopmentsModel devs;
	public Transform contentPanel;
	public Button theButton;

	// Use this for initialization
	void Start () {
		this.PopulateList ();
	}
	
	// Populates list of buttons
	void PopulateList () {
		foreach (string dev in devs.GetUndeveloped()) {
			Button button = Instantiate (theButton) as Button;
			button.transform.SetParent(contentPanel);	
			button.gameObject.SetActive(true);
			button.transform.GetComponentInChildren<Text>().text = dev;
		}
	}
}
