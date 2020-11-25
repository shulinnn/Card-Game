using UnityEngine;
using Mirror;

namespace Assets.Scripts.Multiplayer
{
    public class InputComponent : NetworkBehaviour
    {

        public static System.Action<NetworkIdentity, int> OnCardUsage;

        [SerializeField]
        private KeyCode[] KeyCodes;

        private void Update()
        {
            if (!isLocalPlayer)
                return;
        }

    }
}
