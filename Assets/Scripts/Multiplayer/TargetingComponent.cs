using Assets.Scripts.Core;
using Mirror;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Multiplayer
{
    public class TargetingComponent : NetworkBehaviour
    {

        #region Properties
        [SerializeField] protected bool isTargeting { get; set; }

        [SerializeField] protected LayerMask groundMask, minionMask, summonerMask;

        protected SpawningComponent spawningComponent;

        #endregion

        private void Start()
        {
            spawningComponent = GetComponent<SpawningComponent>();
        }

        void InitTargeting(Card card)
        {
            if (isTargeting)
                return;

            DetectTarget(card);
        }

        /// <summary>
        /// Here we initialize Client side part of targeting
        /// </summary>
        /// <param name="card">The card we're using</param>
        /// 
        [Client]
        public void Initialize(Card card) => InitTargeting(card);

        [Client]
        void DetectTarget(Card card)
        {

            Debug.Log("DetectTarget");

            isTargeting = true;

            switch (card.cardType)
            {
                case CardType.Spell:
                    {
                        switch (card.targetType)
                        {
                            case TargetType.Minion:
                                {
                                    StartCoroutine(WaitForMinion(card));
                                }
                                break;
                            case TargetType.Summoner:
                                {
                                    StartCoroutine(WaitForSummoner(card));
                                }
                                break;
                            case TargetType.Point:
                                {
                                    StartCoroutine(WaitForPoint(card));
                                }
                                break;
                            default:
                                break;
                        }
                    }
                    break;
                case CardType.Enchantment:
                    {
                        ///
                    }
                    break;
                case CardType.Summon:
                    {
                        ///
                    }
                    break;
                default:
                    break;
            }
        }

        #region Coroutines
        IEnumerator WaitForMinion(Card card)
        {

            while (isTargeting)
            {

                Debug.Log("Inside IEnum");

                if (Input.GetMouseButtonDown(0))
                {

                    Debug.Log("LMB");

                    RaycastHit hit = new RaycastHit();
                    if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity, minionMask))
                    {

                        Debug.Log("Succ Raycast");

                        spawningComponent.OnMinionTargetingSuccessAction?.Invoke(card, hit.collider.gameObject);
                        Debug.Log("After.");
                        isTargeting = false;
                        yield break;
                    }
                    else
                    {
                        isTargeting = false;
                        yield break;
                    }
                }
                else if (Input.GetMouseButtonDown(1))
                {
                    isTargeting = false;
                    yield break;
                }
                yield return null;
            }
        }

        IEnumerator WaitForSummoner(Card card)
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit = new RaycastHit();
                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity, summonerMask))
                {
                    spawningComponent.OnSummonerTargetingSuccessAction?.Invoke(card, hit.collider.gameObject);
                    isTargeting = false;
                    yield break;
                }
                else
                {
                    isTargeting = false;
                    yield break;
                }
            }
            else if (Input.GetMouseButtonDown(1))
            {
                isTargeting = false;
                yield break;
            }
            yield return null;
        }

        IEnumerator WaitForPoint(Card card)
        {
            while (isTargeting)
            {

                if (Input.GetMouseButtonDown(0))
                {
                    RaycastHit hit = new RaycastHit();
                    if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity, groundMask))
                    {
                        spawningComponent.OnPointTargetingSuccessAction?.Invoke(card, hit.point);

                        isTargeting = false;
                        yield break;
                    }
                    else
                    {
                        isTargeting = false;
                        yield break;
                    }
                }
                else if (Input.GetMouseButtonDown(1))
                {
                    isTargeting = false;
                    yield break;
                }
                yield return null;
            }
        }

        #endregion

    }
}
