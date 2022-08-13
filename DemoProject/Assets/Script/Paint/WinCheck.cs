using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinCheck : MonoBehaviour
{
    int orderCount;

    [SerializeField] private Image fill;

    void Start()
    {
    }


    void Update()
    {
        if (fill.fillAmount >= 0.99f)
        {
            LevelManager.Instance.LevelComplete();
        }
        orderCount = GameManager.instance.player.Count + GameManager.instance.order;
        if (orderCount <= 1 && GameManager.instance.navmesh)
        {
            LevelManager.Instance.LevelComplete();
        }

    }
}
