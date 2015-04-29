using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LabelList : MonoBehaviour {
	
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
		contentPanel.transform.localScale = new Vector3 (1, devs.GetDeveloped ().Count, 1);
		contentPanel.transform.position = new Vector3 (0, 0, 0);
		foreach (string dev in devs.GetDeveloped()) {
			Transform button = Instantiate (theButton) as Transform;
			button.SetParent(contentPanel);	
			button.gameObject.SetActive(true);
			foreach (Text text in button.transform.GetComponentsInChildren<Text>()) {
				if (!text.text.Equals("Develop")) {
					text.text = dev;
				}
			}
			Vector3 pos = posPanel.position;
			button.position = pos + new Vector3(100, -325 - 50 * devs.GetDeveloped().IndexOf(dev), 1);
		}
	}
}
