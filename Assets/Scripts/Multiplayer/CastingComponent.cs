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
        private ManaComponent manaComponent;
        private TargetingComponent targetingComponent;

        private void Start()
        {
            inputComponent = GetComponent<InputComponent>();
            handComponent = GetComponent<HandComponent>();
            manaComponent = GetComponent<ManaComponent>();
            healthComponent = GetComponent<HealthComponent>();
            targetingComponent = GetComponent<TargetingComponent>();

            ///Listen to Input Action
            inputComponent.OnCardUsageAction += OnCardUsage;

        }

        void OnCardUsage(int i) => CmdCheckResources(handComponent.inventory[i]);

        [Command]
        public void CmdCheckResources(Card card)
        {
            switch (card.resourceType)
            {
                case ResourceType.Health:
                    {
                        if(card.cardCost <= healthComponent.health)
                        {
                            TargetInitializeTargeting(card);
                        }
                        else
                        {
                            return;
                        }
                    }
                    break;
                case ResourceType.Mana:
                    {
                        if (card.cardCost <= manaComponent.mana)
                        {
                            /// We have enough mana
                            TargetInitializeTargeting(card);
                        }
                        else
                        {
                            Debug.Log("Not enough mana.");
                            return;
                        }
                    }
                    break;
                default:
                    break;
            }
        }

        [TargetRpc]
        public void TargetInitializeTargeting(Card card) => targetingComponent.Initialize(card);

    }
}
