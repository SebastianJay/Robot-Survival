using UnityEngine;
using System.Collections;

public class MetaModel : Observable {

	public int year;
	public int storyPath;


	// Use this for initialization
	new public void Start () {
		base.Start ();
		this.year = 2045;
		this.storyPath = 0;


	}

	public MetaModel Clone() {
		MetaModel m = new MetaModel ();
		m.SetYear (year);
		m.SetStoryPath (storyPath);

		return m;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public int GetYear() {
		return this.year;
	}

	public int GetStoryPath {
		return this.storyPath;
	}

	public void SetYear(float value) {
		year = (int)value;
		NotifyAll ("year", (int)value);
	}

	public void SetStoryPath(float value) {
		storyPath = (int)value;
		NotifyAll ("storyPath", (int)value);
	}
}
