using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenarioCollection : MonoBehaviour
{

    public static List<Scenario> scenarioList = new List<Scenario>()
    {
     new Scenario("Scenario 1", "Ancient Artillery", "Bandit Archer"),
     new Scenario("Scenario 2", "Inox Archer", "Bandit Archer", "Ancient Artillery"),
     new Scenario("Scenario 3", "Ancient Artillery", "Bandit Archer", "Inox Archer", "Ancient Artillery")

    };

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }
}
