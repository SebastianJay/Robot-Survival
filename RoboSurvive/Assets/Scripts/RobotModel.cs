using UnityEngine;
using System.Collections;

public class RobotModel : Observable {

	private float mk1LastVal;
	private float mk2LastVal;
	private float mk3LastVal;

	public int markOne;
	public int markTwo;
	public int markThree;
	
	// Initializes
	new public void Start() {
		base.Start();
		this.mk1LastVal = 0;
		this.SetMarkOne(1000);
		this.SetMarkTwo(0);
		this.SetMarkThree(0);
	}
	
	// Returns copy of this model
	public RobotModel Clone() {
		RobotModel m = new RobotModel();
		m.SetMarkOne(markOne);
		m.SetMarkTwo(markTwo);
		m.SetMarkThree(markThree);
		return m;
	}

	// Methods for allocating robots

	public void AllocateMarkOne(float value) {
		markOne = markOne + (int)(mk1LastVal - value);
		NotifyAll("mk1", markOne);
		NotifyAll("mk1_alloc", (int)value);
		mk1LastVal = value;
	}

	public void AllocateMarkTwo(float value) {
		markOne = markTwo + (int)(mk2LastVal - value);
		NotifyAll("mk2", markTwo);
		NotifyAll("mk2_alloc", (int)value);
		mk2LastVal = value;
	}

	public void AllocateMarkThree(float value) {
		markOne = markOne + (int)(mk3LastVal - value);
		NotifyAll("mk3", markThree);
		NotifyAll("mk3_alloc", (int)value);
		mk3LastVal = value;
	}
	
	// Getters and Setters
	
	public int GetMarkOne() {
		return this.markOne;
	}
	public void SetMarkOne(int value) {
		markOne = value;
		NotifyAll("mk1", value);
	}
	
	public int GetMarkTwo() {
		return this.markTwo;
	}
	public void SetMarkTwo(int value) {
		markTwo = value;
		NotifyAll("mk2", value);
	}
	
	public int GetMarkThree() {
		return this.markThree;
	}
	public void SetMarkThree(int value) {
		markThree = value;
		NotifyAll("mk3", value);
	}

}