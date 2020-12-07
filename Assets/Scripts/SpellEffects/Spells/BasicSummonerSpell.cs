using Assets.Scripts.SpellEffects.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.SpellEffects.Spells
{
    public class BasicSummonerSpell : SpellTarget
    {

        public override void OnSpellSpawn()
        {
            base.OnSpellSpawn();
        }


        public override void OnSpellEnd()
        {
            base.OnSpellEnd();

            Destroy(gameObject);

        }

        public override void Tick()
        {
            base.Tick();
        }

    }
}
