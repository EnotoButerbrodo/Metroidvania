using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class MenuManadger : MonoBehaviour
{
  
    [SerializeField] private GameObject _panelGame;
    [SerializeField] private Toggle _changeCameraToggle;
    public static UnityEvent<bool> First_third_camera_Event = new UnityEvent<bool>();
    
    
    private bool _isPressed = false;


    void Start()
    {
        ChangeCameraMove.ChangedCamera.AddListener(OpenPanelGame);
    }

    private void OpenPanelGame()
    {
        _isPressed = !_isPressed;
        _panelGame.SetActive(_isPressed);
    }


    public void Camera_first_third_Face()
    {
        First_third_camera_Event.Invoke(_changeCameraToggle.isOn);
        //Debug.Log(_changeCameraToggle.isOn);
    }

}
