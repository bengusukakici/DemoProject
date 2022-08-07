using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private InputManager swerveInputSystem;
    [SerializeField] InputData _inputData;
    public PlayerAnim animation;
    public FloatingJoystick joystick; 
    public Rigidbody rb;

    private void Start()
    {
        swerveInputSystem = GetComponent<InputManager>();
        animation = GetComponent<PlayerAnim>(); 
        rb = gameObject.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (GameManager.instance.isRotatingFinish)
        {
            FinishMovementJoystick();
        }
        else
        {
            MovementAndSwerve();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Finish"))
        {
            GameManager.instance.isFinish = true;
        }
        if (collision.transform.CompareTag("RotatingFinish"))
        {
            GameManager.instance.isRotatingFinish = true;
        }
    }

    void MovementAndSwerve()
    {
        #region Swerwe Movement
        float swerveAmount = Time.deltaTime * _inputData.swerveSpeed * swerveInputSystem.MoveFactorX;
        var pos = transform.localPosition;
        pos.x = Mathf.Clamp(transform.localPosition.x, -5, 5);
        transform.localPosition = pos;
        transform.Translate(swerveAmount, 0, 0);

        // Vector3 targetPosition = transform.position + new Vector3(swerveInputSystem.MoveFactorX, 0,0);
        //transform.LookAt(targetPosition);
        #endregion

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
    void FinishMovementJoystick()
    {
        if (Input.GetMouseButton(0))
        {
            Debug.Log("mouse");
            Vector3 direction = Vector3.forward * joystick.Vertical + Vector3.right * joystick.Horizontal;
            Vector3 targetPosition = transform.position + direction;
            rb.velocity = direction * 5f * Time.fixedDeltaTime;
            rb.MovePosition(transform.position + direction * 5f * Time.fixedDeltaTime);
            gameObject.transform.LookAt(targetPosition);
            animation.run();
        }
        else
        {
            animation.stoprun();
        }
    }
}