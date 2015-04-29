using UnityEngine;
using System.Collections;

public class RobotModel : Observable
{
	public int OneToTwo;
	public int TwoToThree;

    public int markOneAlloc;
    public int markTwoAlloc;
    public int markThreeAlloc;

    public int markOne;
    public int markTwo;
    public int markThree;
	
	// Initializes
	new public void Start() {
		base.Start();
        NotifyAll("mk1", markOne);
        NotifyAll("mk2", markTwo);
        NotifyAll("mk3", markThree);
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

	public void AllocateMarkOne(int value) {
        markOneAlloc += value;
		NotifyAll("mk1", markOne - markOneAlloc);
		NotifyAll("mk1_alloc", value);
	}

    public void AllocateMarkTwo(int value)
    {
        markTwoAlloc += value;
        NotifyAll("mk2", markTwo - markTwoAlloc);
        NotifyAll("mk2_alloc", value);
	}

    public void AllocateMarkThree(int value)
    {
        markThreeAlloc += value;
        NotifyAll("mk3", markThree - markThreeAlloc);
        NotifyAll("mk3_alloc", value);
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