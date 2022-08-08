using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMesh : MonoBehaviour
{
    private Vector3 target;
    NavMeshAgent navMeshAgent;
    public PlayerAnim animation;
    // Start is called before the first frame update
    void Start()
    {
        animation = GetComponent<PlayerAnim>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        target = new Vector3(Random.Range(-4,4),0,transform.position.z);
        target.z += 30f;
    }

    // Update is called once per frame
    void Update()
    {
        animation.run();
        navMeshAgent.SetDestination(target);
        if(target.z == transform.position.z)
        {
            target = new Vector3(Random.Range(-4, 4), 0, transform.position.z);
            target.z += 30;
        }
    }
}
