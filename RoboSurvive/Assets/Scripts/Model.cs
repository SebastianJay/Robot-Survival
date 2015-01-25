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
	public int metal=0;
	public int components=0;

	// game state 
	public int expansionLevel=0;
	public int fortificationLevel=0;

	// upgrade levels
	public float expandChart=0.5f;
	public int improvedExpand=0;
	public int improvedCollect=0;
	public int improvedUpkeep=0;

}
