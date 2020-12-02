using UnityEngine;
using Mirror;
using Assets.Scripts.Core;
using System.Collections.Generic;
using System.Collections;

namespace Assets.Scripts.SpellEffects.Bases
{
    public abstract class ProjectileSpellPoint : SpellEffectBase
    {
        private Vector3 _position;

        private float _time;

        [SerializeField]
        private List<GameObject> projectileObjects = new List<GameObject>();

        [SerializeField]
        private bool isEnding;

        internal bool hasStarted;


        private void Start()
        {
            _position = transform.position;
        }

        public override void OnStartClient()
        {
            OnProjectileStart();
        }

        [ServerCallback]
        private void Update()
        {
            if (Vector3.Distance(transform.position, _targetPoint) > 0.1f && !isEnding)
            {
                _time += (2f * Time.deltaTime) / Mathf.PI;
                Vector3 currPos = Vector3.Lerp(_position, _targetPoint, _time);
                currPos.y += _animationCurve.Evaluate(_time);
                transform.position = currPos;

            }
            else
            {
                isEnding = true;
                if (isEnding)
                {

                    Collider[] colliders = Physics.OverlapSphere(transform.position, _card.spellData.radius, _card.spellData.layerMask);

                    if (colliders.Length > 0)
                    {
                        foreach (Collider collider in colliders)
                        {
                            if (!hasStarted)
                                StartCoroutine(OnProjectileHitEnumerator(collider.gameObject));
                            else
                                return;
                        }
                    }
                    else
                    {
                        OnProjectileEnd();
                    }

                }

            }
        }

        internal IEnumerator OnProjectileHitEnumerator(GameObject gObject)
        {
            hasStarted = true;
            OnProjectileHit(gObject);
            yield return null;
        }

        public virtual void OnProjectileHit(GameObject gObject)
        {

            OnProjectileEnd();

        }


        public virtual void OnProjectileStart()
        {
            this.projectileObjects[0].SetActive(true);
        }

        public virtual void OnProjectileEnd()
        {
            this.projectileObjects[0].SetActive(false);
            this.projectileObjects[1].SetActive(true);
            ServerDestroySelf(1f);
        }

    }
}
