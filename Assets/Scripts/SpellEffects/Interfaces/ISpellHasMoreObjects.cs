using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.SpellEffects
{
    interface ISpellHasMoreObjects
    {
        List<GameObject> effectObjects { get; set; }
    }
}
