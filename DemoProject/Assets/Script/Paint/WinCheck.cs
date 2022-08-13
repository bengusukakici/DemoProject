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
        if (fill.fillAmount >= 0.98f)
        {
            LevelManager.Instance.LevelComplete();
        }
        if(GameManager.instance.player.Count <= 1)
        {
            Debug.Log("Win");
            LevelManager.Instance.LevelComplete();
        }

    }
}
