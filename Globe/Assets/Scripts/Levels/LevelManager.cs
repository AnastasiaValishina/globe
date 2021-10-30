using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelManager", menuName = "LevelManager")]
public class LevelManager : ScriptableObject
{
    public Level[] levels;
}
