using System.Collections;
using UnityEngine;

namespace Assets.Scripts.SpellEffects.Bases
{
    public class SpellTarget : SpellEffectBase
    {

        public override void OnStartServer()
        {
            base.OnStartServer();

            OnSpellSpawn();

            StartCoroutine(OnSpellTick());

            StartCoroutine(SpellEffectTimer());
        }

        internal IEnumerator SpellEffectTimer()
        {
            yield return new WaitForSeconds(_card.spellEffect.lifetime);
            OnSpellEnd();
        }

        public virtual void OnSpellSpawn() { }

        /// <summary>
        /// Called each second after spawning
        /// </summary>
        public IEnumerator OnSpellTick() 
        {

            Tick();

            yield return new WaitForSeconds(1f);
        }

        public virtual void Tick() { }

        public virtual void OnSpellEnd() { }

    }
}
