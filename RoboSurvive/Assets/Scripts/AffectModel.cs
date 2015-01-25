using UnityEngine;
using System.Collections;

public class AffectModel : MonoBehaviour {


	public Model run(Model old, Model allocations) {
		Model result = old.clone();
		Random rand = new Random();

		// Deal with robots
		result.robots1 -= rand.Next(0, Mathf.Floor((allocations.robots1Collect + allocations.robots1Fortify + allocations.robots1Expand) / (old.armor + 1)) + 1);
		Debug.Log("Lost " + (old.robots1 - result.robots1) + " MK1 robots!");
		result.robots2 -= rand.Next(0, Mathf.Floor((allocations.robots2Collect + allocations.robots2Fortify) / (old.armor + 1)) + );
		Debug.Log("Lost " + (old.robots2 - result.robots2) + " MK2 robots!");
		result.robots3 -= rand.Next(0, Mathf.Floor(allocations.robots3Collect / (old.armor + 1)) + 1);
		Debug.Log("Lost " + (old.robots3 - result.robots3) + " MK3 robots!");


		// Expanding
		if (rand.Next(0, 100) < (allocations.expandChance + ((allocations.robots1Expand - 50) / 10)) * (old.weapons + 1)) {
			result.expansionLevel++;
			result.expandChance -= 5;
			Debug.Log("You expanded!");
		} else {
			Debug.Log("You failed in expanding!");
		}

		// Collecting
		int totRobots = (allocations.robots1Collect + allocations.robots2Collect + allocations.robots3Collect) - 50;
		result.oil += rand.Next(0, 20) + Mathf.Floor(totRobots / 5);
		Debug.Log ("Gained " + (result.oil - old.oil) + " oil!");
		result.metal += rand.Next(0, 20) + Mathf.Floor(totRobots / 5);
		Debug.Log ("Gained " + (result.metal - old.metal) + " metal!");
		result.components += rand.Next(0, 20) + Mathf.Floor(totRobots / 5);
		Debug.Log ("Gained " + (result.components - old.components) + " components!");

		// Fortifying
		totRobots = (allocations.robots1Fortify + allocations.robots2Fortify) - 50;
		result.fortificationLevel += ((totRobots + 50) / 50);
		Debug.Log ("Fortifications improved by " + (result.fortificationLevel - old.fortificationLevel) + "!");

		// Manufacture
		if (allocations.oneToTwo) {
			result.robots1 -= 100;
			result.robots2 += 250;
			Debug.Log("100 MK1s turned into 250 MK2s");
		}
		if (allocations.twoToThree) {
			result.robots2 -= 100;
			result.robots3 += 250;
			Debug.Log("100 MK2s turned into 250 MK3s");
		}

		// Passive gains
		result.oil += 10 * result.derricks;
		Debug.Log("Gained " + 10 * result.derricks + " oil from your derricks!");
		result.metal += 10 * result.mines;
		Debug.Log("Gained " + 10 * result.mines + " oil from your mines!");
		result.components += 10 * result.production;
		Debug.Log("Gained " + 10 * result.production + " oil from your production!");

		// Upkeep
		result.oil -= 5 * result.expansionLevel;
		Debug.Log("Lost " + 5 * result.expansionLevel " oil to upkeep!");

		if (result.oil < 0 || (result.robots1 < 1 && result.robots2 < 1 && result.robots3 < 1)) {
			Debug.Log ("You Lose!");
		}
		if (result.expansionLevel > 10) {
			Debug.Log("You Win!");
		}

		return result;
	}

}
