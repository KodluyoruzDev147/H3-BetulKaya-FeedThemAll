using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _rigidbody;

    [BoxGroup("Visual Settings")]
    [SerializeField] private Transform player;
    [BoxGroup("Visual Settings")]
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
        /* ZTK was here
         * Ayrık bir input sistemi çok güzel bir uygulama olmuş.
         * Ancak oyun kodunu bu şekilde editör ya da mobil için ayrı ayrı yaparak kirletmek yerine.
         * Bu ayrımı direkt bir input manager sistemi içinde yapsan kodunun okunabilirliği ciddi oranda artacaktır.
         */
#if UNITY_EDITOR
        EditorMovement();
#else
        MobileMovement();
#endif

    }

    private void EditorMovement()
    {
        Vector3 forwardMove = Vector3.back * forwardSpeed * Time.deltaTime;
        float swerveAmount = Time.deltaTime * swerveSpeed * _editorSwerveInputs.MoveFactorX;

        swerveAmount = Mathf.Clamp(swerveAmount, -maxSwerveAmount, maxSwerveAmount);
        transform.Translate(swerveAmount, 0, forwardMove.z);
        camPos.position = new Vector3(camPos.position.x, camPos.position.y, player.transform.position.z);

    }

    private void MobileMovement()
    {
        Vector3 forwardMove = Vector3.back * forwardSpeed * Time.deltaTime;
        float swerveAmount = Time.deltaTime * swerveSpeed * _mobileSwerveInputs.MoveFactorX;

        swerveAmount = Mathf.Clamp(swerveAmount, -maxSwerveAmount, maxSwerveAmount);
        transform.Translate(swerveAmount, 0, forwardMove.z);
        camPos.position = new Vector3(camPos.position.x, camPos.position.y, player.transform.position.z);

    }
}
