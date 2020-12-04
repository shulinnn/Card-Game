using Assets.Scripts.SpellEffects.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.SpellEffects.Spells
{
    public class BasicMinionSpell : ProjectileSpellTarget
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
