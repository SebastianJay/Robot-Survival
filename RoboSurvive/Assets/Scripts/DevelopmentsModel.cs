using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class DevelopmentsModel : Observable {

	public List<string> undeveloped;
	public List<string> developed;

	// Use this for initialization
	new public void Start () {
	}

	public DevelopmentsModel Clone() {
		DevelopmentsModel m = new DevelopmentsModel();
		m.SetUndeveloped(undeveloped);
		m.SetDeveloped(developed);
		return m;
	}

	public void Develop(GameObject dev) {
		string development = dev.GetComponent<Text>().text;
		if (undeveloped.Contains(development)) {
			developed.Add(development);
			undeveloped.Remove(development);
		}
	}

	public List<string> GetUndeveloped() {
		return undeveloped;
	}
	public void SetUndeveloped(List<string> undeveloped) {
		this.undeveloped = undeveloped;
	}

	public List<string> getDeveloped() {
		return developed;
	}
	public void SetDeveloped(List<string> developed) {
		this.developed = developed;
	}
}
