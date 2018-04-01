using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;
using System.IO;

public class TestLoadMonsterData : MonoBehaviour
{ //Script Load is now -50. Need to check execution order later.

    private JSONNode MONSTERSTATS, DECKS;
    private string monsterStatsFileName = "monsterstats.json";
    private string combinationsFileName = "monsters.json";
    private string decksFileName = "decks.json";
    public Monsters loadedMonsters;
    public ElitesAndNormals elitesAndNormals;
    private List<string> scenarioMonsters;
    private List<TestDeck> currentMonsterDeck;
    private TestDeck currentCard;

    public Dictionary<string, ElitesAndNormals> currentMonsters = new Dictionary<string, ElitesAndNormals>(); // Dicts with all currentScenario Enemy Info.
    public Dictionary<string, TestCurrentBosses> currentBosses = new Dictionary<string, TestCurrentBosses>(); // Dicts with all currentScenario Enemy Info.

    public Sprite[] monsterImages;
    public Sprite currentMonsterImage;

    private List<string> normalAttri;
    private List<string> eliteAttri;
    private List<string> cardLines;

    private bool monsterFound;

    [System.Serializable]
    public struct ElitesAndNormals
    {
        public TestCurrentMonsters currentNormals;
        public TestCurrentMonsters currentElites;
    }

    [System.Serializable]
    public struct Monsters
    {
        public List<Combination> monsters;
    }

    [System.Serializable]
    public struct Combination
    {
        public string name;
        public string monsterclass;
    }
    private void Awake()
    {
        LoadJSONFiles();
    }

    void Start()
    {
        scenarioMonsters = GetComponent<TestLoadScenario>().scenarioMonsters;
        LoadCombinations(scenarioMonsters);
    }

    void LoadJSONFiles()
    {
        string combinationsPath = Path.Combine(Application.streamingAssetsPath, combinationsFileName);
        string monsterPath = Path.Combine(Application.streamingAssetsPath, monsterStatsFileName);

        if (File.Exists(combinationsPath))
        {
            string dataAsJson = File.ReadAllText(combinationsPath);
            loadedMonsters = JsonUtility.FromJson<Monsters>(dataAsJson);
        }
        else
        {
            Debug.LogError("Cannot load Combination data!");
        }

        if (File.Exists(monsterPath))
        {
            string monstersAsJson = File.ReadAllText(monsterPath);
            MONSTERSTATS = JSON.Parse(monstersAsJson);
        }

        else
        {
            Debug.LogError("Cannot load MonsterStats data!");
        }
        string deckPath = Path.Combine(Application.streamingAssetsPath, decksFileName);
        if (File.Exists(deckPath))
        {
            string deckAsJson = File.ReadAllText(deckPath);
            DECKS = JSON.Parse(deckAsJson);
        }
        else
        {
            Debug.LogError("Cannot load Deck data!");
        }
    }

    private void LoadCombinations(List<string> scenariomonsters)
    {
        foreach (Combination combo in loadedMonsters.monsters)
        {
            for (int i = 0; i < scenariomonsters.Count; i++)
            {
                if (combo.name == scenariomonsters[i])
                {
                    monsterFound = false;
                    LoadMonsterStats(combo.name, combo.monsterclass);
                }
            }
        }
    }

