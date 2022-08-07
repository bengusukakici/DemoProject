using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpponentMove : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.opponent.Add(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
