using UnityEngine;
using Mirror;

namespace Assets.Scripts.Multiplayer
{
    public class CasterComponent : NetworkBehaviour
    {
        public Transform ProjectileTransform;
        public Transform BottomTransform;
        public Transform minionTransform;
    }
}
