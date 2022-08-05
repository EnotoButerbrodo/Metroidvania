using UnityEngine;
using UnityEngine.Events;
public class ChangeCameraMove : MonoBehaviour
{

    public static UnityEvent ChangedCamera = new UnityEvent();


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) // добавленно для удобства
        {
            if(Input.GetAxis("OpenMenu") == 1)
            {
                ChangedCamera.Invoke();
            }
        }
        
    }
}
