using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName = "InputManager", menuName = "InputManager SO", order = -215)]
public class InputManagerSO : ScriptableObject
{
    public event UnityAction<bool, Vector2> Move1, Move2;
    public event UnityAction<bool> Taunt1, Taunt2, CycleCamera;

    AllInputs inputs;

    private void OnEnable()
    {
        inputs = new AllInputs();
        inputs.Enable();
        inputs.All.Enable();
        inputs.All.Move1.performed += OnMovePerformed1;
        inputs.All.Move2.performed += OnMovePerformed2;
        inputs.All.Taunt1.performed += OnTauntPerformed1;
        inputs.All.Taunt2.performed += OnTauntPerformed2;
        inputs.All.CycleCamera.performed += OnCycleCameraPerformed;
        inputs.All.CycleCamera.canceled += OnCycleCameraCanceled;
        inputs.All.Taunt1.canceled += OnTauntCanceled1;
        inputs.All.Taunt2.canceled += OnTauntCanceled2;
        inputs.All.Move1.canceled += OnMoveCanceled1;
        inputs.All.Move2.canceled += OnMoveCanceled2;
    }
    private void OnDisable()
    {
        inputs.All.Move1.canceled -= OnMoveCanceled1;
        inputs.All.Move2.canceled -= OnMoveCanceled2;
        inputs.All.Taunt1.canceled -= OnTauntCanceled1;
        inputs.All.Taunt2.canceled -= OnTauntCanceled2;
        inputs.All.CycleCamera.canceled -= OnCycleCameraCanceled;
        inputs.All.CycleCamera.performed -= OnCycleCameraPerformed;
        inputs.All.Taunt1.performed -= OnTauntPerformed1;
        inputs.All.Taunt2.performed -= OnTauntPerformed2;
        inputs.All.Move1.performed -= OnMovePerformed1;
        inputs.All.Move2.performed -= OnMovePerformed2;
        inputs.All.Disable();
        inputs.Disable();
    }

    private void OnMovePerformed1(InputAction.CallbackContext context) => Move1?.Invoke(true, context.ReadValue<Vector2>());
    private void OnMovePerformed2(InputAction.CallbackContext context) => Move2?.Invoke(true, context.ReadValue<Vector2>());
    private void OnTauntPerformed1(InputAction.CallbackContext context) => Taunt1?.Invoke(true);
    private void OnTauntPerformed2(InputAction.CallbackContext context) => Taunt2?.Invoke(true);
    private void OnCycleCameraPerformed(InputAction.CallbackContext context) => CycleCamera?.Invoke(true);

    private void OnMoveCanceled1(InputAction.CallbackContext context) => Move1?.Invoke(false, context.ReadValue<Vector2>());
    private void OnMoveCanceled2(InputAction.CallbackContext context) => Move2?.Invoke(false, context.ReadValue<Vector2>());
    private void OnTauntCanceled1(InputAction.CallbackContext context) => Taunt1?.Invoke(false);
    private void OnTauntCanceled2(InputAction.CallbackContext context) => Taunt2?.Invoke(false);
    private void OnCycleCameraCanceled(InputAction.CallbackContext context) => CycleCamera?.Invoke(false);
}