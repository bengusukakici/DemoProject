using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.AI;

public class Obstacle : MonoBehaviour
{

    void Start()
    {
        
    }

    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        collision.gameObject.GetComponent<PlayerAnim>().fall();
        StopMove(collision);

    }
    public void StopMove(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerMovement>().enabled = false;
            collision.gameObject.GetComponent<MeshCollider>().enabled = false;
        }
        if (collision.gameObject.CompareTag("Opponent"))
        {
            //Debug.Log("çarpýþma");
            collision.gameObject.GetComponent<NavMesh>().enabled = false;
            collision.gameObject.GetComponent<NavMeshAgent>().speed = 0;
            collision.gameObject.GetComponent<MeshCollider>().enabled = false;
        }
    }
    

}
