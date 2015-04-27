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

	}


	// Update is called once per frame
	void Update () {
	
	}

	public void onClickTasks () {
		tasks.position.Set (0, 0, 0);
		home.position.Set (-1000, -1000, 0);
		messages.position.Set (-1000, -1000, 0);
		factory.position.Set (-1000, -1000, 0);
		developments.position.Set (-1000, -1000, 0);
	}

	public void onClickFactory () {
		tasks.position.Set (-1000, -1000, 0);
		home.position.Set (-1000, -1000, 0);
		messages.position.Set (-1000, -1000, 0);
		factory.position.Set (0, 0, 0);
		developments.position.Set (-1000, -1000, 0);
	}

	public void onClickHome () {
		tasks.position.Set (-1000, -1000, 0);
		home.position.Set (0, 0, 0);
		messages.position.Set (-1000, -1000, 0);
		factory.position.Set (-1000, -1000, 0);
		developments.position.Set (-1000, -1000, 0);
	}

	public void onClickDevelopments () {
		tasks.position.Set (-1000, -1000, 0);
		home.position.Set (-1000, -1000, 0);
		messages.position.Set (-1000, -1000, 0);
		factory.position.Set (-1000, -1000, 0);
		developments.position.Set (0, 0, 0);
	}

	public void onClickMessages () {
		tasks.position.Set (-1000, -1000, 0);
		home.position.Set (-1000, -1000, 0);
		messages.position.Set (0, 0, 0);
		factory.position.Set (-1000, -1000, 0);
		developments.position.Set (-1000, -1000, 0);
	}

}
