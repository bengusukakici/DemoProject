using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PaintMove : MonoBehaviour
{
    private InputManager swerveInputSystem;
    [SerializeField] InputData _inputData;

    private void Start()
    {
        swerveInputSystem = GetComponent<InputManager>();
    }

    private void Update()
    {
        if (GameManager.instance.isPaintFinish) 
        {
            MovementAndSwerwe(); 
        }
    }

    void MovementAndSwerwe()
    {
        if (Input.GetMouseButton(0))
        {
            transform.DOMoveZ(124.4f, 0.5f);
        }
        if (Input.GetMouseButtonUp(0))
        {
            transform.DOMoveZ(120, 0.5f);
        }
        #region Swerwe Movement
        var pos = transform.localPosition;
        float swerveAmountX = Time.deltaTime * _inputData.swerveSpeed * swerveInputSystem.MoveFactorX;
        pos.x = Mathf.Clamp(transform.localPosition.x, -_inputData.clampX, _inputData.clampX);
        transform.localPosition = pos;
        transform.Translate(swerveAmountX, 0, 0);
        
        float swerveAmountY = Time.deltaTime * _inputData.swerveSpeed * swerveInputSystem.MoveFactorY;
        var posY = transform.localPosition;
        posY.y = Mathf.Clamp(transform.localPosition.y, 0.5f, 10);
        transform.localPosition = posY;
        transform.Translate(0, swerveAmountY, 0);
        #endregion
    }
}