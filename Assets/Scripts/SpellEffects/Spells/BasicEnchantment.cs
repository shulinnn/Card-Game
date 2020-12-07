using Mirror;
using UnityEngine;
using Assets.Scripts.SpellEffects.Bases;
using Assets.Scripts.Multiplayer;

namespace Assets.Scripts.SpellEffects.Spells
{
    public class BasicEnchantment : EnchantmentBase
    {
        public override void OnEnchantmentStart()
        {
            base.OnEnchantmentStart();
            _targetTransform.gameObject.GetComponent<HealthComponent>().maxHealth += _card.cardValue;
        }

        public override void OnEnchantmentEnd()
        {
            base.OnEnchantmentEnd();

            _targetTransform.gameObject.GetComponent<HealthComponent>().maxHealth -= _card.cardValue;


        }
    }
}
