using UnityEngine;
using Mirror;

namespace Assets.Scripts.Multiplayer
{

    public class InputComponent : NetworkBehaviour
    {

        public System.Action<int> OnCardUsageAction;

        [SerializeField]
        private KeyCode[] cardKeyCodes;

        private void Update()
        {

            if (!isLocalPlayer)
                return;

            for (int i = 0; i < cardKeyCodes.Length; i++)
            {
                if(Input.GetKeyDown(cardKeyCodes[i]))
                    OnCardUsageAction?.Invoke(i);
            }
        }

    }
}
