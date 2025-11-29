using UnityEngine;
using UnityEngine.Events;

public class SignalBus : MonoBehaviour
{
    public UnityEvent OnPlayerNeedToRespawn { get; private set; } = new();
    public UnityEvent OnPlayerRespawned { get; private set; } = new();
    public UnityEvent OnGameOver { get; private set; } = new();
    public UnityEvent OnInvisibility { get; private set; } = new();
    public UnityEvent<bool> OnPauseStateChanged { get; private set; } = new();

    public static SignalBus Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null)
            Destroy(Instance);

        Instance = this;
    }
}
