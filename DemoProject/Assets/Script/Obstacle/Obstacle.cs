using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.AI;

public class Obstacle : MonoBehaviour
{
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
            collision.gameObject.GetComponent<NavMeshAgent>().updatePosition = false;
            collision.gameObject.GetComponent<MeshCollider>().enabled = false;
        }
    }
    

}
