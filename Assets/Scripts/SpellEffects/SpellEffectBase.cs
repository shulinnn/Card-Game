using Mirror;
using UnityEngine;

namespace Assets.Scripts.SpellEffects
{

    public class SpellEffectBase : NetworkBehaviour
    {
        public virtual Vector3 _targetPoint;
        [SerializeField]
        private Card _card;
        /// <summary>
        /// Animation curve to used for projectile path => we will be animating it on the Y Axis so it doesnt look weird.
        /// </summary>
        [SerializeField]
        private AnimationCurve _animationCurve;

        /// <summary>
        /// Cache our start position at initialization to avoid issues
        /// </summary>
        [SerializeField]
        private Vector3 _position;

        [SerializeField]
        private float _projectileSpeed;

        #region Base methods

        [Server]
        protected void ServerDestroySelf(float delay) => Destroy(gameObject, delay);
        [Server]
        protected void ServerDestroySelf() => Destroy(gameObject);

        #endregion

    }
}
