using UnityEngine;

public class InputManager: MonoBehaviour
{
    public float HorizontalAxis { get; private set; }
    public float VerticalAxis { get; private set; }
    
    private void Update()
    {
        HorizontalAxis = Input.GetAxisRaw("Horizontal");
        VerticalAxis = Input.GetAxisRaw("Vertical");

       
    }
}
