using Assets.Scripts.Core;
using Assets.Scripts.Multiplayer;
using Mirror;
using UnityEngine;

namespace Assets.Scripts.SpellEffects.Bases
{

    public class SpellEffectBase : NetworkBehaviour
    {
        public Vector3 _targetPoint;
        public Transform _targetTransform;
        public Card _card;
        [SerializeField]
        public AnimationCurve _animationCurve;

        #region Base methods

        [Server]
        protected void ServerDestroySelf(float delay) => Destroy(gameObject, delay);
        [Server]
        protected void ServerDestroySelf() => Destroy(gameObject);

        #endregion

    }
}
