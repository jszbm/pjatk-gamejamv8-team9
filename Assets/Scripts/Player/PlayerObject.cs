using UnityEngine;

namespace Assets.Scripts.Player
{
    class PlayerObject : MonoBehaviour
    {
        public static PlayerObject Instance;

        private void Awake() => Instance = this;

        private void OnDestroy()
        {
            if (Instance == this)
            {
                Instance = null;
            }
        }
    }
}
