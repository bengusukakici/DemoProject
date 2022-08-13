using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderManager : MonoBehaviour
{
    void Start()
    {
        InvokeRepeating("PlayerOrder", 0.00f, 0.001f);
       
    }
    void Update()
    {
        InvokeRepeating("UpdatePlayerOrder", 0.00f, 0.001f);
        DistanceSort();
        
    }
    public void PlayerOrder()
    {
        for (int i = 0; i < GameManager.instance.player.Count; i++)
        {
            GameManager.instance.distance.Add(GameManager.instance.player[i].GetDistance());
        }

        CancelInvoke("PlayerOrder");
    }
    public void UpdatePlayerOrder()
    {
        for (int i = 0; i < GameManager.instance.player.Count; i++)
        {
            GameManager.instance.distance[i] = GameManager.instance.player[i].GetDistance();
        }

        CancelInvoke("UpdatePlayerOrder");
    }
    public void DistanceSort()
    {
        GameManager.instance.distance.Sort();
    }
}
