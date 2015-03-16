using UnityEngine;
using System.Collections;

public abstract class Observer : MonoBehaviour {

	// Initializes
	public abstract void Start();
	
	// Updates states when subject changes
	public abstract void Notify(string field, int val);

}
