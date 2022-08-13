using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using DG.Tweening;

public class NavMesh : MonoBehaviour
{
    private Vector3 target;
    NavMeshAgent navMeshAgent;
    public PlayerAnim animation;
    Vector3 current;
    public Rigidbody rb;
    bool isFinish;
    bool isRotator;
    bool isRotatingLeft;
    bool isRotatingRight;
    PlayerOrder playerOrder;
    void Start()
    {
        isFinish = false;
        isRotator = false;
        isRotatingLeft = false;
        isRotatingRight = false;
        GameManager.instance.opponentScript.Add(this);
        animation = GetComponent<PlayerAnim>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        rb = gameObject.GetComponent<Rigidbody>();
        playerOrder = GetComponent<PlayerOrder>();
        target = new Vector3(Random.Range(-3.5f, 3.5f), 0, transform.position.z);
        target.z += 30;

        StartCoroutine(NavMeshControl());
        animation.run();
    }

    void Update()
    {
        if (!isFinish)
        {
            Debug.Log("finish");
            navMeshAgent.SetDestination(target);
        }
        else StopCoroutine(NavMeshControl());
        if (isRotator)
        {
            StartCoroutine(NavMeshControlRotator());
            MovementRotator();
            target = new Vector3(Random.Range(-2f, 2f), 0, Random.Range(6f, 24f));
            navMeshAgent.SetDestination(target);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Fall"))
        {
            Fall();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("PaintFinish"))
        {
            isFinish = true;
            animation.stoprun();
            navMeshAgent.enabled = false;
        }
        if (collision.transform.CompareTag("RotatingFinish"))
        {
            isFinish = true;
            isRotator = true;
            animation.stoprun();
            //
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Right"))
        {
            isRotatingRight = true;
        }
        if (collision.gameObject.CompareTag("Left"))
        {
            isRotatingLeft = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Right"))
        {
            isRotatingRight = false;
        }
        if (collision.gameObject.CompareTag("Left"))
        {
            isRotatingLeft = false;
        }
    }
    public IEnumerator NavMeshControl()
    {

        yield return new WaitForSeconds(Random.Range(3.0f, 5.0f));
        target = new Vector3(Random.Range(-3.5f, 3.5f), 0, transform.position.z);
        target.z += 30;
        StartCoroutine(NavMeshControl());
    }
    public IEnumerator NavMeshControlRotator()
    {
        yield return new WaitForSeconds(Random.Range(8.0f, 10.0f));
        target = new Vector3(Random.Range(-2f, 2f), 0, Random.Range(6f, 24f));
        rb.constraints = RigidbodyConstraints.FreezeRotation;
        StartCoroutine(NavMeshControlRotator());
    }
    void MovementRotator()
    {
        if (isRotatingRight)
        {
            rb.MovePosition(transform.position + Vector3.right * 10f * Time.deltaTime);
        }
        if (isRotatingLeft)
        {
            rb.MovePosition(transform.position + Vector3.right * -10f * Time.deltaTime);
        }
    }
    void Fall()
    {
        if (transform.position.x > 0)
        {
            transform.DOMoveX(6f, 0.5f);
        }
        else
        {
            transform.DOMoveX(-6f, 0.5f);
        }
        isRotator = false;
        transform.DOMoveY(-5f, 0.7f).OnComplete(() =>{
            StopCoroutine(NavMeshControlRotator());
            navMeshAgent.enabled = false;
            GameManager.instance.player.Remove(playerOrder);
            gameObject.SetActive(false);
        });
        
    }

}
