using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

// Измените базовый класс с:
// public class MachineInteractable : XRBaseInteractable
// на:
public class MachineInteractable : XRSimpleInteractable
{
    public MachineController machineController;

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);
        machineController.ToggleMachine();
    }
}