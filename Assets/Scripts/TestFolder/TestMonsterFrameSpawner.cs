using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestMonsterFrameSpawner : MonoBehaviour
{

    public TestLoadMonsterData monsterData;
    public List<GameObject> enemyFrames = new List<GameObject>();
    public List<bool> endRound = new List<bool>();
    public Button roundButton;
    public int turnPassed = 0;
    public GameObject genericFrame, genericBossFrame, portrait, portraitSpawnContainer;

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
            monsterFrame.attributesElite.text = "";
            monsterFrame.attributesNormal.text = "";
            foreach (string line in monster.Value.currentElites.attributes)
            {
                monsterFrame.attributesElite.text = monsterFrame.attributesElite.text + " " + line + "\n";
            }
            foreach (string line in monster.Value.currentNormals.attributes)
            {
                monsterFrame.attributesNormal.text = monsterFrame.attributesNormal.text + line + "\n";
            }
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
            genericFrame.GetComponentInChildren<TestMonsterPanel>().gridDynamic = gameObject;

            monsterFrame.staticElite.GetComponentInChildren<Text>().text = monster.Value.currentElites.monsterHealth + "\n" +
                monster.Value.currentElites.monsterMove + "\n" + monster.Value.currentElites.monsterAttack + "\n" +
                monster.Value.currentElites.monsterRange;

            monsterFrame.staticNormal.GetComponentInChildren<Text>().text = monster.Value.currentNormals.monsterHealth + "\n" +
                monster.Value.currentNormals.monsterMove + "\n" + monster.Value.currentNormals.monsterAttack + "\n" +
                monster.Value.currentNormals.monsterRange;

            monsterFrame.abilityDeck = new List<TestDeck>(monster.Value.currentNormals.cardDeck);


            enemyFrames.Add(Instantiate(genericFrame, gameObject.transform));

        }
        foreach (KeyValuePair<string, TestCurrentBosses> boss in monsterData.currentBosses)
        {
            Debug.Log("Spawning Deck For " + boss.Key);
            TestBossFrame bossFrame = genericBossFrame.GetComponent<TestBossFrame>();
            bossFrame.monsterName.text = boss.Key;
            bossFrame.monsterImage.sprite = boss.Value.monsterImage;
            bossFrame.special1Boss.text = "Special 1: ";
            bossFrame.special2Boss.text = "Special 2: ";
            bossFrame.immunities.text = "<size=1>Immunities:</size> ";
            bossFrame.notes.text = "Notes: ";
            foreach (string line in boss.Value.monsterImmunities)
            {
                bossFrame.immunities.text = bossFrame.immunities.text + line + "\n";
            }
            foreach (string line in boss.Value.Special1)
            {
                bossFrame.special1Boss.text = bossFrame.special1Boss.text + line + "\n";
            }
            foreach (string line in boss.Value.Special2)
            {
                bossFrame.special2Boss.text = bossFrame.special2Boss.text + line + "\n";
            }

            if (boss.Value.monsterNotes != "")
            {
                bossFrame.notes.text = bossFrame.notes.text + "\n" + boss.Value.monsterNotes;
            }
            foreach (GameObject popupboss in bossFrame.monsterPopUp.GetComponent<TestAddMonsterPopUp>().popUpMonsters)
            {
                popupboss.GetComponent<Image>().sprite = boss.Value.monsterImage;
            }
            foreach (GameObject panelboss in bossFrame.monsterPanel.GetComponent<TestMonsterPanel>().panelBosses)
            {
                panelboss.GetComponent<TestBoss>().currentBoss = boss.Value;
            }
            genericBossFrame.GetComponentInChildren<TestMonsterPanel>().gridDynamic = gameObject;
            genericBossFrame.name = boss.Key;

            bossFrame.GetComponent<TestBossFrame>().staticBoss.text = boss.Value.monsterHealth + "\n" +
                boss.Value.monsterMove + "\n" + boss.Value.monsterAttack + "\n" +
                boss.Value.monsterRange;

            bossFrame.abilityDeck = new List<TestDeck>(boss.Value.cardDeck);

            enemyFrames.Add(Instantiate(genericBossFrame, gameObject.transform));
        }
        foreach (GameObject enemyFrame in enemyFrames)
        {
            portrait.GetComponent<OnOffPortraits>().enemyFrame = enemyFrame;
            if (enemyFrame.GetComponent<TestMonsterFrame>() != null)
            {
                portrait.GetComponent<OnOffPortraits>().deselectedPortrait.sprite = enemyFrame.GetComponent<TestMonsterFrame>().monsterImage.sprite;
                portrait.GetComponent<OnOffPortraits>().selectedPortrait.sprite = enemyFrame.GetComponent<TestMonsterFrame>().monsterImage.sprite;
            }
            else
            {
                portrait.GetComponent<OnOffPortraits>().deselectedPortrait.sprite = enemyFrame.GetComponent<TestBossFrame>().monsterImage.sprite;
                portrait.GetComponent<OnOffPortraits>().selectedPortrait.sprite = enemyFrame.GetComponent<TestBossFrame>().monsterImage.sprite;
            }
            Instantiate(portrait, portraitSpawnContainer.transform);
        }
    }


    public void SetInitiativeOrder()
    {
        enemyFrames.Sort((p1, p2) => p1.transform.GetChild(0).transform.GetComponentInChildren<TestAbilityDeckHandler>().currentCard.initiativeValue.CompareTo(p2.transform.GetChild(0).transform.GetComponentInChildren<TestAbilityDeckHandler>().currentCard.initiativeValue));

        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            foreach (GameObject enemy in enemyFrames)
            {
                if (enemy == gameObject.transform.GetChild(i).gameObject)
                {
                    gameObject.transform.GetChild(i).SetSiblingIndex(enemyFrames.IndexOf(enemy));
                }

            }
        }
    }

    public void RefreshEnemies()
    {
        int activeEnemies = 0;
        turnPassed = turnPassed + 1;
        foreach (GameObject enemy in enemyFrames)
        {
            if (enemy.activeSelf)
            {
                activeEnemies = activeEnemies + 1;
            }
        }
        if (turnPassed == activeEnemies)
        {
            roundButton.interactable = true;
            turnPassed = 0;
        }
    }
}
