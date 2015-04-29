using UnityEngine;
using System.Collections;

public class Collections : SimScript {

    public float resPerMk1, resPerMk2, resPerMk3, bonusResPerDev;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public override void RunSimulation(Transform preTurn, Transform afterTurn, Transform result)
    {
        var oilRate = 0;
        var compRate = 0;
        var metalRate = 0;
        
        var d = result.GetComponent<DevelopmentsModel>();
        var meta = result.GetComponent<MetaModel>();
        var res = result.GetComponent<ResourceModel>();

        var devs = d.GetDeveloped();

        foreach(string dev in devs) 
        {
            if (dev.Equals("Energy Capacity"))
            {
                //Energy
            }
            else if (dev.Equals("Metal"))
            {
                metalRate++;
            }
            else if (dev.Equals("Fine"))
            {
                compRate++;
            }
            else if (dev.Equals("Derrick"))
            {
                oilRate++;
            }
        }
        
        float oilScale = 1 + bonusResPerDev * oilRate;
        float compScale = 1 + bonusResPerDev * compRate;
        float metScale = 1 + bonusResPerDev * metalRate;

        foreach (Task t in afterTurn.GetComponents<Task>())
        {
            if (t.type.Equals("collect"))
            {
                if (t.internalName.Equals("oil"))
                {
                    float newOil = (t.mk1 * resPerMk1 + t.mk2 * resPerMk2 + t.mk3 * resPerMk3) * oilScale;
                    res.SetOil(res.GetOil() + (int)newOil);
                    meta.AddMessage("Collected " + newOil + " oil.");
                }
                else if (t.internalName.Equals("comp"))
                {
                    float newComp = (t.mk1 * resPerMk1 + t.mk2 * resPerMk2 + t.mk3 * resPerMk3) * compScale;
                    res.SetComponents(res.GetComponents() + (int)newComp);
                    meta.AddMessage("Collected " + newComp + " components.");
                }
                else if (t.internalName.Equals("metal"))
                {
                    float newMetal = (t.mk1 * resPerMk1 + t.mk2 * resPerMk2 + t.mk3 * resPerMk3) * metScale;
                    res.SetMetal(res.GetMetal() + (int)newMetal);
                    meta.AddMessage("Collected " + newMetal + " metal.");
                }
            }
        }
    }
}
