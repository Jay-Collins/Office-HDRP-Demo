using Cinemachine;
using UnityEngine;

// ---------- Please note: This script was added to the project much later after it was completed ----------
public class CameraManager : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera[] _cameras;
    private int _cameraSwitcher;

    private void OnEnable()
    {
        if (_cameras is null)
            Debug.Log("_cameras is NULL");
        GenerateCameraList();
    }

    private void Update()
    {
        CameraSwitcher();
        
        
        // quick application - needed because it runs full screen
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
    }

    private void CameraSwitcher()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (_cameraSwitcher == 0)
                _cameraSwitcher = 5;
            else
                _cameraSwitcher--;
            
            ResetCameras();
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            if (_cameraSwitcher == 5)
                _cameraSwitcher = 0;
            else
                _cameraSwitcher++;
            
            ResetCameras();
        }
        
        _cameras[_cameraSwitcher].Priority = 11;
    }

    private void ResetCameras()
    {
        foreach (var _cinemachineVirtualCamera in _cameras)
            _cinemachineVirtualCamera.Priority = 10;
    }
    
    private void GenerateCameraList() => _cameras = GetComponentsInChildren<CinemachineVirtualCamera>();
}

