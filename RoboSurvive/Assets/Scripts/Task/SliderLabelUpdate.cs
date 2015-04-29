using UnityEngine;
using System.Collections;

public class SliderLabelUpdate : MonoBehaviour {

    public UnityEngine.UI.Text label;
    public UnityEngine.UI.Slider slider;
    public Task task;
    public string field;
    
	public void Start() {
	}

    public void Update()
    {
        if (task != null)
        {
            if (field.Equals("mk1"))
            {
                if ((int)slider.value != task.mk1)
                {
                    GameObject.FindGameObjectWithTag("AfterTurn").GetComponent<RobotModel>().AllocateMarkOne((int) (slider.value - task.mk1));
                }
                task.mk1 = (int)slider.value;
                label.text = task.mk1.ToString();
            }
            else if (field.Equals("mk2"))
            {
                if ((int)slider.value != task.mk2)
                {
                    GameObject.FindGameObjectWithTag("AfterTurn").GetComponent<RobotModel>().AllocateMarkTwo((int)(slider.value - task.mk2));
                }
                task.mk2 = (int)slider.value;
                label.text = task.mk2.ToString();
            }
            else if (field.Equals("mk3"))
            {
                if ((int)slider.value != task.mk3)
                {
                    GameObject.FindGameObjectWithTag("AfterTurn").GetComponent<RobotModel>().AllocateMarkThree((int)(slider.value - task.mk3));
                }
                task.mk3 = (int)slider.value;
                label.text = task.mk3.ToString();
            }
        }
    }

    public void SetTask(Task t)
    {
        task = t;
        var r = GameObject.FindGameObjectWithTag("AfterTurn").GetComponent<RobotModel>();

        if (field.Equals("mk1"))
        {
            slider.maxValue = task.mk1 + r.markOne - r.markOneAlloc;
            slider.value = task.mk1;
            label.text = task.mk1.ToString();
        }
        else if (field.Equals("mk2"))
        {
            slider.maxValue = task.mk2 + r.markTwo - r.markTwoAlloc;
            slider.value = task.mk2;
            label.text = task.mk2.ToString();
        }
        else if (field.Equals("mk3"))
        {
            slider.maxValue = task.mk3 + r.markThree - r.markThreeAlloc;
            slider.value = task.mk3;
            label.text = task.mk3.ToString();
        }

    }
}
