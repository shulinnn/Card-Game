using UnityEngine;
using Mirror;
using Assets.Scripts.Multiplayer;

namespace Assets.Scripts
{
    public class CameraController : NetworkBehaviour
    {

        public CameraBoundaries cameraBoundaries;
        public CameraData cameraData;
        private Camera cam => Camera.main;
        private Transform camContainer;

        private void Start()
        {
            camContainer = cam.transform.parent;
        }
        void Update()
        {

            if (!isLocalPlayer)
                return;

            Move();
        }

        void Move()
        {
            float xInput = Input.GetAxis("Vertical");
            float zInput = Input.GetAxis("Horizontal");

            Vector3 dir = camContainer.transform.forward * xInput + -camContainer.transform.right * -zInput;

            camContainer.transform.position += dir * cameraData.cameraSpeed * Time.deltaTime;

            Vector3.Lerp(camContainer.transform.position, dir, cameraData.cameraSpeed * Time.deltaTime);

            transform.position = new Vector3
            (
                Mathf.Clamp(camContainer.transform.position.x, cameraBoundaries.boundariesXNegative, cameraBoundaries.boundariesXPositive),
                Mathf.Clamp(camContainer.transform.position.y, cameraBoundaries.boundariesYNegative, cameraBoundaries.boundariesYPositive),
                Mathf.Clamp(camContainer.transform.position.z, cameraBoundaries.boundariesZNegative, cameraBoundaries.boundariesZPositive)
            );


        }
    }
}
