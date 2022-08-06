using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "InputData", menuName = "ScriptableObjects/Datas/InputData")]
public class InputData : ScriptableObject
{
    public float swerveSpeed;
    public float maxSwerveAmount;
    public float speed;
    public float clamp;

}

