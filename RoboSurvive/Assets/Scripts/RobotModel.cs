
using UnityEngine;
using System.Collections;

public class RobotModel : Observable {
	
	public int markOne;
	public int markTwo;
	public int markThree;
	
	// Initializes
	new public void Start() {
		base.Start();
		this.markOne = 0;
		this.markTwo = 0;
		this.markThree = 0;

	}
	
	// Returns copy of this model
	public RobotModel Clone() {
		RobotModel m = new RobotModel();
		m.SetMarkOne(markOne);
		m.SetMarkTwo(markTwo);
		m.SetMarkThree(markThree);
		return m;
	}
	
	// Getters and Setters
	
	public int GetMarkOne() {
		return this.markOne;
	}
	public void SetMarkOne(float value) {
		markOne = (int)value;
		NotifyAll("mk1", (int)value);
	}
	
	public int GetMarkTwo() {
		return this.markTwo;
	}
	public void SetMarkTwo(float value) {
		markTwo = (int)value;
		NotifyAll("mk2", (int)value);
	}
	
	public int GetMarkThree() {
		return this.markThree;
	}
	public void SetMarkThree(float value) {
		markThree = (int)value;
		NotifyAll("mk3", (int)value);
	}

}