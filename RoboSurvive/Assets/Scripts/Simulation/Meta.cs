using UnityEngine;
using System.Collections.Generic;

public class Meta : SimScript {

    public SoundMixer mixer;
    public StorySelector sel;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public override void RunSimulation(Transform preTurn, Transform afterTurn, Transform result) {
        var meta = result.GetComponent<MetaModel>();
        meta.SetYear(meta.GetYear() + 1);

        if (meta.year >= 2070)
        {
            mixer.PlayStage5();
            sel.AddAct3 = true;
        }
        else if (meta.year >= 2060)
        {
            mixer.PlayStage4();
        }
        else if (meta.year >= 2055)
        {
            mixer.PlayStage3();
            sel.AddAct2 = true;
            sel.set = true;
        }
        else if (meta.year >= 2050)
        {
            mixer.PlayStage2();
        }
        else 
        {
            mixer.PlayStage1();
        }

        if(meta.storyPath >= 0 && !sel.set) {
            sel.Sulphate = true;
        }
	}
}
