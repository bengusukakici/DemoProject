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
        GameManager.instance.isFinish = false;
        swerveInputSystem = GetComponent<InputManager>();
        animation = GetComponent<PlayerAnim>();
    }

    private void Update()
    {
        MovementAndSwerwe();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Finish"))
        {
            GameManager.instance.isFinish = true;
        }
    }

    void MovementAndSwerwe()
    {
        #region Swerwe Movement
        float swerveAmount = Time.deltaTime * _inputData.swerveSpeed * swerveInputSystem.MoveFactorX;
        var pos = transform.localPosition;
        pos.x = Mathf.Clamp(transform.localPosition.x, -5, 5);
        transform.localPosition = pos;
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