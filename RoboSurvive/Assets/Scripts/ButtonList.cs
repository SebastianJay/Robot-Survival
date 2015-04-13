using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ButtonList : MonoBehaviour {

	public DevelopmentsModel devs;
	public Transform contentPanel;

	// Use this for initialization
	void Start () {
		this.PopulateList ();
	}
	
	// Populates list of buttons
	void PopulateList () {
		foreach (string dev in devs.GetUndeveloped()) {
			GameObject button = new GameObject();
			button.AddComponent<RectTransform>();
			button.AddComponent<Button>();
			button.AddComponent<Text>();
			button.GetComponent<Text>().text = dev;
			button.transform.SetParent(contentPanel);		
		}
	}
}
