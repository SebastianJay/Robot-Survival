using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DetailDisplay : MonoBehaviour {

    public Text nameField;
    public Text descField;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ShowTask(Task t)
    {
        nameField.text = t.name;
        descField.text = t.desc;

    }
}
