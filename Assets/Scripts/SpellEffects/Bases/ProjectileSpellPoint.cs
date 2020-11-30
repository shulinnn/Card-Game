using UnityEngine;
using Mirror;
using Assets.Scripts.Core;
using Assets.Scripts.SpellEffects.Interfaces;

namespace Assets.Scripts.SpellEffects.Bases
{
    public class ProjectileSpellPoint : SpellEffectBase, IPointSpell, ICardSpell, ISpellProjectile
    {
        [SerializeField]
        private Vector3 _targetPoint;
        [SerializeField]
        private Card _card;
        /// <summary>
        /// Animation curve to used for projectile path => we will be animating it on the Y Axis so it doesnt look weird.
        /// </summary>
        [SerializeField]
        private AnimationCurve _animationCurve;

        #region Properties

        public Vector3 TargetPoint
        {
            get
            {
                return _targetPoint;
            }
            set
            {
                _targetPoint = value;
            }
        }

        public Card Card
        {
            get
            {
                return _card;
            }
            set
            {
                _card = value;
            }
        }

        public AnimationCurve AnimationCurve
        {
            get
            {
                return _animationCurve;
            }
            set
            {
                _animationCurve = value;
            }
        }

        #endregion
    }
}
