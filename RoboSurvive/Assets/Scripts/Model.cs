using UnityEngine;
using System.Collections;

/**
 * for lack of a better name
 * 
 * Information about the game state here
 */
public class Model : UnityEngine.MonoBehaviour {
	// robot count
	public int robots1=500;	//the highest tier
	public int robots2=0;	//next tier
	public int robots3=0;	

	// resources
	public int electricity=0;
	public int oil=50;
	public int metal=10;
	public int components=10;

	// game state 
	public int expansionLevel=0;
	public int fortificationLevel=0;

	// upgrade levels
	public float expandChart=0.5f;
	public int improvedExpand=0;
	public int improvedCollect=0;
	public int improvedUpkeep=0;

	//allocation vars
	public int robots1Collect=0;
	public int robots2Collect=0;
	public int robots3Collect=0;
	public int robots1Fortify=0;
	public int robots2Fortify=0;
	public int robots1Expand=0;

	public Model clone()
	{
		Model m = new Model ();
		m.robots1 = robots1;
		m.robots2 = robots2;
		m.robots3 = robots3;

		m.electricity = electricity;
		m.oil = oil;
		m.metal = metal;
		m.components = components;
		m.expansionLevel = expansionLevel;
		m.fortificationLevel = fortificationLevel;

		m.expandChart = expandChart;
		m.improvedExpand = improvedExpand;
		m.improvedCollect = improvedCollect;
		m.improvedUpkeep = improvedUpkeep;
		return m;
	}
}
