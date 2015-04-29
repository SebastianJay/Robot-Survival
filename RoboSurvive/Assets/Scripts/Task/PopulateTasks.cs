using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class PopulateTasks : MonoBehaviour {

    public Transform taskButton;
    public DetailDisplay detail;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.A))
        {
            OnEnter();
        }
	}

    void OnEnter()
    {
        Populate(GameObject.FindGameObjectWithTag("AfterTurn").GetComponents<Task>());
    }

    void Populate(Task[] tasks)
    {
        int x = 0;
        int y = 93;

        foreach (Task task in tasks)
        {
            Transform b = (Transform) Instantiate(taskButton);
            b.parent = transform;
            b.localPosition = new Vector3(x, y, 0);

            TaskDisplay td = b.GetComponent<TaskDisplay>();
            td.detail = detail;
            td.t = task;

            Text name = b.GetComponentInChildren<Text>();
            name.text = task.name;

            y -= 30;
        }
    }
}