    private void LoadMonsterStats(string monstername, string monsterclass)
    {
        foreach (Sprite image in monsterImages)
        {
            if (image.name == "Horz-" + monstername)
            {
                Debug.Log("found Image");
                currentMonsterImage = image;
            }
        }

        foreach (JSONNode monsterdeck in DECKS["decks"])
        {
            if (monsterdeck["monsterclass"] == monsterclass)
            {
                cardLines = new List<string>();
                currentMonsterDeck = new List<TestDeck>();

                for (int i = 0; i < monsterdeck["cards"].Count; i++)
                {
                    for (int x = 0; x < monsterdeck["cards"][i]["cardlines"].Count; x++)
                    {
                        cardLines.Add(monsterdeck["cards"][i]["cardlines"][x]);
                    }
                    currentCard = new TestDeck(monsterclass,
                        monsterdeck["cards"][i]["initiative"],
                        monsterdeck["cards"][i]["shuffle"], cardLines);

                    currentMonsterDeck.Add(currentCard);
                }
            }
        }

        foreach (KeyValuePair<string, JSONNode> monster in MONSTERSTATS["monsters"])
        {
            if (monster.Key == monstername)
            {
                monsterFound = true;
                normalAttri = new List<string>();
                eliteAttri = new List<string>();
                ElitesAndNormals elitesAndNormals = new ElitesAndNormals();

                for (int i = 0; i < monster.Value["level"][PlayerPrefs.GetString("ChosenLevel")]["normal"]["attributes"].Count; i++)
                {
                    normalAttri.Add(monster.Value["level"][PlayerPrefs.GetString("ChosenLevel")]["normal"]["attributes"][i]);
                }
                TestCurrentMonsters currentNormals = new TestCurrentMonsters(monstername,
                    currentMonsterImage,
                    "Normal", PlayerPrefs.GetInt("ChosenLevel"),
                    monster.Value["level"][PlayerPrefs.GetInt("ChosenLevel")]["normal"]["health"],
                    monster.Value["level"][PlayerPrefs.GetInt("ChosenLevel")]["normal"]["move"],
                    monster.Value["level"][PlayerPrefs.GetInt("ChosenLevel")]["normal"]["attack"],
                    monster.Value["level"][PlayerPrefs.GetInt("ChosenLevel")]["normal"]["range"], normalAttri, currentMonsterDeck);

                elitesAndNormals.currentNormals = currentNormals;

                for (int i = 0; i < monster.Value["level"][PlayerPrefs.GetString("ChosenLevel")]["elite"]["attributes"].Count; i++)
                {
                    eliteAttri.Add(monster.Value["level"][PlayerPrefs.GetString("ChosenLevel")]["elite"]["attributes"][i]);
                }
                TestCurrentMonsters currentElites = new TestCurrentMonsters(monstername,
                    currentMonsterImage,
                    "Elite", PlayerPrefs.GetInt("ChosenLevel"),
                    monster.Value["level"][PlayerPrefs.GetInt("ChosenLevel")]["elite"]["health"],
                    monster.Value["level"][PlayerPrefs.GetInt("ChosenLevel")]["elite"]["move"],
                    monster.Value["level"][PlayerPrefs.GetInt("ChosenLevel")]["elite"]["attack"],
                    monster.Value["level"][PlayerPrefs.GetInt("ChosenLevel")]["elite"]["range"], eliteAttri, currentMonsterDeck);

                elitesAndNormals.currentElites = currentElites;

                currentMonsters.Add(monstername, elitesAndNormals);
            }
            if (!monsterFound)
            {
                foreach (KeyValuePair<string, JSONNode> boss in MONSTERSTATS["bosses"])
                {
                    if (boss.Key == monstername)
                    {
                        monsterFound = true;
                        TestCurrentBosses currentBoss = new TestCurrentBosses(monstername,
                            currentMonsterImage,
                            PlayerPrefs.GetInt("ChosenLevel"),
                            boss.Value["level"]["level"][PlayerPrefs.GetString("ChosenLevel")]["health"],
                            boss.Value["level"][boss.Key]["level"][PlayerPrefs.GetString("ChosenLevel")]["move"],
                            boss.Value["level"][boss.Key]["level"][PlayerPrefs.GetString("ChosenLevel")]["attack"],
                            boss.Value["level"][boss.Key]["level"][PlayerPrefs.GetString("ChosenLevel")]["range"],
                            boss.Value["level"][boss.Key]["level"][PlayerPrefs.GetString("ChosenLevel")]["special1"],
                            boss.Value["level"][boss.Key]["level"][PlayerPrefs.GetString("ChosenLevel")]["special2"],
                            boss.Value["level"][boss.Key]["level"][PlayerPrefs.GetString("ChosenLevel")]["notes"], currentMonsterDeck);

                        currentBosses.Add(monstername, currentBoss);
                    }
                }

            }
        }
    }
}


