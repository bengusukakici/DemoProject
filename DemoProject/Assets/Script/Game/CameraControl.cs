using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraControl : MonoBehaviour
{
    public static Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.isFinish)
        {
            animator.Play("Cam02");
        }
        if (!GameManager.instance.isFinish)
        {
            animator.Play("Cam01");
        }
    }
}
