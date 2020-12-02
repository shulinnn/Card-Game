using UnityEngine;
using Mirror;
using Assets.Scripts.Core;
using System.Collections.Generic;

namespace Assets.Scripts.SpellEffects.Bases
{
    public abstract class ProjectileSpellPoint : SpellEffectBase
    {
        private Vector3 _position;

        private float _time;

        [SerializeField]
        private List<GameObject> projectileObjects = new List<GameObject>();


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
            if (Vector3.Distance(transform.position, _targetPoint) <= .01f)
            {

                Debug.Log(Vector3.Distance(transform.position, _targetPoint));

                _time += (2f * Time.deltaTime) / Mathf.PI;
                Vector3 currPos = Vector3.Lerp(_position, _targetPoint, _time);
                currPos.y += _animationCurve.Evaluate(_time);
                transform.position = currPos;
            }
            else
            {

                Debug.Log("Else.");

                foreach (Collider collider in Physics.OverlapSphere(transform.position, _card.spellData.radius, _card.spellData.layerMask))
                {
                        OnProjectileHit(collider.gameObject);
                }
            }

            return;
        }


        /// <summary>
        /// Will get called whether our projectile travels to its destination
        /// </summary>
        /// <param name="gObjects"></param>
        public virtual void OnProjectileHit(GameObject gObject) {}

        public virtual void OnProjectileStart() 
        {
            this.projectileObjects[0].SetActive(true);
        }

        public virtual void OnProjectileEnd() 
        {

            Debug.Log("Called.");

            this.projectileObjects[0].SetActive(false);
            this.projectileObjects[1].SetActive(true);
        }

    }
}
