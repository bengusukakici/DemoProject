using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;
    public GameObject player;
    public bool isFinish;
    PlayerMovement playerMovement;
    PlayerAnim animation;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        playerMovement = player.GetComponent<PlayerMovement>();
        animation = player.GetComponent<PlayerAnim>();
    }

    void Update()
    {
        if (isFinish)
        {
            playerMovement.enabled = false;
            animation.stoprun();
        }
    }
}
