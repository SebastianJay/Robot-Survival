
using UnityEngine;
using System.Collections;

public class RobotModel : Observable {
	
	public int markOne;
	public int markTwo;
	public int markThree;
	
	// Initializes
	new public void Start() {
		base.Start();
		this.markOne = 500;
		this.markTwo = 0;
		this.markThree = 0;

	}
	
	// Returns copy of this model
	public RobotModel Clone() {
		RobotModel m = new RobotModel();
		m.SetOne(markOne);
		m.SetTwo(markTwo);
		m.SetThree(markThree);
		return m;
	}
	
	// Getters and Setters
	
	public int GetOne() {
		return this.markOne;
	}
	public void SetOne(float value) {
		markOne = (int)value;
		NotifyAll("mark one", (int)value);
	}
	
	public int GetTwo() {
		return this.markTwo;
	}
	public void SetTwo(int value) {
		markTwo = value;
		NotifyAll("mark two", value);
	}
	
	public int GetThree() {
		return this.markThree;
	}
	public void SetThree(int value) {
		markThree = value;
		NotifyAll("mark three", value);
	}

}