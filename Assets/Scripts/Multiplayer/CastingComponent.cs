using Mirror;
using UnityEngine;

namespace Assets.Scripts.Multiplayer
{
    public class CastingComponent : NetworkBehaviour
    {

        private void Start()
        {
            InputComponent.OnCardUsageEvent.AddListener(OnCardUsageListener);
        }

        void OnCardUsageListener(NetworkIdentity networkIdentity)
        {
            Debug.Log(networkIdentity);
        }

    }
}
