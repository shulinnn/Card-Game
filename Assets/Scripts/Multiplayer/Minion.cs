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

    public class Minion : NetworkBehaviour
    {
        public MinionObject minionObject;

    }
}
