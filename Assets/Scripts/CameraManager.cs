using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] InputManagerSO inputs;
    [SerializeField] Camera[] cameras;
    int activeCameraIndex = 0;

    void OnEnable()
    {
        inputs.CycleCamera += OnCycleCamera;
    }
    void OnDisable()
    {
        inputs.CycleCamera -= OnCycleCamera;
    }

    public void OnCycleCamera(bool isPressed)
    {
        if (isPressed)
        {
            cameras[activeCameraIndex].gameObject.SetActive(false);
            if (++activeCameraIndex >= cameras.Length) activeCameraIndex = 0;
            cameras[activeCameraIndex].gameObject.SetActive(true);
        }
    }
}
