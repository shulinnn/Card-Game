using UnityEngine;
using System;
using System.Collections;
using Mirror;

namespace Assets.Scripts.Multiplayer
{
    [Serializable]
    public struct MinionObject
    {
        public float attackDamage;
        public float attackSpeed;
        public float attackRange;
        public float moveSpeed;
    }

    [Serializable]
    public enum MinionState
    {
      Move,
      Attack,
      Chase
    }

    public class Minion : NetworkBehaviour
    {
        [SerializeField]
        private MinionObject minionObject;
        [SerializeField]
        private MinionState minionState;
        [SerializeField]
        private HealthComponent healthComponent;

        [SerializeField]
        private Transform[] wayPoints;


        public override void OnStartServer()
        {
            base.OnStartServer();



        }

        [Server]
        public void Update()
        {
            
        }



    }

}
