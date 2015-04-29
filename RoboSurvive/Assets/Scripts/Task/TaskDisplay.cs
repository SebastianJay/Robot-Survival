using UnityEngine;
using System.Collections;

public class TaskDisplay : MonoBehaviour {

    public DetailDisplay detail;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ShowTask()
    {
        Task t = GetComponent<Task>();

        detail.ShowTask(t);
    }
}
