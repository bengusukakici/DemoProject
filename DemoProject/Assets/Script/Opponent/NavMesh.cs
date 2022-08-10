using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMesh : MonoBehaviour
{
    private Vector3 target;
    NavMeshAgent navMeshAgent;
    public PlayerAnim animation;
    Vector3 current;
    public void Awake()
    {
    }
    void Start()
    {
        GameManager.instance.opponentScript.Add(this);
        animation = GetComponent<PlayerAnim>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        target = new Vector3(Random.Range(-3.5f,3.5f),0,transform.position.z);
        target.z += 30f;
    }

    void Update()
    {
        animation.run();
        navMeshAgent.SetDestination(target);
        if(target.z == transform.position.z)
        {
            target = new Vector3(Random.Range(-3.5f, 3.5f), 0, transform.position.z);
            target.z += 30;
        }
        Debug.Log(target.z);
    }
    public void NavMeshControl()
    {

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Finish"))
        {
            Debug.Log("çarpýþma");
            animation.stoprun();
            navMeshAgent.Stop();
        }
    }

}
