using Mirror;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Multiplayer
{
    public class ManaComponent : NetworkBehaviour
    {    /// <summary>
         /// What is our current health ?
         /// </summary>
        [SyncVar(hook = nameof(OnManaChange))]
        public float mana;
        /// <summary>
        /// What is our maximum health we can have?
        /// </summary>
        [SyncVar(hook = nameof(OnMaxManaChange))]
        public float maxMana;
        /// <summary>
        /// How much health we get back each second ?
        /// </summary>
        [SyncVar(hook = nameof(OnManaRegenRatioChanged))]
        public float manaRegenRatio;

        /// <summary>
        /// Should be used for changing UI Elements values and such...
        /// </summary>
        /// <param name="oldVal">Old value</param>
        /// <param name="newVal">New Value</param>
        void OnManaChange(float oldVal, float newVal)
        {
        }
        /// <summary>
        /// Should be used for changing UI Elements values and such...
        /// </summary>
        /// <param name="oldVal">Old value</param>
        /// <param name="newVal">New Value</param>
        void OnMaxManaChange(float oldVal, float newVal)
        {
        }
        /// <summary>
        /// Should be used for changing UI Elements values and such...
        /// </summary>
        /// <param name="oldVal">Old value</param>
        /// <param name="newVal">New Value</param>
        void OnManaRegenRatioChanged(float oldVal, float newVal)
        { }

        #region Server-side Methods

        /// Set our health to our MaxHealth when the Server start => e.g. when the game starts or we get spawned

        public override void OnStartServer()
        {
            base.OnStartServer();
            mana = maxMana;

            //StartCoroutine(HealthRegen());

        }

        #endregion

        #region Methods

        /// <summary>
        /// Wait 1 second then add health based on health regen ratio
        /// </summary>
        /// <returns></returns>
        IEnumerator ManaRegen()
        {
            while (true)
            {
                yield return new WaitForSeconds(1f);
                mana += manaRegenRatio;
                yield return null;
            }
        }

        #endregion


    }
}
