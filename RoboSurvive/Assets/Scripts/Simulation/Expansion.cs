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
        var meta = result.GetComponent<MetaModel>();
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

        meta.AddMessage("Scan show a " + p.name + " nearby.");
    }

    private void Expand(Task t, Transform result)
    {
        var places = GetComponentsInChildren<Place>();
        foreach(Place p in places) {
            if(t.internalName.Equals(p.name)) {
                var meta = result.GetComponent<MetaModel>();
                var robo = result.GetComponent<RobotModel>();
                var res = result.GetComponent<ResourceModel>();

                float odds = t.mk1 * chancePerMarkOne + t.mk2 * chancePerMarkTwo + t.mk3 * chancePerMarkThree;
                if (odds == 0)
                {
                    break;
                }

                float threshold = p.difficulty - odds;

                if (Random.value > threshold)
                {
                    // Success
                    if (p.story)
                    {
                        string story = sel.GetStory();
                        meta.SetFreedom(meta.GetFreedom() + 1);
                        meta.AddMessage("Beginning Artefact Scan: " + story);
                    }

                    if (!p.developement.Equals(""))
                    {
                        Task ta = result.gameObject.AddComponent<Task>();
                        ta.name = "Develop " + p.name;
                        ta.desc = p.desc;
                        ta.type = "develop";
                        ta.internalName = p.name;
                        ta.mk1 = ta.mk2 = ta.mk3 = 0;
                        meta.AddMessage("Found a developement site");
                    }

                    if (p.comp > 0)
                    {
                        res.SetComponents(res.GetComponents() + p.comp);
                        meta.AddMessage("Acquired " + p.comp + " components.");
                    }
                    if (p.met > 0)
                    {
                        res.SetMetal(res.GetMetal() + p.met);
                        meta.AddMessage("Acquired " + p.met + " metal.");
                    }
                    if (p.elec > 0)
                    {
                        res.SetElectricity(res.GetElectricity() + p.elec);
                        meta.AddMessage("Acquired " + p.elec + " electricity.");
                    }
                    if (p.oil > 0)
                    {
                        res.SetOil(res.GetOil() + p.oil);
                        meta.AddMessage("Acquired " + p.oil + " oil.");
                    }

                    if (p.mk1 > 0)
                    {
                        robo.SetMarkOne(robo.GetMarkOne() + p.mk1);
                        meta.AddMessage("Acquired " + p.oil + " Mark 1 robots.");
                    }
                    if (p.mk2 > 0)
                    {
                        robo.SetMarkTwo(robo.GetMarkTwo() + p.mk2);
                        meta.AddMessage("Acquired " + p.oil + " Mark 2 robots.");
                    }
                    if (p.mk3 > 0)
                    {
                        robo.SetMarkThree(robo.GetMarkThree() + p.mk3);
                        meta.AddMessage("Acquired " + p.oil + " Mark 3 robots.");
                    }

                    int newPlaces = Random.Range(1, maxPlaces);
                    for (int i = 0; i < newPlaces; i++)
                    {
                        AddNewPlace(result);
                    }

                    Destroy(t);

                    break;
                }
                else
                {
                    meta.AddMessage("You failed to capture the " + p.name + ".");
                    // Failure
                }
            }
        }
    }

    public override void RunSimulation(Transform preTurn, Transform afterTurn, Transform result)
    {
        bool none = true;
        foreach(Task t in afterTurn.GetComponents<Task>()) {
            if (t.type.Equals("expand"))
            {
                Expand(t, result);
                none = false;
            }
        }

        if (none)
        {
            AddNewPlace(result);
        }
    }
}
