using UnityEngine;
using System.Collections;

public class ResourceModel : Observable {

	public int oil;
	public int metal;
	public int components;
	public int electricity;

	// Initializes
	new public void Start() {
		base.Start();
		this.oil = 0;
		this.metal = 0;
		this.components = 0;
		this.electricity = 0;
	}

	// Returns copy of this model
	public ResourceModel Clone() {
		ResourceModel m = new ResourceModel();
		m.SetOil(oil);
		m.SetMetal(metal);
		m.SetComponents(components);
		m.SetElectricity(electricity);
		return m;
	}

	// Getters and Setters

	public int GetOil() {
		return this.oil;
	}
	public void SetOil(float value) {
		oil = (int)value;
		NotifyAll("oil", (int)value);
	}

	public int GetMetal() {
		return this.metal;
	}
	public void SetMetal(int value) {
		metal = value;
		NotifyAll("metal", value);
	}

	public int GetComponents() {
		return this.components;
	}
	public void SetComponents(int value) {
		components = value;
		NotifyAll("components", value);
	}

	public int GetElectricity() {
		return this.electricity;
	}
	public void SetElectricity(int value) {
		electricity = value;
		NotifyAll("electricity", value);
	}
}
