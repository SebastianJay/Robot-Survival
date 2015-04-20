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
			foreach (Text text in button.transform.GetComponentsInChildren<Text>()) {
				text.text = dev;
			}
			button.transform.position = new Vector3(550, 250 - 50 * devs.GetUndeveloped().IndexOf(dev), 1);
		}
	}
}
