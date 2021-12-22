using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileSwerveInputs : MonoBehaviour
{
    private float _lastFrameFingerPositionX;
    private float _moveFactorX;
    public float MoveFactorX => _moveFactorX;

    private void Update()
    {
        MobileSwerving();
    }

    private void MobileSwerving()
    {
        // Track a single touch as a direction control.
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // Handle finger movements based on touch phase.
            switch (touch.phase)
            {
                // Record initial touch position.
                case TouchPhase.Began:
                    _lastFrameFingerPositionX = touch.position.x;
                    break;

                // Determine direction by comparing the current touch position with the initial one.
                case TouchPhase.Moved:
                    _moveFactorX = touch.position.x - _lastFrameFingerPositionX;
                    _lastFrameFingerPositionX = touch.position.x;
                    break;

                // Report that a direction has been chosen when the finger is lifted.
                case TouchPhase.Ended:
                    _moveFactorX = 0f;
                    break;
            }
        }
    }
}
