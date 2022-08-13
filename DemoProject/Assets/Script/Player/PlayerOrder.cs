using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerOrder : MonoBehaviour
{
    [SerializeField] Transform playerTransform;
    [SerializeField] Transform EndLineTransform;

    private Vector3 endLinePosition;

    private void Awake()
    {
        playerTransform = gameObject.transform;
        endLinePosition = EndLineTransform.position;
    }
    void Start()
    {
        GameManager.instance.player.Add(this);
    }
    public float GetDistance()
    {
        return (endLinePosition - playerTransform.position).sqrMagnitude;
    }

}
