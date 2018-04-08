using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestMonsterFrameSpawner : MonoBehaviour
{

    public TestLoadMonsterData monsterData;
    public List<GameObject> enemyFrames = new List<GameObject>();

    public GameObject genericFrame;

    void OnEnable()
    {
        TestLoadMonsterData.UpdateScene += SpawnMonsterFrame;
    }

    void OnDisable()
    {
        TestLoadMonsterData.UpdateScene -= SpawnMonsterFrame;
    }

    void SpawnMonsterFrame()
    {
        foreach (KeyValuePair<string, TestLoadMonsterData.ElitesAndNormals> monster in monsterData.currentMonsters)
        {
            Debug.Log("Spawning Deck For " + monster.Key);
            TestMonsterFrame monsterFrame = genericFrame.GetComponent<TestMonsterFrame>();
            monsterFrame.monsterName.text = monster.Key;
            monsterFrame.monsterImage.sprite = monster.Value.currentElites.monsterImage;

            foreach (GameObject popupmonster in monsterFrame.monsterPopUp.GetComponent<TestAddMonsterPopUp>().popUpMonsters)
            {
                popupmonster.GetComponent<Image>().sprite = monster.Value.currentElites.monsterImage;
            }

            foreach (GameObject elite in monsterFrame.monsterPanel.GetComponent<TestMonsterPanel>().panelMonsters.Elites)
            {
                elite.GetComponent<TestMonster>().currentMonster = monster.Value.currentElites;
            }
            foreach (GameObject normal in monsterFrame.monsterPanel.GetComponent<TestMonsterPanel>().panelMonsters.Normals)
            {
                normal.GetComponent<TestMonster>().currentMonster = monster.Value.currentNormals;
            }

            genericFrame.name = monster.Key;

            monsterFrame.staticElite.GetComponentInChildren<Text>().text = monster.Value.currentElites.monsterHealth + "\n" +
                monster.Value.currentElites.monsterMove + "\n" + monster.Value.currentElites.monsterAttack + "\n" +
                monster.Value.currentElites.monsterRange;

            monsterFrame.staticNormal.GetComponentInChildren<Text>().text = monster.Value.currentNormals.monsterHealth + "\n" +
                monster.Value.currentNormals.monsterMove + "\n" + monster.Value.currentNormals.monsterAttack + "\n" +
                monster.Value.currentNormals.monsterRange;

            monsterFrame.GetComponentInChildren<TestRegex>().normalMonsterStats = new Dictionary<string, int>() {
                { "health", monster.Value.currentNormals.monsterHealth },
                { "attack", monster.Value.currentNormals.monsterHealth },
                { "range", monster.Value.currentNormals.monsterHealth },
                { "move", monster.Value.currentNormals.monsterHealth }
                //could add all the stats...
            };

            monsterFrame.GetComponentInChildren<TestRegex>().eliteMonsterStats = new Dictionary<string, int>() {
                { "health", monster.Value.currentElites.monsterHealth },
                { "attack", monster.Value.currentElites.monsterHealth },
                { "range", monster.Value.currentElites.monsterHealth },
                { "move", monster.Value.currentElites.monsterHealth }
                //could add all the stats...
            };

            monsterFrame.abilityDeck = new List<TestDeck>(monster.Value.currentNormals.cardDeck);

            enemyFrames.Add(Instantiate(genericFrame, gameObject.transform));

        }
    }
}
