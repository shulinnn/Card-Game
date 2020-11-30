using Assets.Scripts.Core;
using Mirror;
using UnityEngine;

namespace Assets.Scripts.Multiplayer
{
    public class TargetingComponent : NetworkBehaviour
    {

        [SerializeField] private bool isTargeting;

        /// <summary>
        /// Here we initialize Client side part of targeting
        /// </summary>
        /// <param name="card">The card we're using</param>
        /// 
        [Client]
        public void Initialize(Card card)
        {

        }

    }
}
