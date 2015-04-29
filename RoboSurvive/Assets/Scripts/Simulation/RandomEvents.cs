using UnityEngine;
using System.Collections;

public class RandomEvents : SimScript
{
    public float dustStorm, earthquake, fire, rogueBots, wildlife;
    public float rogueBotDanger, wildlifeDanger, mk1Odds, mk2Odds;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void Attack(float danger, Transform result)
    {
        var meta = result.GetComponent<MetaModel>();
        int effectiveDanger = (int) (danger * (1 - meta.fortification) * (Random.value + .5));

        for (int i = 0; i < effectiveDanger; i++)
        {
            float rand = Random.value;

            var robo = result.GetComponent<RobotModel>();
            if (rand < mk1Odds)
            {
                robo.SetMarkOne(robo.GetMarkOne() - 1);
            }
            else if (rand < mk1Odds + mk2Odds)
            {
                robo.SetMarkTwo(robo.GetMarkTwo() - 1);
            }
            else
            {
                robo.SetMarkThree(robo.GetMarkThree() - 1);
            }
        }
    }

    public override void RunSimulation(Transform preTurn, Transform afterTurn, Transform result)
    {
        float rand = Random.value;

        var res = result.GetComponent<ResourceModel>();
        var oldres = afterTurn.GetComponent<ResourceModel>();

        if (rand < dustStorm)
        {
            res.SetComponents(oldres.GetComponents());
        }
        else if (rand < dustStorm + earthquake)
        {
            res.SetMetal(oldres.GetMetal());
        }
        else if (rand < dustStorm + earthquake + fire)
        {
            res.SetOil(oldres.GetOil());
        }
        else if (rand < dustStorm + earthquake + fire + rogueBots)
        {
            Attack(rogueBotDanger, result);
        }
        else if (rand < dustStorm + earthquake + fire + rogueBots + wildlife)
        {
            Attack(wildlifeDanger, result);
        }
    }
}
