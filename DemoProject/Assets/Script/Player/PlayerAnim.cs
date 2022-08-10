using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerAnim : MonoBehaviour
{
    [SerializeField] Animator animator;

    void Start()
    {
    }
    void Update()
    {

    }
    public void run()
    {
        animator.SetBool("isRun", true);
    }
    public void stoprun()
    {
        animator.SetBool("isRun", false);
    }
    public void fall()
    {
        animator.SetTrigger("isFall");
    }
    public void RestartMove()
    {
        if (gameObject.CompareTag("Player"))
        {
            Debug.Log("restart");
            transform.localPosition = new Vector3(0, 0, 0);
            gameObject.GetComponent<PlayerMovement>().enabled = true;
            gameObject.GetComponent<MeshCollider>().enabled = true;
        }
        if (gameObject.CompareTag("Opponent"))
        {
            Debug.Log("restart");
            transform.localPosition = new Vector3(Random.Range(-4,4), 0, 0);
            gameObject.GetComponent<NavMesh>().enabled = true;
            gameObject.GetComponent<MeshCollider>().enabled = true;
            gameObject.GetComponent<NavMeshAgent>().speed = 4; 
        }
    }
}
