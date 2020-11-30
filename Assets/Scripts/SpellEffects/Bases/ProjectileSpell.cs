using Mirror;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.SpellEffects.Bases
{
    public class ProjectileSpell : NetworkBehaviour, ISpellHasMoreObjects
    {
        public List<GameObject> effectObjects { get => effectObjects; }
    }
}
