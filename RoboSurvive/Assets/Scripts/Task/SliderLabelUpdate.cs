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
                label.text = task.mk1.ToString();
                slider.value = task.mk1;
                slider.maxValue = 100;
            }
            else if (field.Equals("mk2"))
            {
                label.text = task.mk2.ToString();
            }
            else if (field.Equals("mk3"))
            {
                label.text = task.mk3.ToString();
            }
        }
    }
}
