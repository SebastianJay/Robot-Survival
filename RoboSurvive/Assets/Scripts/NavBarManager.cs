using UnityEngine;
using System.Collections;

public class NavBarManager : MonoBehaviour {
	public Transform tasks;
	public Transform home;
	public Transform developments;
	public Transform factory;
	public Transform messages;


	// Use this for initialization
	void Start () {
		//Rect tasksRect = tasks.GetComponent<RectTransform> ().localPosition.Set;
	}


	// Update is called once per frame
	void Update () {
	
	}

	public void onClickTasks () {
		Debug.Log ("working");
		tasks.GetComponent<RectTransform>().localPosition = new Vector3(0f, 0f, 0f);
		home.GetComponent<RectTransform>().localPosition = new Vector3(-1000f, -1000f, 0f);
		messages.GetComponent<RectTransform>().localPosition = new Vector3(-1000f, -1000f, 0f);
		factory.GetComponent<RectTransform>().localPosition = new Vector3(-1000f, -1000f, 0f);
		developments.GetComponent<RectTransform>().localPosition = new Vector3(-1000f, -1000f, 0f);
	}

	public void onClickFactory () {
		tasks.GetComponent<RectTransform>().localPosition = new Vector3(-1000f, -1000f, 0f);
		home.GetComponent<RectTransform>().localPosition = new Vector3(-1000f, -1000f, 0f);
		messages.GetComponent<RectTransform>().localPosition = new Vector3(-1000f, -1000f, 0f);
		factory.GetComponent<RectTransform>().localPosition = new Vector3(0f, 0f, 0f);
		developments.GetComponent<RectTransform>().localPosition = new Vector3(-1000f, -1000f, 0f);
	}

	public void onClickHome () {
		Debug.Log ("home");
		tasks.GetComponent<RectTransform>().localPosition = new Vector3(-1000f, -1000f, 0f);
		home.GetComponent<RectTransform>().localPosition = new Vector3(0f, 0f, 0f);
		messages.GetComponent<RectTransform>().localPosition = new Vector3(-1000f, -1000f, 0f);
		factory.GetComponent<RectTransform>().localPosition = new Vector3(-1000f, -1000f, 0f);
		developments.GetComponent<RectTransform>().localPosition = new Vector3(-1000f, -1000f, 0f);
	}

	public void onClickDevelopments () {
		tasks.GetComponent<RectTransform>().localPosition = new Vector3(-1000f, -1000f, 0f);
		home.GetComponent<RectTransform>().localPosition = new Vector3(-1000f, -1000f, 0f);
		messages.GetComponent<RectTransform>().localPosition = new Vector3(-1000f, -1000f, 0f);
		factory.GetComponent<RectTransform>().localPosition = new Vector3(-1000f, -1000f, 0f);
		developments.GetComponent<RectTransform>().localPosition = new Vector3(0f, 0f, 0f);
	}

	public void onClickMessages () {
		tasks.GetComponent<RectTransform>().localPosition = new Vector3(-1000f, -1000f, 0f);
		home.GetComponent<RectTransform>().localPosition = new Vector3(-1000f, -1000f, 0f);
		messages.GetComponent<RectTransform>().localPosition = new Vector3(0f, 0f, 0f);
		factory.GetComponent<RectTransform>().localPosition = new Vector3(-1000f, -1000f, 0f);
		developments.GetComponent<RectTransform>().localPosition = new Vector3(-1000f, -1000f, 0f);
	}

}
