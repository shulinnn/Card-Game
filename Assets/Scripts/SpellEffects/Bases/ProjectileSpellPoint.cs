using UnityEngine;
using Mirror;
using Assets.Scripts.Core;

namespace Assets.Scripts.SpellEffects.Bases
{
    public class ProjectileSpellPoint : SpellEffectBase
    {

        private Vector3 _position;
        [SerializeField]
        private float _projectileSpeed;

        private void Start()
        {
            _position = transform.position;
        }

        private void Update()
        {
            transform.position = Vector3.MoveTowards(_position, _targetPoint, _projectileSpeed * Time.deltaTime);
        }

    }
}
