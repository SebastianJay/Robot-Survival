using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MessageList : MonoBehaviour {
	
	public MetaModel meta;
	public Transform contentPanel;
	public Transform posPanel;
	public Transform theButton;
	
	// Use this for initialization
	void Start () {
		this.PopulateList ();
	}
	
	// Populates list of buttons
	void PopulateList () {
		int lastY = 175;
		int wrap = 1;
		foreach (string dev in meta.messages) {
			Transform button = Instantiate (theButton) as Transform;
			button.SetParent(contentPanel);	
			button.gameObject.SetActive(true);
			foreach (Text text in button.transform.GetComponentsInChildren<Text>()) {
				if (!text.text.Equals("Develop")) {
					text.text = dev;
				}
			}
			Vector3 pos = posPanel.position;
			button.position = pos + new Vector3(50, lastY - 30 * wrap, 1);
			lastY -= 30 * wrap;
			wrap = dev.Length/30 + 1;
		}
		lastY -= 30 * wrap + 175;
		contentPanel.GetComponent<RectTransform> ().sizeDelta = new Vector3 (560, -1 * lastY);
	}
}
