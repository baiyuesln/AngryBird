using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class TestScriptObject : ScriptableObject
{
    public string name;
    public int level;

    public int[] levelData;
    public int[,] mapData;
}
