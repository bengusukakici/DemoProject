using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;
    public GameObject character;
    public List<NavMesh> opponentScript;
    public List<PlayerOrder> player;
    public List<float> distance;
    public bool isFinish;
    public bool isFinishLine;
    public bool isRotatingPlatform;
    PlayerMovement playerMovement;
    PlayerAnim animation;

    private void Awake()
    {
        opponentScript = new List<NavMesh>();
        player = new List<PlayerOrder>();
        distance = new List<float>();
        if (instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        isFinish = false;
        isFinishLine = false;
        isRotatingPlatform = false;
        playerMovement = character.GetComponent<PlayerMovement>();
        animation = character.GetComponent<PlayerAnim>();
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
