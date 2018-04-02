using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMonsterPanel : MonoBehaviour {

    public Types panelMonsters;
}

[System.Serializable]
public struct Types
{
    public List<GameObject> Normals;
    public List<GameObject> Elites;
}