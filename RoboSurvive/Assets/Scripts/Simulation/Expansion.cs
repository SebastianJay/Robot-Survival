using UnityEngine;
using System.Collections;

public class Expansion : SimScript
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void Expand(Task t)
    {

    }

    public override void RunSimulation(Transform preTurn, Transform afterTurn, Transform result)
    {
        foreach(Task t in afterTurn.GetComponents<Task>()) {
            if (t.type.Equals("expand"))
            {
                Expand(t);
            }
        }
    }
}
