using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private InputManager swerveInputSystem;
    [SerializeField] InputData _inputData;
    public PlayerAnim animation;

    private void Start()
    {
        swerveInputSystem = GetComponent<InputManager>();
        animation = GetComponent<PlayerAnim>();
    }

    private void Update()
    {
        if (true)
        {
            MovementAndSwerwe();
        }
    }

    void MovementAndSwerwe()
    {
        #region Swerwe Movement
        float swerveAmount = Time.deltaTime * _inputData.swerveSpeed * swerveInputSystem.MoveFactorX;
        swerveAmount = Mathf.Clamp(swerveAmount, -_inputData.maxSwerveAmount, _inputData.maxSwerveAmount);
        transform.Translate(swerveAmount, 0, 0);
        #endregion

        //forward movement
        if (Input.GetMouseButton(0))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * _inputData.speed);
            
            animation.run();
        }
        else
        {
            animation.stoprun();
        }

    }
}