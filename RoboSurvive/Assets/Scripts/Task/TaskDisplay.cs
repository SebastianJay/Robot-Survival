using UnityEngine;
using System.Collections;

public class TaskDisplay : MonoBehaviour {

    public DetailDisplay detail;
    public Task t;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ShowTask()
    {
        detail.ShowTask(t);
    }
}
