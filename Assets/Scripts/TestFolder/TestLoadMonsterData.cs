using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;
using System.IO;

public class TestLoadMonsterData : MonoBehaviour
{ //Script Load is now -50. Need to check execution order later.

    private JSONNode MONSTERSTATS, DECKS;
    private string monsterStatsFileName = "testmonsterstats.json";
    private string combinationsFileName = "monsters.json";
    //private string decksFileName = "decks.json";
    private string decksFileName = "testdecks.json";
    public Monsters loadedMonsters;
    public ElitesAndNormals elitesAndNormals;
    private List<string> scenarioMonsters;

    public TestDeck currentCard;
    public TestCurrentMonsters Normals;
    public TestCurrentMonsters Elites;
    public TestCurrentBosses Bosses;
    public List<TestDeck> currentMonsterDeck;


    public Dictionary<string, ElitesAndNormals> currentMonsters = new Dictionary<string, ElitesAndNormals>(); // Dicts with all currentScenario Enemy Info.
    public Dictionary<string, TestCurrentBosses> currentBosses = new Dictionary<string, TestCurrentBosses>(); // Dicts with all currentScenario Enemy Info.

    public Sprite[] monsterImages;
    private Sprite currentMonsterImage;
    public Sprite[] bossImages;

    private List<string> normalAttri;
    private List<string> eliteAttri;
    private List<string> bossImmu;
    private List<string> bossSpecial1;
    private List<string> bossSpecial2;
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

    public delegate void SceneListener();
    public static event SceneListener UpdateScene;

    public void SceneUpdater() // execute this method to updatescene (so whenever anything changes in the scene).
    {
        if (UpdateScene != null)
        {
            UpdateScene();
        }
    }

    void Start()
    {
        scenarioMonsters = GetComponent<TestLoadScenario>().scenarioMonsters;
        LoadCombinations(scenarioMonsters);
        SceneUpdater();
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
                currentMonsterImage = image;
            }
        }
        foreach (Sprite image in bossImages)
        {
            if (image.name == monstername)
            {
                currentMonsterImage = image;
            }
        }

        foreach (JSONNode monsterdeck in DECKS["decks"])
        {
            if (monsterdeck["monsterclass"] == monsterclass)
            {
                currentMonsterDeck = new List<TestDeck>();

                for (int i = 0; i < monsterdeck["cards"].Count; i++)
                {
                    cardLines = new List<string>();
                    for (int x = 0; x < monsterdeck["cards"][i]["cardlines"].Count; x++)
                    {
                        cardLines.Add(monsterdeck["cards"][i]["cardlines"][x]);
                    }
                    currentCard = new TestDeck
                    {
                        monsterName = monsterclass,
                        initiativeValue = monsterdeck["cards"][i]["initiative"],
                        shuffleBool = monsterdeck["cards"][i]["shuffle"],
                        modifierLines = cardLines
                    };


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

                for (int i = 0; i < monster.Value["level"][PlayerPrefs.GetInt("ChosenLevel")]["normal"]["attributes"].Count; i++)
                {
                    normalAttri.Add(monster.Value["level"][PlayerPrefs.GetInt("ChosenLevel")]["normal"]["attributes"][i]);
                }

                Normals = new TestCurrentMonsters
                {
                    monsterName = monstername,
                    monsterImage = currentMonsterImage,
                    enemyType = "normal",
                    monsterLevel = PlayerPrefs.GetInt("ChosenLevel"),
                    monsterHealth = monster.Value["level"][PlayerPrefs.GetInt("ChosenLevel")]["normal"]["health"],
                    monsterMove = monster.Value["level"][PlayerPrefs.GetInt("ChosenLevel")]["normal"]["move"],
                    monsterAttack = monster.Value["level"][PlayerPrefs.GetInt("ChosenLevel")]["normal"]["attack"],
                    monsterRange = monster.Value["level"][PlayerPrefs.GetInt("ChosenLevel")]["normal"]["range"],
                    attributes = normalAttri,
                    cardDeck = currentMonsterDeck
                };
                elitesAndNormals.currentNormals = Normals;

                for (int i = 0; i < monster.Value["level"][PlayerPrefs.GetInt("ChosenLevel")]["elite"]["attributes"].Count; i++)
                {
                    eliteAttri.Add(monster.Value["level"][PlayerPrefs.GetInt("ChosenLevel")]["elite"]["attributes"][i]);
                }
                Elites = new TestCurrentMonsters
                {
                    monsterName = monstername,
                    monsterImage = currentMonsterImage,
                    enemyType = "elites",
                    monsterLevel = PlayerPrefs.GetInt("ChosenLevel"),
                    monsterHealth = monster.Value["level"][PlayerPrefs.GetInt("ChosenLevel")]["elite"]["health"],
                    monsterMove = monster.Value["level"][PlayerPrefs.GetInt("ChosenLevel")]["elite"]["move"],
                    monsterAttack = monster.Value["level"][PlayerPrefs.GetInt("ChosenLevel")]["elite"]["attack"],
                    monsterRange = monster.Value["level"][PlayerPrefs.GetInt("ChosenLevel")]["elite"]["range"],
                    attributes = eliteAttri,
                    cardDeck = currentMonsterDeck
                };

                elitesAndNormals.currentElites = Elites;

                currentMonsters.Add(monstername, elitesAndNormals);
            }
            if (!monsterFound)
            {
                foreach (KeyValuePair<string, JSONNode> boss in MONSTERSTATS["bosses"])
                {
                    if (boss.Key == monstername)
                    {
                        monsterFound = true;
                        bossImmu = new List<string>();
                        bossSpecial1 = new List<string>();
                        bossSpecial2 = new List<string>();
                        for (int i = 0; i < boss.Value["level"][PlayerPrefs.GetInt("ChosenLevel")]["immunities"].Count; i++)
                        {
                            bossImmu.Add(boss.Value["level"][PlayerPrefs.GetInt("ChosenLevel")]["immunities"][i]);
                        }
                        for (int i = 0; i < boss.Value["level"][PlayerPrefs.GetInt("ChosenLevel")]["special1"].Count; i++)
                        {
                            bossSpecial1.Add(boss.Value["level"][PlayerPrefs.GetInt("ChosenLevel")]["special1"][i]);
                        }
                        for (int i = 0; i < boss.Value["level"][PlayerPrefs.GetInt("ChosenLevel")]["special2"].Count; i++)
                        {
                            bossSpecial2.Add(boss.Value["level"][PlayerPrefs.GetInt("ChosenLevel")]["special2"][i]);
                        }
                        Bosses = new TestCurrentBosses
                        {
                            monsterName = monstername,
                            monsterImage = currentMonsterImage,
                            monsterLevel = PlayerPrefs.GetInt("ChosenLevel"),
                            monsterHealth = boss.Value["level"][PlayerPrefs.GetInt("ChosenLevel")]["health"],
                            monsterMove = boss.Value["level"][PlayerPrefs.GetInt("ChosenLevel")]["move"],
                            monsterAttack = boss.Value["level"][PlayerPrefs.GetInt("ChosenLevel")]["attack"],
                            monsterRange = boss.Value["level"][PlayerPrefs.GetInt("ChosenLevel")]["range"],
                            Special1 = bossSpecial1,
                            Special2 = bossSpecial2,
                            monsterImmunities = bossImmu,
                            monsterNotes = boss.Value["level"][PlayerPrefs.GetInt("ChosenLevel")]["notes"],
                            cardDeck = currentMonsterDeck
                        };

                        currentBosses.Add(monstername, Bosses);
                    }
                }

            }
        }
    }
}


