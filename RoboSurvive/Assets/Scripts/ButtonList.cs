using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ButtonList : MonoBehaviour {

	public DevelopmentsModel devs;
	public Transform contentPanel;
	public Transform posPanel;
	public Transform theButton;

	// Use this for initialization
	void Start () {
		this.PopulateList ();
	}
	
	// Populates list of buttons
	void PopulateList () {
		contentPanel.transform.localScale = new Vector3 (1, devs.GetUndeveloped ().Count, 1);
		contentPanel.transform.position = new Vector3 (0, 0, 0);
		foreach (string dev in devs.GetUndeveloped()) {
			Transform button = Instantiate (theButton) as Transform;
			button.SetParent(contentPanel);	
			button.gameObject.SetActive(true);
			foreach (Text text in button.transform.GetComponentsInChildren<Text>()) {
				if (!text.text.Equals("Develop")) {
					text.text = dev;
				}
			}
			Vector3 pos = new Vector3(0, 0, 0);
			button.position = pos + new Vector3(150, 50 -50 * devs.GetUndeveloped().IndexOf(dev), 1);
		}
	}
}
