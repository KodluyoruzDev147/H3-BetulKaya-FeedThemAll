using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _rigidbody;

    [BoxGroup("Visual Settings")]
    [SerializeField] private Transform visual;
    [SerializeField] private Transform camPos;

    [BoxGroup("Player Settings")]
    [SerializeField] private float forwardSpeed;
    [BoxGroup("Player Settings")]
    [SerializeField] private float sideSpeed;

    private Touch touch;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // // Editor movements
        // Vector3 forwardMove = Vector3.back * forwardSpeed * Time.fixedDeltaTime;
        // Vector3 sideMove = Vector3.right * Input.GetAxis("Horizontal") * sideSpeed * Time.fixedDeltaTime;
        // _rigidbody.MovePosition(transform.position + forwardMove + sideMove);

        Vector3 deltaPosition = -visual.forward * forwardSpeed;
        if (Input.touchCount > 0)
        {
            Vector3 touchPosition = Input.GetTouch(0).position;
            if (touchPosition.x > Screen.width * 0.5f)
                deltaPosition += visual.right * sideSpeed;
            else
                deltaPosition -= visual.right * sideSpeed;
        }
        visual.transform.position = visual.position + deltaPosition * Time.fixedDeltaTime;
        camPos.position = new Vector3(camPos.position.x, camPos.position.y, visual.transform.position.z);
    }
}
