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


    [BoxGroup("Player Input Settings")]
    [SerializeField] private float forwardSpeed;
    [BoxGroup("Player Input Settings")]
    [SerializeField] private MobileSwerveInputs _mobileSwerveInputs;
    [BoxGroup("Player Input Settings")]
    [SerializeField] private EditorSwerveInputs _editorSwerveInputs;
    [BoxGroup("Player Input Settings")]
    [SerializeField] private float swerveSpeed = 0.5f;
    [BoxGroup("Player Input Settings")]
    [SerializeField] private float maxSwerveAmount = 1f;


    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
#if UNITY_EDITOR
        EditorMovement();
#else
        MobileMovement();
#endif

    }

    #region Fixed Update
    void FixedUpdate()
    {
        // // Editor movements
        // Vector3 forwardMove = Vector3.back * forwardSpeed * Time.fixedDeltaTime;
        // Vector3 sideMove = Vector3.right * Input.GetAxis("Horizontal") * sideSpeed * Time.fixedDeltaTime;
        // _rigidbody.MovePosition(transform.position + forwardMove + sideMove);


        // Vector3 deltaPosition = -visual.forward * forwardSpeed;
        // if (Input.touchCount > 0)
        // {
        //     Vector3 touchPosition = Input.GetTouch(0).position;
        //     if (touchPosition.x > Screen.width * 0.4f)
        //         deltaPosition += visual.right * sideSpeed;
        //     else
        //         deltaPosition -= visual.right * sideSpeed;
        // }
        // visual.transform.position = visual.position + deltaPosition * Time.fixedDeltaTime;
        // camPos.position = new Vector3(camPos.position.x, camPos.position.y, visual.transform.position.z);
    }
    #endregion

    private void EditorMovement()
    {
        Vector3 forwardMove = Vector3.back * forwardSpeed * Time.deltaTime;
        float swerveAmount = Time.deltaTime * swerveSpeed * _editorSwerveInputs.MoveFactorX;

        swerveAmount = Mathf.Clamp(swerveAmount, -maxSwerveAmount, maxSwerveAmount);
        visual.transform.Translate(swerveAmount, 0, forwardMove.z);
        camPos.position = new Vector3(camPos.position.x, camPos.position.y, visual.transform.position.z);

    }

    private void MobileMovement()
    {
        Vector3 forwardMove = Vector3.back * forwardSpeed * Time.deltaTime;
        float swerveAmount = Time.deltaTime * swerveSpeed * _mobileSwerveInputs.MoveFactorX;

        swerveAmount = Mathf.Clamp(swerveAmount, -maxSwerveAmount, maxSwerveAmount);
        visual.transform.Translate(swerveAmount, 0, forwardMove.z);
        camPos.position = new Vector3(camPos.position.x, camPos.position.y, visual.transform.position.z);

    }
}
