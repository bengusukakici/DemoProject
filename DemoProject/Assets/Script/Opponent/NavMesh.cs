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
    bool isFinish;
    public void Awake()
    {

    }
    void Start()
    {
        isFinish = false;
        GameManager.instance.opponentScript.Add(this);
        animation = GetComponent<PlayerAnim>();
        navMeshAgent = GetComponent<NavMeshAgent>();

        target = new Vector3(Random.Range(-3.5f, 3.5f), 0, transform.position.z);
        target.z += 30;

        StartCoroutine(NavMeshControl());
        animation.run();
    }

    void Update()
    {
        if (!isFinish)
        {
            navMeshAgent.SetDestination(target);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Finish"))
        {
            isFinish = true;
            animation.stoprun();
            navMeshAgent.enabled = false;
        }
    }
    public IEnumerator NavMeshControl()
    {
        yield return new WaitForSeconds(Random.Range(3.0f, 5.0f));
        target = new Vector3(Random.Range(-3.5f, 3.5f), 0, transform.position.z);
        target.z += 30;
        StartCoroutine(NavMeshControl());
    }

}
