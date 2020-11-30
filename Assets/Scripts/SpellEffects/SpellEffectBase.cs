using Mirror;

namespace Assets.Scripts.SpellEffects
{

    public class SpellEffectBase : NetworkBehaviour
    {

        #region Base methods

        [Server]
        protected void ServerDestroySelf(float delay) => Destroy(gameObject, delay);
        [Server]
        protected void ServerDestroySelf() => Destroy(gameObject);

        #endregion

    }
}
