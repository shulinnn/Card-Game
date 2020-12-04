using Assets.Scripts.Core;
using Assets.Scripts.SpellEffects;
using Mirror;
using UnityEngine;

namespace Assets.Scripts.Multiplayer
{
    public class SpawningComponent : NetworkBehaviour
    {
        public System.Action<Card, Vector3> OnPointTargetingSuccessAction;
        public System.Action<Card, GameObject> OnMinionTargetingSuccessAction;
        public System.Action<Card, GameObject> OnSummonerTargetingSuccessAction;

        private CasterComponent casterComponent;


        private void Start()
        {
            casterComponent = GetComponent<CasterComponent>();
        }

        private void Awake()
        {
            OnPointTargetingSuccessAction += SpawnComponentPoint;
            OnMinionTargetingSuccessAction += SpawnComponentMinion;
            OnSummonerTargetingSuccessAction += SpawnComponentSummoner;
        }

        [Client]
        public void SpawnComponentPoint(Card card, Vector3 pointObject) => CmdSpellOnPoint(card, pointObject);

        [Client]
        public void SpawnComponentMinion(Card card, GameObject minionObject) => CmdSpellOnMinion(card, minionObject);

        [Client]
        public void SpawnComponentSummoner(Card card, GameObject summonerObject) => CmdSpellOnSummoner(card, summonerObject);


        [Command]
        void CmdSpellOnPoint(Card card, Vector3 point)
        {
            if (card.traversalType == TraversalType.FromCasterToPos)
            {
                GameObject spellEffect = Instantiate(card.spellEffect.prefab, casterComponent.ProjectileTransform.position, Quaternion.identity);
                spellEffect.GetComponent<SpellEffectBase>()._targetPoint = point;
                spellEffect.GetComponent<SpellEffectBase>()._card = card;
                NetworkServer.Spawn(spellEffect, gameObject);
                DecrementResources(card);
            }
            if (card.traversalType == TraversalType.SpawnAtPoint)
            {
                GameObject spellEffect = Instantiate(card.spellEffect.prefab, point, Quaternion.identity);
                spellEffect.GetComponent<SpellEffectBase>()._targetPoint = point;
                spellEffect.GetComponent<SpellEffectBase>()._card = card;
                NetworkServer.Spawn(spellEffect, gameObject);
                DecrementResources(card);
            }

        }
        [Command]
        void CmdSpellOnMinion(Card card, GameObject minionObject)
        {
            if (card.traversalType == TraversalType.FromCasterToPos)
            {
                GameObject spellEffect = Instantiate(card.spellEffect.prefab, casterComponent.ProjectileTransform.position, Quaternion.identity);
                spellEffect.GetComponent<SpellEffectBase>()._targetTransform = minionObject.transform;
                spellEffect.GetComponent<SpellEffectBase>()._card = card;
                NetworkServer.Spawn(spellEffect, gameObject);
                DecrementResources(card);
            }
            if (card.traversalType == TraversalType.SpawnAtPoint)
            {
                GameObject spellEffect = Instantiate(card.spellEffect.prefab, minionObject.transform.position, Quaternion.identity, minionObject.transform);
                spellEffect.GetComponent<SpellEffectBase>()._targetTransform = minionObject.transform;
                spellEffect.GetComponent<SpellEffectBase>()._card = card;
                NetworkServer.Spawn(spellEffect, gameObject);
                DecrementResources(card);
            }
        }
        [Command]
        void CmdSpellOnSummoner(Card card, GameObject summonerObject) { }
        [Command]
        void CmdEnchantmentOnMinion(Card card, GameObject minionObject) { }
        [Command]
        void CmdMinionSpawn(Card card) { }

        [Server]
        public void DecrementResources(Card card)
        {
            switch (card.resourceType)
            {
                case ResourceType.Health:
                    {
                        HealthComponent healthComponent = GetComponent<HealthComponent>();
                        if (healthComponent.health >= card.cardCost)
                        {
                            healthComponent.health -= card.cardCost;
                        }
                        else return;
                    }
                    break;
                case ResourceType.Mana:
                    {
                        ManaComponent manaComponent = GetComponent<ManaComponent>();
                        if (manaComponent.mana >= card.cardCost)
                        {
                            manaComponent.mana -= card.cardCost;
                        }
                    }
                    break;
                default:
                    break;
            }
        }
    }
}