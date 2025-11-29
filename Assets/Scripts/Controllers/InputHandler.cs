using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.Scripts.Controllers
{
    class InputHandler : MonoBehaviour
    {
        [SerializeField] private PlayerInput playerInput;

        public static InputHandler Instance { get; private set; }
        public InputAsset InputActions { get; private set; }

        private string[] inputsToLock = { "Movement" };

        private void Awake()
        {
            if (Instance != null)
                Destroy(Instance);
            Instance = this;

            InputActions = new();
            playerInput.actions = InputActions.asset;
        }

        private void Start()
        {
            //SignalBus.Instance.OnGameOver.AddListener(LockInputs);
            SignalBus.Instance.OnPlayerNeedToRespawn.AddListener(LockInputs);
            SignalBus.Instance.OnPlayerRespawned.AddListener(UnlockInputs);
            SignalBus.Instance.OnPauseStateChanged.AddListener(HandlePauseEvent);
        }

        private void OnEnable() => InputActions.Enable();

        private void OnDisable() => InputActions.Disable();

        private void OnDestroy()
        {
            if (SignalBus.Instance != null)
            {
                //SignalBus.Instance.OnGameOver.RemoveListener(LockInputs);
                SignalBus.Instance.OnPlayerNeedToRespawn.RemoveListener(LockInputs);
                SignalBus.Instance.OnPlayerRespawned.RemoveListener(UnlockInputs);
                SignalBus.Instance.OnPauseStateChanged.RemoveListener(HandlePauseEvent);
            }

            TogglePlayerInput(false);
        }

        private void LockInputs() => InputActions.Disable();

        private void UnlockInputs() => InputActions.Enable();

        private void HandlePauseEvent(bool isPaused)
        {
            TogglePlayerInput(isPaused);
        }

        private void TogglePlayerInput(bool isPaused)
        {
            foreach (string m in inputsToLock)
            {
                if (isPaused)
                {
                    playerInput.actions.FindActionMap(m)?.Disable();
                }
                else
                {
                    playerInput.actions.FindActionMap(m)?.Enable();
                }
            }
        }
    }
}
