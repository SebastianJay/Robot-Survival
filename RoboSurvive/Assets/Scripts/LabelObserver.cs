using UnityEngine;
using System.Collections;

public class LabelObserver : Observer {

	public UnityEngine.UI.Text label;

	public override void Start() {
		label.text = "0";
	}

	// Updates states when subject changes
	public override void Notify(string field, int val) {
		if (label.tag.Equals(field)) {
			label.text = val.ToString ();
		}
	}
}
