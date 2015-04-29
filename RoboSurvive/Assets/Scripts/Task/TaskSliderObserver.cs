using UnityEngine;
using System.Collections;

public class TaskSliderObserver : Observer {

	public UnityEngine.UI.Slider slider;
	
	public override void Start() {
	}
	
	// Updates states when subject changes
	public override void Notify(string field, int val) {
		if (slider.tag.Equals(field)) {
            slider.maxValue = val;
		}
	}
}
