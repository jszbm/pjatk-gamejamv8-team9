using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Player
{
    class PlayerObject : MonoBehaviour
    {
        public static PlayerObject Instance;
        public bool IsInvisible { get; private set; } = false;

        [SerializeField] private float timeForInvisibility = 1f;

        private void Awake() => Instance = this;

        private void OnDestroy()
        {
            if (Instance == this)
            {
                Instance = null;
            }

            if (SignalBus.Instance != null)
            {
                SignalBus.Instance.OnInvisibility.RemoveListener(HandleInvisibility);
            }
        }

        private void Start()
        {
            SignalBus.Instance.OnInvisibility.AddListener(HandleInvisibility);
        }

        private void HandleInvisibility()
        {
            StartCoroutine(Invisibility());
        }

        private IEnumerator Invisibility()
        {
            IsInvisible = true;
            yield return new WaitForSeconds(timeForInvisibility);
            IsInvisible = false;
        }
    }
}
