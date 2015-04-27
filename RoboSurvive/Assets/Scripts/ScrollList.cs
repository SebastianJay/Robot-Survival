using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Item {
	public string name;
	public Sprite icon;
	public string type;
	public string rarity;
	public bool isChampion;
	public Button.ButtonClickedEvent thingToDo;
}

public class ScrollList : MonoBehaviour {
	
	public GameObject sampleButton;
	public List<Item> itemList;
	
	public Transform contentPanel;
	
	void Start () {
		PopulateList ();
	}
	
	void PopulateList () {
		foreach (var item in itemList) {
			GameObject newButton = Instantiate (sampleButton) as GameObject;
			SampleButton button = newButton.GetComponent <SampleButton> ();
			button.nameLabel.text = item.name;
			button.icon.sprite = item.icon;
			button.typeLabel.text = item.type;
			button.rarityLabel.text = item.rarity;
			button.championIcon.SetActive (item.isChampion);
			newButton.transform.SetParent (contentPanel);
		}
	}
}