using UnityEngine;
using Mirror;
using Assets.Scripts.Multiplayer;

namespace Assets.Scripts
{
    public class CameraController : NetworkBehaviour
    {

        public CameraBoundaries cameraBoundaries;
        public CameraData cameraData;
        [SerializeField]
        private Camera cam;
        [SerializeField]
        private Transform camContainer;

        private void Start()
        {
            cam = Camera.main;
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

            Vector3 dir = camContainer.forward * xInput + -camContainer.right * -zInput;

            camContainer.transform.position += dir * cameraData.cameraSpeed * Time.deltaTime;

            Vector3.Lerp(camContainer.position, dir, cameraData.cameraSpeed * Time.deltaTime);

            camContainer.position = new Vector3
            (
                Mathf.Clamp(camContainer.position.x, cameraBoundaries.boundariesXNegative, cameraBoundaries.boundariesXPositive),
                0f,
                Mathf.Clamp(camContainer.position.z, cameraBoundaries.boundariesZNegative, cameraBoundaries.boundariesZPositive)
            );


        }
    }
}
