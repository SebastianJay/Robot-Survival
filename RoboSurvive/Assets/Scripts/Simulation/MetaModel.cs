using UnityEngine;
using System.Collections.Generic;

public class MetaModel : Observable {

	public int year;
	public int storyPath;

	public List<string> messages;


	// Initializes
	new public void Start () {
		base.Start ();
		this.year = 2045;
		this.storyPath = 0;
	}

	// Returns copy of this model
	public MetaModel Clone() {
		MetaModel m = new MetaModel ();
		m.SetYear (year);
		m.SetStoryPath (storyPath);

		return m;
	}

	// Getters and Setters

	public int GetYear() {
		return this.year;
	}
	public void SetYear(float value) {
		year = (int)value;
		NotifyAll ("year", (int)value);
	}

	public int GetStoryPath() {
		return this.storyPath;
	}
	public void SetStoryPath(float value) {
		storyPath = (int)value;
		NotifyAll ("storyPath", (int)value);
	}
}
