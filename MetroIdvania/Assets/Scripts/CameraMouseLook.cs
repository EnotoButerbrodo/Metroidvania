using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraMouseLook : MonoBehaviour
{
    

    [SerializeField] [Range(0,500)] private float MouseSensitivity = 250f;
    [SerializeField] private Transform playerBody;
    [SerializeField] private Transform _firstPoint;
    [SerializeField] private Transform _thirdPoint;


    [SerializeField] [Range(-180,180)] private float _upLockRotation, _downLockRotation;


    private float xRotation = 0;
    private bool _orientationCamera = false;

    /*
        _orientationCamera = false -> First Camera
        _orientationCamera = True -> Third Camera
    */
     private bool _isPressed = false;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        ChangeCameraMove.ChangedCamera.AddListener(LookCursor);      
        MenuManadger.First_third_camera_Event.AddListener(ChangeCameraOrientation); 
    }

    void Update()
    {

        if(!_orientationCamera)
        {
           
           
            //получение позиции мышки для просчёта вектора поворота
            float mouseX = Input.GetAxis("Mouse X") * MouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * MouseSensitivity * Time.deltaTime;

            xRotation -= mouseY;

            xRotation = Mathf.Clamp(xRotation,_downLockRotation,_upLockRotation);

            transform.localRotation = Quaternion.Euler(xRotation,0f,0f);
            playerBody.Rotate(Vector3.up * mouseX);
        } else 
        {   
            
           

            float mouseX = Input.GetAxis("Mouse X") * MouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * MouseSensitivity * Time.deltaTime;

            xRotation -= mouseY;

            xRotation = Mathf.Clamp(xRotation,_downLockRotation,_upLockRotation);

            transform.localRotation = Quaternion.Euler(xRotation,0f,0f);
            playerBody.Rotate(Vector3.up * mouseX);
        }
       


    }

    private void ChangeCameraOrientation(bool _isOn)
    {
        _orientationCamera = _isOn;
        if(!_orientationCamera)
        {
            Debug.Log("First Controller");

            gameObject.transform.position = _firstPoint.position;
        } else 
        {
            Debug.Log("ThirdController");
            gameObject.transform.position = _thirdPoint.position;
        }
    }
    private void LookCursor()
    {
        if(!_isPressed) Cursor.lockState = CursorLockMode.None;
        else Cursor.lockState = CursorLockMode.Locked;

        _isPressed = !_isPressed;
    }
}
