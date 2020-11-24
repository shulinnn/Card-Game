using Mirror;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Multiplayer
{
    public class HealthComponent : NetworkBehaviour
    {    /// <summary>
         /// What is our current health ?
         /// </summary>
        [SyncVar(hook = nameof(OnHealthChange))]
        public float health;
        /// <summary>
        /// What is our maximum health we can have?
        /// </summary>
        [SyncVar(hook = nameof(OnMaxHealthChange))]
        public float maxHealth;
        /// <summary>
        /// How much health we get back each second ?
        /// </summary>
        [SyncVar(hook = nameof(OnHealthRegenRatioChanged))]
        public float healthRegenRatio;

        /// <summary>
        /// Should be used for changing UI Elements values and such...
        /// </summary>
        /// <param name="oldVal">Old value</param>
        /// <param name="newVal">New Value</param>
        void OnHealthChange(float oldVal, float newVal)
        {
        }
        /// <summary>
        /// Should be used for changing UI Elements values and such...
        /// </summary>
        /// <param name="oldVal">Old value</param>
        /// <param name="newVal">New Value</param>
        void OnMaxHealthChange(float oldVal, float newVal)
        {
        }
        /// <summary>
        /// Should be used for changing UI Elements values and such...
        /// </summary>
        /// <param name="oldVal">Old value</param>
        /// <param name="newVal">New Value</param>
        void OnHealthRegenRatioChanged(float oldVal, float newVal)
        {}

        #region Server-side Methods

        /// Set our health to our MaxHealth when the Server start => e.g. when the game starts or we get spawned

        public override void OnStartServer()
        {
            base.OnStartServer();
            health = maxHealth;

            //StartCoroutine(HealthRegen());

        }

        #endregion

        #region Methods

        /// <summary>
        /// Wait 1 second then add health based on health regen ratio
        /// </summary>
        /// <returns></returns>
        IEnumerator HealthRegen()
        {
            while (true)
            {
                yield return new WaitForSeconds(1f);
                health += healthRegenRatio;
                yield return null;
            }
        }

        #endregion


    }
}
