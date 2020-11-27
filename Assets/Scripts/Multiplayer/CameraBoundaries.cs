using UnityEngine;

namespace Assets.Scripts.Multiplayer
{
    [System.Serializable]
    public struct CameraBoundaries
    {
        [Header("Positive Boundaries")]
        public float boundariesXPositive;
        public float boundariesZPositive;
        [Header("Negative Boundaries")]
        public float boundariesXNegative;
        public float boundariesZNegative;
    }
}
