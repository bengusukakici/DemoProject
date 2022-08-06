using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintInputManager : MonoBehaviour
{
    private float _lastFrameFingerPositionX;
    private float _moveFactorX;
    public float MoveFactorX => _moveFactorX;


    private float _lastFrameFingerPositionY;
    private float _moveFactorY;
    public float MoveFactorY => _moveFactorY;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _lastFrameFingerPositionX = Input.mousePosition.x;
            _lastFrameFingerPositionY = Input.mousePosition.y;
        }
        else if (Input.GetMouseButton(0))
        {
            _moveFactorX = Input.mousePosition.x - _lastFrameFingerPositionX;
            _lastFrameFingerPositionX = Input.mousePosition.x;
            _moveFactorY = Input.mousePosition.y - _lastFrameFingerPositionY;
            _lastFrameFingerPositionY = Input.mousePosition.y;

        }
        else if (Input.GetMouseButtonUp(0))
        {
            _moveFactorX = 0f;
            _moveFactorY = 0f;
        }
    }
}