using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using DG.Tweening;

public class PlayerMovement : MonoBehaviour
{
    private InputManager swerveInputSystem;
    [SerializeField] InputData _inputData;
    public PlayerAnim animation;
    public FloatingJoystick joystick; 
    public Rigidbody rb;

    PlayerOrder playerOrder;
    NavMeshAgent navMeshAgent;
    Vector3 target;
    bool isRotatingLeft;
    bool isRotatingRight;
    bool isRotator;


    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.enabled = false;
        isRotatingLeft = false;
        isRotatingRight = false;
        isRotator = false;
        swerveInputSystem = GetComponent<InputManager>();
        animation = GetComponent<PlayerAnim>(); 
        rb = gameObject.GetComponent<Rigidbody>();
        playerOrder = GetComponent<PlayerOrder>();
    }

    private void Update()
    {
        MovementRotator();
        if (GameManager.instance.isFinish)
        {
            MovementJoystick(); 
        }
        else
        {
            MovementAndSwerve();
        }
        if (isRotator)
        {
            UIManager.Instance.orderText.text = (GameManager.instance.player.Count + GameManager.instance.order) + ".";
            
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("PaintFinish"))
        {
            GameManager.instance.isPaintFinish = true;
        }
        
        if (collision.transform.CompareTag("RotatingFinish"))
        {
            GameManager.instance.isFinish = true;
            rb.constraints = RigidbodyConstraints.FreezeRotation;
        }
        if (collision.transform.CompareTag("BonusObstacle"))
        {
            navMeshAgent.enabled = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("FinishLine"))
        {
            GameManager.instance.isFinishLine = true;
        }
        if (other.CompareTag("Fall"))
        {
            Fall();
        }
    }
    
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Right"))
        {
            isRotatingRight = true;
            isRotator = true;
        }
        if (collision.gameObject.CompareTag("Left"))
        {
            isRotatingLeft = true;
            isRotator = true;
        }
        if (collision.transform.CompareTag("RotatingFinish") && !UIManager.Instance.startPanel.activeSelf)
        {
            animation.run();
            transform.DOMoveZ(transform.position.z + 1f, 0.7f);
            
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.CompareTag("BonusObstacle"))
        {
            navMeshAgent.enabled = false;
        }
        if (collision.transform.CompareTag("RotatingFinish"))
        {
            collision.gameObject.SetActive(false);
            animation.stoprun();
        }
        if (collision.gameObject.CompareTag("Right"))
        {
            isRotatingRight = false;
        }
        if (collision.gameObject.CompareTag("Left"))
        {
            isRotatingLeft = false;
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

    void MovementJoystick()
    {
        if (Input.GetMouseButton(0))
        {
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
    void MovementRotator()
    {
        if (isRotatingRight)
        {
            rb.MovePosition(transform.position + Vector3.right * 10f * Time.deltaTime); 
            MovementJoystick();
        }
        if (isRotatingLeft)
        {
            rb.MovePosition(transform.position + Vector3.right * -10f * Time.deltaTime);
            MovementJoystick();
        }
    }
    void Fall()
    {
        if (transform.position.x > 0)
        {
            transform.DOMoveX(6f, 0.5f);
        }
        else
        {
            transform.DOMoveX(-6f, 0.5f);
        }
        transform.DOMoveY(-5f, 0.5f).OnComplete(() => {
            navMeshAgent.enabled = false;
            LevelManager.Instance.LevelFailed();

        });
        joystick.enabled = false;
       
    }
}