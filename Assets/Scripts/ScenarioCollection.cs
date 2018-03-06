using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenarioCollection : MonoBehaviour
{
    public Dictionary<string, string[]> scenarios = new Dictionary<string, string[]>();

    // Use this for initialization
    void Awake()
    {
        scenarios.Add("Scenario 1", new string[] { "Ancient Artillery", "Bandit Archer" });
        scenarios.Add("Scenario 2", new string[] { "Inox Archer", "Bandit Archer", "Ancient Artillery" });
        scenarios.Add("Scenario 3", new string[] { "Ancient Artillery", "Bandit Archer", "Inox Archer", "Ancient Artillery" });
    }
}
