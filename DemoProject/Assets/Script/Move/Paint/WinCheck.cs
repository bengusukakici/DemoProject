using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinCheck : MonoBehaviour
{


    [SerializeField] private Image fill;

    void Start()
    {
    }


    void Update()
    {
        if (fill.fillAmount >= 0.97f)
        {
            Debug.Log("win");
            LevelManager.Instance.LevelComplete();
        }

    }
}
