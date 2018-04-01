using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCurrentScenario
{

    public string scenarioName;
    public List<string> enemyNames;

    public TestCurrentScenario(string scenarioname, List<string> enemynames)
    {
        scenarioName = scenarioname;
        enemyNames = enemynames;
    }
}
