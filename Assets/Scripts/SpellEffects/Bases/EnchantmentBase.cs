using Mirror;
using System;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.SpellEffects.Bases
{
    public class EnchantmentBase : SpellEffectBase
    {

        public override void OnStartServer()
        {
            base.OnStartServer();

            OnEnchantmentStart();

            StartCoroutine(OnEnchantmentTick());

        }
        [Server]
        public virtual void OnEnchantmentStart() { }

        [Server]
        public virtual void OnEnchantmentEnd() { }
        internal IEnumerator OnEnchantmentTick()
        {
            Tick();
            yield return new WaitForSeconds(1f);
        }

        /// <summary>
        /// Gets called each second spell effect is enabled/alive
        /// </summary>
        public virtual void Tick() { }

    }
}
