using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public FloatingJoystick joystick;
    public PlayerAnim animation;

    public static PlayerMovement instance;

    public Rigidbody rb;
    [SerializeField] float speed;

    bool trigger;
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        trigger = false;
        rb = gameObject.GetComponent<Rigidbody>();
    }
    private void Update()
    {

        if (Input.GetMouseButton(0))
        {
            Debug.Log("mouse");
            Vector3 direction = Vector3.forward * joystick.Vertical + Vector3.right * joystick.Horizontal;
            Vector3 targetPosition = transform.position + direction;
            rb.velocity = direction * 5f * Time.fixedDeltaTime;
            rb.MovePosition(transform.position + direction * 5f * Time.fixedDeltaTime);
            animation.run();
        }
        else
        {
            animation.stoprun();
        }
        if (trigger)
        {
            rb.MovePosition(transform.position + Vector3.right * 50f * Time.deltaTime);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("StaticObstacle"))
        {
            trigger = true;
        }
    }
}
