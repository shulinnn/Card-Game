using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.SpellEffects.Interfaces
{
    interface ISpellHasMoreObjects
    {
        List<GameObject> effectObjects { get; }
    }
}
