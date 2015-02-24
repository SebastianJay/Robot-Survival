using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Observable : MonoBehaviour {

	// Collection of observers attached to this observable
	public List<Observer> observers;

	// Initializes
	public void Start() {

	}

	// Adds o to observers
	public void Attach(Observer o) {
		observers.Add(o);
	}

	// Removes o from observers
	public void Detach(Observer o) {
		observers.Remove(o);
	}

	// Calls notify on each observer in observers
	public void NotifyAll(string field, int val) {
		foreach (Observer o in observers) {
			o.Notify(field, val);
		}
	}
}
