using Assets.Scripts.SpellEffects.Bases;
using UnityEngine;
using Assets.Scripts.Core;

namespace Assets.Scripts.SpellEffects.Spells
{


    public class BasicPointSpell : ProjectileSpellPoint
    {
        /// <summary>
        /// Will get called whether our projectile travels to its destination
        /// </summary>
        /// <param name="gObjects"></param>
        public override void OnProjectileHit(GameObject gObject)
        {
            base.OnProjectileHit(gObject);

            Debug.Log(gObject.name);

        }
    }
}
