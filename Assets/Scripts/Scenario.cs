public class Scenario
{

    public string enemy1, enemy2, enemy3, enemy4, enemy5, scenarioNumber;

    public Scenario(string scenario, string line1 = "", string line2 = "", string line3 = "", string line4 = "", string line5 = "")
    {
        scenarioNumber = scenario;
        enemy1 = line1;
        enemy2 = line2;
        enemy3 = line3;
        enemy4 = line4;
        enemy5 = line5;
    }

}
