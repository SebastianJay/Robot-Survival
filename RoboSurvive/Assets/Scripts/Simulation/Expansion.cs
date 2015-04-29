using UnityEngine;
using System.Collections;

public class Expansion : SimScript
{
    public float chancePerMarkOne, chancePerMarkTwo, chancePerMarkThree;
    public int maxPlaces;
    public StorySelector sel;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void AddNewPlace(Transform result)
    {
        var places = GetComponentsInChildren<Place>();
        float[] odds = new float[places.Length];

        float running = 0;
        for (int i = 0; i < places.Length; i++)
        {
            running += places[i].rarity;
            odds[i] = running;
        }

        float rand = Random.value * running;

        float comp = 0;
        int index = 0;
        while (comp < rand)
        {
            comp = odds[index];
            index++;
        }

        Place p = places[index];

        Task t = result.gameObject.AddComponent<Task>();
        t.name = "Explore " + p.name;
        t.desc = p.desc;
        t.type = "expand";
        t.internalName = p.name;
        t.mk1 = t.mk2 = t.mk3 = 0;
    }

    private void Expand(Task t, Transform result)
    {
        var places = GetComponentsInChildren<Place>();
        foreach(Place p in places) {
            if(t.internalName.Equals(p.name)) {
                float odds = t.mk1 * chancePerMarkOne + t.mk2 * chancePerMarkTwo + t.mk3 * chancePerMarkThree;

                float threshold = p.difficulty - odds;

                if (Random.value > threshold)
                {
                    // Success
                    if (p.story)
                    {
                        string story = sel.GetStory();
                        var meta = result.GetComponent<MetaModel>();
                        meta.SetFreedom(meta.GetFreedom() + 1);
                    }

                    if (!p.developement.Equals(""))
                    {

                    }

                    if (p.comp > 0 || p.met > 0 || p.elec > 0 || p.oil > 0)
                    {
                        var res = result.GetComponent<ResourceModel>();
                        res.SetComponents(res.GetComponents() + p.comp);
                        res.SetComponents(res.GetComponents() + p.comp);
                        res.SetElectricity(res.GetElectricity() + p.comp);
                        res.SetOil(res.GetOil() + p.oil);
                    }

                    if (p.mk1 > 0 || p.mk2 > 0 || p.mk3 > 0)
                    {
                        var robo = result.GetComponent<RobotModel>();
                        robo.SetMarkOne(robo.GetMarkOne() + p.mk1);
                        robo.SetMarkTwo(robo.GetMarkTwo() + p.mk2);
                        robo.SetMarkThree(robo.GetMarkThree() + p.mk3);
                    }

                    int newPlaces = Random.Range(0, maxPlaces);
                    for (int i = 0; i < newPlaces; i++)
                    {
                        AddNewPlace(result);
                    }
                }
                else
                {
                    // Failure
                }
            }
        }
    }

    public override void RunSimulation(Transform preTurn, Transform afterTurn, Transform result)
    {
        foreach(Task t in afterTurn.GetComponents<Task>()) {
            if (t.type.Equals("expand"))
            {
                Expand(t, result);
            }
        }
    }
}
