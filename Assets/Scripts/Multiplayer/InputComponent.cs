using UnityEngine;
using Mirror;
using UnityEngine.InputSystem;

namespace Assets.Scripts.Multiplayer
{
    public class InputComponent : NetworkBehaviour
    {

        public void OnCardUse(InputAction.CallbackContext callbackContext)
        {
            Debug.Log("Card Used.");
            Debug.Log(callbackContext.action);
        }

    }
}
