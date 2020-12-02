using Assets.Scripts.SpellEffects.Bases;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.SpellEffects.Spells
{


    public class BasicPointSpell : ProjectileSpellPoint
    {
        public override void OnProjectileHit(GameObject gObject)
        {

            base.OnProjectileHit(gObject);

            Debug.Log(gObject.name);
        }
    }
}
