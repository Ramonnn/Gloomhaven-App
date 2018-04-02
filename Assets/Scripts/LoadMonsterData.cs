//using System.Collections.Generic;
//using UnityEngine;
//using SimpleJSON;
//using System.IO;
//using UnityEngine.UI;

//public class LoadMonsterData : MonoBehaviour { //Script Load is now -50. Need to check execution order later.

//    public string monsters, bosses; // need to make distinction between bosses and monsters. Bosses won't load now.
//    private JSONNode MONSTERSTATS;
//    public string selectedLevel;
//    private string monsterStatsFileName = "monsterstats.json";

//    public Sprite[] monsterImages;
//    public Sprite currentMonsterImage;

//    public List<string> monsterAttri = new List<string>();
//    public List<string> genericStatsNormal = new List<string>();

//    public List<string> monsterAttriElite = new List<string>();
//    public List<string> genericStatsElite = new List<string>();

//    void Start () {
//        LoadMonsterStats(transform.name);
//    }

//    private void LoadMonsterStats(string monstername) // Merge with JSONNODE?
//    {
//        string filePath = Path.Combine(Application.streamingAssetsPath, monsterStatsFileName);

//        if (File.Exists(filePath))
//        {
//            string dataAsJson = File.ReadAllText(filePath);
//            MONSTERSTATS = JSON.Parse(dataAsJson);

//            int monsterHealth = GetMonsterfromJSON(monstername, 1, "normal")["health"]; //level and monstertype will eventually be defined by the player.
//            int monsterMove = GetMonsterfromJSON(monstername, 1, "normal")["move"];
//            int monsterAttack = GetMonsterfromJSON(monstername, 1, "normal")["attack"];
//            int monsterRange = GetMonsterfromJSON(monstername, 1, "normal")["range"];

//            for (int i = 0; i < GetMonsterfromJSON(monstername, 1, "normal")["attributes"].Count; i++)
//            {
//                monsterAttri.Add(GetMonsterfromJSON(monstername, 1, "normal")["attributes"][i].ToString());
//            }

//            genericStatsNormal.Add(monsterHealth.ToString());
//            genericStatsNormal.Add(monsterMove.ToString());
//            genericStatsNormal.Add(monsterAttack.ToString());
//            genericStatsNormal.Add(monsterRange.ToString());


//            int monsterHealthElite = GetMonsterfromJSON(monstername, 1, "Elite")["health"]; //level and monstertype will eventually be defined by the player.
//            int monsterMoveElite = GetMonsterfromJSON(monstername, 1, "Elite")["move"];
//            int monsterAttackElite = GetMonsterfromJSON(monstername, 1, "Elite")["attack"];
//            int monsterRangeElite = GetMonsterfromJSON(monstername, 1, "Elite")["range"];

//            for (int i = 0; i < GetMonsterfromJSON(monstername, 1, "Elite")["attributes"].Count; i++)
//            {
//                monsterAttri.Add(GetMonsterfromJSON(monstername, 1, "Elite")["attributes"][i].ToString());
//            }

//            genericStatsElite.Add(monsterHealthElite.ToString());
//            genericStatsElite.Add(monsterMoveElite.ToString());
//            genericStatsElite.Add(monsterAttackElite.ToString());
//            genericStatsElite.Add(monsterRangeElite.ToString());


//            foreach (Sprite image in monsterImages)
//            {
//                if (image.name == "Horz-" + transform.name)
//                {
//                    Debug.Log("found Image");
//                    currentMonsterImage = image; //Image spawn in enemyframe
//                }
//            }
//        }
//        else
//        {
//            Debug.LogError("Cannot load MonsterStats data!");
//        }
//    }

//    JSONNode GetMonsterfromJSON(string name, int scenarioLevel, string EliteOrNorm) // to be continued...
//    {
//        foreach (KeyValuePair<string, JSONNode> monster in MONSTERSTATS["monsters"])
//        {
//            if (monster.Key == name)
//            {
//                if (EliteOrNorm == "normal")
//                {
//                    return MONSTERSTATS["monsters"][monster.Key]["level"][scenarioLevel]["normal"];
//                }
//                else
//                {
//                    return MONSTERSTATS["monsters"][monster.Key]["level"][scenarioLevel]["elite"];
//                }
//            }
//        }
//        return null;
//    }

//}
