using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;
using System.IO;

public class LoadMonsterData : MonoBehaviour {

    public string monsters, bosses; // need to make distinction between bosses and monsters. Bosses won't load now.
    private JSONNode MONSTERSTATS;
    public string selectedLevel;
    private string monsterStatsFileName = "monsterstats.json";

    public Sprite[] monsterImages;
    public Sprite currentMonsterImage;

    void Start () {
        LoadMonsterStats(gameObject.name);
    }

    private void LoadMonsterStats(string monstername) // Merge with JSONNODE?
    {
        string filePath = Path.Combine(Application.streamingAssetsPath, monsterStatsFileName);

        if (File.Exists(filePath))
        {
            string dataAsJson = File.ReadAllText(filePath);
            MONSTERSTATS = JSON.Parse(dataAsJson);

            //Debug.Log(test["monsters"]["Ancient Artillery"]["level"][1]["normal"]["health"]); // Deepest branch reference example.
            int monsterHealth = GetMonsterfromJSON(monstername, 1, "normal")["health"]; //level and monstertype will eventually be defined by the player.
            int monsterMove = GetMonsterfromJSON(monstername, 1, "normal")["move"];
            int monsterAttack = GetMonsterfromJSON(monstername, 1, "normal")["attack"];
            int monsterRange = GetMonsterfromJSON(monstername, 1, "normal")["range"];
            List<string> monsterAttri = new List<string>();
            for (int i = 0; i < GetMonsterfromJSON(monstername, 1, "normal")["attributes"].Count; i++)
            {
                monsterAttri.Add(GetMonsterfromJSON(monstername, 1, "normal")["attributes"][i].ToString());
            }

            foreach (Sprite image in monsterImages)
            {
                if (image.name == "Horz-" + gameObject.name)
                {
                    Debug.Log("found Image");
                    transform.GetChild(1).GetComponent<SpriteRenderer>().sprite = image; //Good alternative for "Find" method. Or use a game manager dictionary containing all instantiations? and search by key...
                    currentMonsterImage = image; //Image spawn in enemyframe

                }
            }
        }
        else
        {
            Debug.LogError("Cannot load MonsterStats data!");
        }
    }

    JSONNode GetMonsterfromJSON(string name, int scenarioLevel, string EliteOrNorm) // to be continued...
    {
        foreach (KeyValuePair<string, JSONNode> monster in MONSTERSTATS["monsters"])
        {
            if (monster.Key == name)
            {
                if (EliteOrNorm == "normal")
                {
                    return MONSTERSTATS["monsters"][monster.Key]["level"][scenarioLevel]["normal"];
                }
                else
                {
                    return MONSTERSTATS["monsters"][monster.Key]["level"][scenarioLevel]["elite"];
                }
            }
        }
        return null;
    }

}
