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

    public Transform _actualContainer;

    private Vector3 _moveDirection;
    private Vector3 _moveTarget;

    public override void OnStartClient()
    {
        _actualCamera = Camera.main;
        _actualContainer = _actualCamera.transform.parent;
    }

    /// <summary>
    /// Sets the direction of movement based on the input provided by the player
    /// </summary>
    /// <param name="context"></param>
    /// 
    [Client]
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
    [ClientCallback]
    private void LateUpdate()
    {
        _moveTarget += (_actualContainer.forward * _moveDirection.z + _actualContainer.right * _moveDirection.x) * Time.fixedDeltaTime * 16f;

        //Lerp  the camera to a new move target position
        _actualContainer.position = Vector3.Lerp(_actualContainer.position, _moveTarget, Time.deltaTime * 16f);
    }
}
