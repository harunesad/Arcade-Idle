using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JoystickControl : MonoBehaviour
{
    public static JoystickControl instance = null;
    public DynamicJoystick dynamic;
    public GameObject background;

    float moveSpeed = 5;
    float turnSpeed = 5;

    Rigidbody rb;
    public Animator playerAnim;

    Vector3 firstTouch, secondTouch;
    float move;
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        if (instance == null)
        {
            instance = this;
        }
    }
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            secondTouch = Input.mousePosition;
        }
        if (Input.GetMouseButtonDown(0))
        {
            firstTouch = Input.mousePosition;
        }
        move = Vector3.Distance(secondTouch, firstTouch);
        if (Input.GetButton("Fire1"))
        {
            if (move == 0)
            {
                return;
            }
            else
            {
                Joystick();
                playerAnim.SetFloat("Walk", 2);
            }
        }
        else
        {
            rb.velocity = new Vector3(0, 0, 0);
            playerAnim.SetFloat("Walk", 1);
        }
    }
    void Joystick()
    {
        float horizontal = dynamic.Horizontal;
        float vertical = dynamic.Vertical;
        Vector3 addesPos = new Vector3(x: horizontal * Time.deltaTime * moveSpeed, y: 0, z: vertical * Time.deltaTime * moveSpeed);
        transform.position += addesPos;

        Vector3 direction = Vector3.forward * vertical + Vector3.right * horizontal;
        transform.rotation = Quaternion.Slerp(a: transform.rotation, b: Quaternion.LookRotation(direction), t: turnSpeed * Time.deltaTime);
    }
}
