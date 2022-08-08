using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;
    public GameObject player;
    public List<GameObject> opponent;
    public bool isFinish;
    public bool isRotatingPlatform;
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
        isFinish = false;
        isRotatingPlatform = false;
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
