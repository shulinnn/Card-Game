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
        }

        [Client]
        public void SpawnComponentPoint(Card card, Vector3 pointObject) => CmdSpellOnPoint(card, pointObject);

        [Client]
        public void SpawnComponentMinion(Card card, GameObject minionObject) { }

        [Client]
        public void SpawnComponentSummoner(Card card, GameObject summonerObject) { }


        [Command]
        void CmdSpellOnPoint(Card card, Vector3 point)
        {
            if (card.traversalType == TraversalType.FromCasterToPos)
            {
                GameObject spellEffect = Instantiate(card.spellEffect.prefab, casterComponent.ProjectileTransform.position, Quaternion.identity);
                spellEffect.GetComponent<SpellEffectBase>()._targetPoint = point;
                NetworkServer.Spawn(spellEffect, gameObject);
            }
            if (card.traversalType == TraversalType.SpawnAtPoint)
            {
                GameObject spellEffect = Instantiate(card.spellEffect.prefab, point, Quaternion.identity);
                NetworkServer.Spawn(spellEffect, gameObject);
            }

        }
        [Command]
        void CmdSpellOnMinion(Card card, GameObject minionObject) { }
        [Command]
        void CmdSpellOnSummoner(Card card, GameObject summonerObject) { }
        [Command]
        void CmdEnchantmentOnMinion(Card card, GameObject minionObject) { }
        [Command]
        void CmdMinionSpawn(Card card) { }
    }
}