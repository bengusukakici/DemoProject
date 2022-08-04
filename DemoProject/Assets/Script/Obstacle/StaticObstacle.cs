using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class StaticObstacle : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //StartCoroutine(Move(other));
            Debug.Log("hadi bakalýmm");
            //Vector3 direction = Vector3.right * Input.GetAxis("Horizontal");
            //other.GetComponent<Rigidbody>().MovePosition(transform.position + (direction * 5 * Time.deltaTime));
            PlayerMovement.instance.rb.MovePosition(transform.position + Vector3.forward * 5 * Time.deltaTime);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //StopAllCoroutines();
        }
    }

    IEnumerator Move(Collider other)
    {
        other.transform.DOMoveX(other.transform.position.x + 9f, 9f);
        yield return new WaitForSeconds(1f);
    }
}
