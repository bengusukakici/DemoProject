using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

}
