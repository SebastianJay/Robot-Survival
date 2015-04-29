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
            if (rand < mk1Odds && robo.GetMarkOne() > 0)
            {
                robo.SetMarkOne(robo.GetMarkOne() - 1);
            }
            else if (rand < mk1Odds + mk2Odds && robo.GetMarkTwo() > 0 )
            {
                robo.SetMarkTwo(robo.GetMarkTwo() - 1);
            }
            else if (robo.GetMarkThree() > 0)
            {
                robo.SetMarkThree(robo.GetMarkThree() - 1);
            }
        }

        meta.AddMessage(effectiveDanger + " robots were destroyed.");
    }

    public override void RunSimulation(Transform preTurn, Transform afterTurn, Transform result)
    {
        float rand = Random.value;

        var meta = result.GetComponent<MetaModel>();
        var res = result.GetComponent<ResourceModel>();
        var oldres = afterTurn.GetComponent<ResourceModel>();

        if (rand < dustStorm)
        {
            meta.AddMessage("A large dust storm is currently sweeping through the local area, disabling component production capability.");
            res.SetComponents(oldres.GetComponents());
        }
        else if (rand < dustStorm + earthquake)
        {
            meta.AddMessage("An earthquake in the local area has caused a mine collapse, preventing metal production until the entrance has been cleared.");
            res.SetMetal(oldres.GetMetal());
        }
        else if (rand < dustStorm + earthquake + fire)
        {
            meta.AddMessage("There has been an explosion at the oil fields, disabling oil production until the fire is controlled.");
            res.SetOil(oldres.GetOil());
        }
        else if (rand < dustStorm + earthquake + fire + rogueBots)
        {
            meta.AddMessage("A group of unintegrated units is raiding unit facilities in what appears to be an attempt to expand their own control.");
            Attack(rogueBotDanger, result);
        }
        else if (rand < dustStorm + earthquake + fire + rogueBots + wildlife)
        {
            meta.AddMessage("A group of dangerous local wild-life is undergoing migration, attacking operational units along the way.");
            Attack(wildlifeDanger, result);
        }
    }
}
