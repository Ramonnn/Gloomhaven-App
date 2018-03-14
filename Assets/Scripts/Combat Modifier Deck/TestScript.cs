using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using SimpleJSON;

public class TestScript : MonoBehaviour
{

    public string monsters, bosses;
    private string monsterStatsFileName = "monsterstats.json";
    private JSONNode test;

    void Start()
    {
        LoadMonsterStats();
    }

    //I have to use SimpleJSON here. File is to big and complicated to manually adjust to Unity's liking. Please Upvote the C#/JSON dictionary conversion implementation on the Unity Support website -.-'
    private void LoadMonsterStats()
    {
        string filePath = Path.Combine(Application.streamingAssetsPath, monsterStatsFileName);
        if (File.Exists(filePath))
        {
            string dataAsJson = File.ReadAllText(filePath);
            test = JSON.Parse(dataAsJson);

            Debug.Log(test["monsters"]["Ancient Artillery"]["level"][1]["normal"]["health"]); // Deepest branch reference example.

            Debug.Log(GetMonster("Ancient Artillery", 1, "normal"));

        }
        else
        {
            Debug.LogError("Cannot load MonsterStats data!");
        }
    }

    JSONNode GetMonster(string name, int scenarioLevel, string EliteOrNorm) // to be continued...
    {
        foreach (KeyValuePair<string, JSONNode> monster in test["monsters"])
        {
            if (monster.Key == name)
            {
                if (EliteOrNorm == "normal")
                {
                    return test["monsters"][monster.Key]["level"][scenarioLevel]["normal"];
                }
                else
                {
                    return test["monsters"][monster.Key]["level"][scenarioLevel]["elite"];
                }
            }
        }
        return null;
    }
}

//    //Correct Coding below!! Please don't delete.

//    public partial struct MonsterStatistics
//    {
//        public Monsters Monsters { get; set; }
//        public Bosses Bosses { get; set; }
//    }

//    public partial struct Bosses
//    {
//        public Boss BanditCommander { get; set; }
//        public Boss TheBetrayer { get; set; }
//        public Boss CaptainOfTheGuard { get; set; }
//        public Boss TheColorless { get; set; }
//        public Boss DarkRider { get; set; }
//        public Boss ElderDrake { get; set; }
//        public Boss TheGloom { get; set; }
//        public Boss InoxBodyguard { get; set; }
//        public Boss Jekserah { get; set; }
//        public Boss MercilessOverseer { get; set; }
//        public Boss PrimeDemon { get; set; }
//        public Boss TheSightlessEye { get; set; }
//        public Boss WingedHorror { get; set; }
//    }

//    public partial struct Boss
//    {
//        public List<BossLevel> Level { get; set; }
//    }

//    public partial struct BossLevel
//    {
//        public long Level { get; set; }
//        public string Health { get; set; }
//        public long Move { get; set; }
//        public long Attack { get; set; }
//        public long Range { get; set; }
//        public List<string> Special1 { get; set; }
//        public List<string> Special2 { get; set; }
//        public List<string> Immunities { get; set; }
//        public string Notes { get; set; }
//    }

//    public partial struct Monsters
//    {
//        public Monster AncientArtillery { get; set; }
//        public Monster BanditArcher { get; set; }
//        public Monster BanditGuard { get; set; }
//        public Monster BlackImp { get; set; }
//        public Monster CaveBear { get; set; }
//        public Monster CityArcher { get; set; }
//        public Monster CityGuard { get; set; }
//        public Monster Cultist { get; set; }
//        public Monster DeepTerror { get; set; }
//        public Monster EarthDemon { get; set; }
//        public Monster FlameDemon { get; set; }
//        public Monster FrostDemon { get; set; }
//        public Monster ForestImp { get; set; }
//        public Monster GiantViper { get; set; }
//        public Monster HarrowerInfester { get; set; }
//        public Monster Hound { get; set; }
//        public Monster InoxArcher { get; set; }
//        public Monster InoxGuard { get; set; }
//        public Monster InoxShaman { get; set; }
//        public Monster LivingBones { get; set; }
//        public Monster LivingCorpse { get; set; }
//        public Monster LivingSpirit { get; set; }
//        public Monster Lurker { get; set; }
//        public Monster Ooze { get; set; }
//        public Monster NightDemon { get; set; }
//        public Monster RendingDrake { get; set; }
//        public Monster SavvasIcestorm { get; set; }
//        public Monster SavvasLavaflow { get; set; }
//        public Monster SpittingDrake { get; set; }
//        public Monster StoneGolem { get; set; }
//        public Monster SunDemon { get; set; }
//        public Monster VermlingScout { get; set; }
//        public Monster VermlingShaman { get; set; }
//        public Monster WindDemon { get; set; }
//    }

//    public partial struct Monster
//    {
//        public List<MonsterLevel> Level { get; set; }
//    }

//    public partial struct MonsterLevel
//    {
//        public long Level { get; set; }
//        public MonsterType Normal { get; set; }
//        public MonsterType Elite { get; set; }
//    }

//    public partial struct MonsterType
//    {
//        public long Health { get; set; }
//        public long Move { get; set; }
//        public long Attack { get; set; }
//        public long Range { get; set; }
//        public List<string> Attributes { get; set; }
//    }

//}
