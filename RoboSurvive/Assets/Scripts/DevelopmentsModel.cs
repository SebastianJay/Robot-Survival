using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DevelopmentsModel : Observable {

	public List<string> undeveloped;
	public List<string> developed;

	// Use this for initialization
	new public void Start () {
		undeveloped = new List<string>();
		undeveloped.Add("Hello!");
		undeveloped.Add("Bye!");
		developed = new List<string>();
	}

	public DevelopmentsModel Clone() {
		DevelopmentsModel m = new DevelopmentsModel();
		m.SetUndeveloped(undeveloped);
		m.SetDeveloped(developed);
		return m;
	}

	public bool Develop(string development) {
		if (undeveloped.Contains(development)) {
			developed.Add(development);
			undeveloped.Remove(development);
			return true;
		}
		return false;
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
