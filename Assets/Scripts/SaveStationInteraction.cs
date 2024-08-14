using System;
using UnityEngine;

public class SaveStationInteraction : MonoBehaviour, IInteraction
{
    [SerializeField] private UIWindow _levelUpWindow;

    public event Action Finished;

    public void StartInteraction()
    {
        _levelUpWindow.gameObject.SetActive(true);
    }

    private void OnEnable()
    {
        _levelUpWindow.Closed += OnClosed;
    }

    private void OnDisable()
    {
        _levelUpWindow.Closed -= OnClosed;
    }

    private void OnClosed()
    {
        Finished?.Invoke();
    }

    public void ApplyInteractionState(IInteractionApplyerState state)
    {
        state.ApplyInteraction<UseSaveStationState>();
    }
}
