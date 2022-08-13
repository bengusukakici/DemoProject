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
    public bool isPaintFinish;
    public bool isFinishLine;
    public bool isFinish;
    public bool navmesh;
    public int order;
    PlayerMovement playerMovement;
    PlayerAnim animation;

    private void Awake()
    {
        opponentScript = new List<NavMesh>();
        distance = new List<float>();
        player = new List<PlayerOrder>();
        if (instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        isPaintFinish = false;
        isFinishLine = false;
        isFinish = false;
        navmesh = false;
        playerMovement = character.GetComponent<PlayerMovement>();
        animation = character.GetComponent<PlayerAnim>();
        
    }

    void Update()
    {
        if (isPaintFinish)
        {
            playerMovement.enabled = false;
            animation.stoprun();
        }
        UIManager.Instance.Order();
    }
}
