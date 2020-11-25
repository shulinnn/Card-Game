using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Mirror;

[System.Serializable]
public struct CameraBoundaries
{
    public float boundariesYPositive;
    public float boundariesXPositive;
    public float boundariesZPositive;

    public float boundariesYNegative;
    public float boundariesXNegative;
    public float boundariesZNegative;
}

public class CameraController : NetworkBehaviour
{

    public CameraBoundaries cameraBoundaries;

    public Camera _actualCamera;

    private Vector3 _moveDirection;
    private Vector3 _moveTarget;

    public override void OnStartLocalPlayer()
    {
        _actualCamera = Camera.main;
    }

    /// <summary>
    /// Sets the direction of movement based on the input provided by the player
    /// </summary>
    /// <param name="context"></param>
    public void OnMove(InputAction.CallbackContext context)
    {

        if (!isLocalPlayer)
            return;

        if (context.phase == InputActionPhase.Started)
            return;

        //Read the input value that is being sent by the Input System
        Vector2 value = context.ReadValue<Vector2>();

        //Store the value as a Vector3, making sure to move the Y input on the Z axis.
        _moveDirection = new Vector3(value.x, 0, value.y);
    }

    private void LateUpdate()
    {
        _moveTarget += (_actualCamera.transform.parent.gameObject.transform.forward * _moveDirection.z + _actualCamera.transform.parent.gameObject.transform.right * _moveDirection.x) * Time.fixedDeltaTime * 16f;

        //Lerp  the camera to a new move target position
        _actualCamera.transform.parent.gameObject.transform.position = Vector3.Lerp(_actualCamera.transform.parent.gameObject.transform.position, _moveTarget, Time.deltaTime * 16f);
    }
}
