using Mirror;
using UnityEngine;

namespace Assets.Scripts.Multiplayer
{
    public class CastingComponent : NetworkBehaviour
    {

        private InputComponent inputComponent;

        private void Start()
        {
            inputComponent = GetComponent<InputComponent>();

            inputComponent.OnCardUsageAction += OnCardUsage;

        }

        void OnCardUsage(int i)
        {
            Debug.Log("CardUsage" + i);
        }

    }
}
