using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintMove : MonoBehaviour
{
    private PaintInputManager swerveInputSystem;
    [SerializeField] PaintInputData _inputData;

    private void Start()
    {
        swerveInputSystem = GetComponent<PaintInputManager>();
    }

    private void Update()
    {
        if (GameManager.instance.isFinish) 
        {
            Debug.Log("finish");
            MovementAndSwerwe(); 
        }
        
    }

    void MovementAndSwerwe()
    {
        #region Swerwe Movement
        var pos = transform.localPosition;
        float swerveAmount = Time.deltaTime * _inputData.swerveSpeed * swerveInputSystem.MoveFactorX;
        pos.x = Mathf.Clamp(transform.localPosition.x, -3.5f, 3.5f);
        transform.localPosition = pos;
        transform.Translate(swerveAmount, 0, 0);
        
        float swerveAmountY = Time.deltaTime * _inputData.swerveSpeed * swerveInputSystem.MoveFactorY;
        var posY = transform.localPosition;
        posY.y = Mathf.Clamp(transform.localPosition.y, 0.5f, 10);
        transform.localPosition = posY;
        transform.Translate(0, swerveAmountY, 0);
        #endregion
    }
}