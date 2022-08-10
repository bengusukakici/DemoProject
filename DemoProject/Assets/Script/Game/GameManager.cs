using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;
    public GameObject player;
    public List<NavMesh> opponentScript;
    public bool isFinish;
    public bool isRotatingPlatform;
    PlayerMovement playerMovement;
    PlayerAnim animation;
    private void Awake()
    {
        opponentScript = new List<NavMesh>();
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

    public IEnumerator NavMeshControl()
    {
        yield return new WaitForSeconds(0.8f);
        transform.GetComponent<NavMeshAgent>().enabled = false;
        transform.GetComponent<NavMeshAgent>().enabled = true;
    }
}
