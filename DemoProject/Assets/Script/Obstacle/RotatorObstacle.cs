using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RotatorObstacle : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("itmesi gerek");
            //animation.fall();
            //collision.transform.DOMoveX(((collision.transform.position.x - transform.position.x) * 1.5f) + collision.transform.position.x, 1.5f);
            //collision.transform.DOMoveZ(((collision.transform.position.z - transform.position.z) * 1.5f) + collision.transform.position.z, 1.5f);

            //çok saçmaaa
        }
    }

}
