using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Level Settings")]
public class LevelSettings : ScriptableObject
{
    [Header("Level Settings")]
    public int levelCount = 0;
    public List<int> LevelArray;

}
