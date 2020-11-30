using Assets.Scripts.Core;
using Mirror;
using UnityEngine;

namespace Assets.Scripts.Multiplayer
{
    public class SpawningComponent : NetworkBehaviour
    {
        public System.Action<Card, Vector3> OnPointTargetingSuccessAction;
        public System.Action<Card, GameObject> OnMinionTargetingSuccessAction;
        public System.Action<Card, GameObject> OnSummonerTargetingSuccessAction;

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
                //spawn at self.
            }
            if (card.traversalType == TraversalType.SpawnAtPoint)
            {
                //spawn at point
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