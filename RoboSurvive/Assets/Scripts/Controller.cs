using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {

    private Expansion expand;
    private Upkeep upkeep;

	// Use this for initialization
    void Start()
    {
        expand = this.GetComponent<Expansion>();
        upkeep = this.GetComponent<Upkeep>();
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.anyKeyDown) {
            Run();
        }
	}

    private void RandomEvents()
    {

    }

    public void Run()
    {
        expand.Run();
        upkeep.Run();
    }
}
