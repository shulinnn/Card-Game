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

        private void Start()
        {
            inputComponent = GetComponent<InputComponent>();
            handComponent = GetComponent<HandComponent>();
            manaComponent = GetComponent<ManaComponent>();
            healthComponent = GetComponent<HealthComponent>();

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
                            //pass
                        }
                        else
                        {
                            //not enough health..
                        }
                    }
                    break;
                case ResourceType.Mana:
                    {
                        if (card.cardCost <= manaComponent.mana)
                        {
                            //pass
                        }
                        else
                        {
                            //not enough health..
                        }
                    }
                    break;
                default:
                    break;
            }
        }

    }
}
