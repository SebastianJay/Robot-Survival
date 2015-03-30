using UnityEngine;
using System.Collections;

public class Observer : MonoBehaviour {

	public UnityEngine.UI.Text label;

	public void Start() {
		label.text = "0";
	}

	// Updates states when subject changes
	public void Notify(string field, int val) {
		if (label.tag.Equals(field)) {
			label.text = val.ToString ();
		}
	}
}
