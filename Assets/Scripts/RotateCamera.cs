using UnityEngine;

public class RotateCamera : MonoBehaviour
{

    private InputSystem_Actions controls;
    public float rotationSpeed = 150f;

    void Awake()
    {
        controls = new InputSystem_Actions();
    }

    private void OnEnable()
    {
        controls.Player.Enable();
        Debug.Log(controls.Player.Move);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveInput = controls.Player.Move.ReadValue<Vector2>();
        transform.Rotate(Vector3.up, moveInput.x * rotationSpeed * Time.deltaTime);
    }
}
