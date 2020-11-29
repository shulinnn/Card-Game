using System;
using UnityEngine;

namespace Assets.Scripts.Core
{
    [Serializable]
    public class SpellEffectObject
    {
        public float lifetime;
        public float speed;
        public GameObject prefab;
    }

    [Serializable]
    public class SpellDataObject
    {
        public float radius;
        public LayerMask layerMask;
    }

    public enum TargetType
    {
        Minion,
        Summoner,
        Both,
        Point
    }

    public enum TraversalType
    {
        FromCasterToPos,
        SpawnAtPoint
    }

    [Serializable]
    public class Action
    {
        public enum ActionType
        {
            Heal,
            Damage,
            Shield,
            AddDamage,
            AddAttackRange,
            AddAttackSpeed,
            AddMaxHealth,
            AddMaxMana,
            Stun,
            Slow,
            Dispell
        }

        public enum ActionTarget
        {
            Caster,
            Target
        }
        public ActionType actionType;
        public ActionTarget actionTarget;
        public float value;
    }

    [Serializable]
    public enum ResourceType
    {
        Health, Mana
    }
    [Serializable]
    public enum CardType
    {
        Spell,
        Summon,
        Enchantment
    }
    [CreateAssetMenu(fileName = "New Card", menuName = "Card Shuffle/Cards/New Card")]
    public class Card : ScriptableObject
    {

        [Header("Spell Data")]
        [TextArea(0, 10)]
        public string cardDescription;
        public ResourceType resourceType;
        public float cardCost;
        public Sprite cardIcon;
        public TargetType targetType;
        public TraversalType traversalType;
        public CardType cardType;
        public Action[] cardActions;
        [Header("Spell Effect Related")]
        public SpellEffectObject spellEffect;
        [Header("Spell Effect Data")]
        public SpellDataObject spellData;

    }
}
