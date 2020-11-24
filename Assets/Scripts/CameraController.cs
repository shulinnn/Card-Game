using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

[System.Serializable]
public struct CameraData
{
    public float cameraSpeed;
}

public class CameraController : MonoBehaviour
{

    public CameraBoundaries cameraBoundaries;
    public CameraData cameraData;
    public Camera cam;

    void Update()
    {
        Move();
    }

    void Move()
    {
        float xInput = Input.GetAxis("Vertical");
        float zInput = Input.GetAxis("Horizontal");

        Vector3 dir = transform.forward * zInput + transform.right * -xInput;

        transform.position += dir * cameraData.cameraSpeed * Time.deltaTime;

        Vector3.Lerp(transform.position, dir, cameraData.cameraSpeed * Time.deltaTime);

        transform.position = new Vector3
        (
            Mathf.Clamp(transform.position.x, cameraBoundaries.boundariesXNegative, cameraBoundaries.boundariesXPositive),
            Mathf.Clamp(transform.position.y, cameraBoundaries.boundariesYNegative, cameraBoundaries.boundariesYPositive),
            Mathf.Clamp(transform.position.z, cameraBoundaries.boundariesZNegative, cameraBoundaries.boundariesZPositive)
        );


    }
}
