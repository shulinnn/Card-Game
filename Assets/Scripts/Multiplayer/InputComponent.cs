using UnityEngine;
using Mirror;
using UnityEngine.InputSystem;
using UnityEngine.Events;

namespace Assets.Scripts.Multiplayer
{
    public class IntEvent : UnityEvent<NetworkIdentity>
    { }

    public class InputComponent : NetworkBehaviour
    {

        public static IntEvent OnCardUsageEvent;


        public override void OnStartClient()
        {
            if (OnCardUsageEvent == null)
                OnCardUsageEvent = new IntEvent();
        }

        public void OnCardUse(InputAction.CallbackContext callbackContext)
        {

            if (!isLocalPlayer)
                return;

            if (callbackContext.phase == InputActionPhase.Performed)
                OnCardUsageEvent?.Invoke(netIdentity);
        }

    }
}
