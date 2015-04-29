using UnityEngine;
using System.Collections.Generic;

public class MetaModel : Observable {

	public int year;
	public int storyPath, freedom;
	public float fortification;

	public List<string> messages;


	// Initializes
	public void Start () {
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

    public int GetStoryPath()
    {
        return this.storyPath;
    }
    public void SetStoryPath(float value)
    {
        storyPath = (int)value;
        NotifyAll("storyPath", (int)value);
    }

    public int GetFreedom()
    {
        return this.freedom;
    }
    public void SetFreedom(float value) 
    {
        freedom = (int)value;
        NotifyAll("freedom", (int)value);
    }

    public void AddMessage(string msg)
    {
        messages.Add(msg);
    }
}
