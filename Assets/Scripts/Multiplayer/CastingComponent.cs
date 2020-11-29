using Assets.Scripts.Core;
using Mirror;
using UnityEngine;

namespace Assets.Scripts.Multiplayer
{
    public class CastingComponent : NetworkBehaviour
    {

        private InputComponent inputComponent;
        private HandComponent handComponent;
        private HealthComponent healthComponent;

        private void Start()
        {
            inputComponent = GetComponent<InputComponent>();
            handComponent = GetComponent<HandComponent>();
            inputComponent.OnCardUsageAction += OnCardUsage;

        }

        void OnCardUsage(int i) => CmdCheckResources(handComponent.inventory[i]);

        [Command]
        public void CmdCheckResources(Card card)
        {

        }

    }
}
