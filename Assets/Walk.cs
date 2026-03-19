using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class Walk : MonoBehaviour {

    public float speed = 10.0F;
    public float rotationSpeed = 100.0F;

    private Rigidbody rb;
    private Vector3 movement;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null) Debug.LogWarning("Player needs a Rigidbody.");

    }

    void Update() {
        if (Keyboard.current == null) return;

        Vector2 moveInput = Vector2.zero;

        // Forward/backward
        if (Keyboard.current.wKey.isPressed || Keyboard.current.upArrowKey.isPressed) moveInput.y = 1f;
        if (Keyboard.current.sKey.isPressed || Keyboard.current.downArrowKey.isPressed) moveInput.y = -1f;

        // Left/right (rotation)
        if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed) moveInput.x = -1f;
        if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed) moveInput.x = 1f;

        // --- ФІЗИКА РУХУ МАШИНИ ---
       if (Keyboard.current.wKey.isPressed && Keyboard.current.shiftKey.isPressed)
        {
            movement = transform.forward * moveInput.y * speed*1.5f * Time.fixedDeltaTime;
            rb.MovePosition(rb.position + movement);
        }
            movement = transform.forward * moveInput.y * speed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + movement);

        float turnDirection = moveInput.x;
        if (moveInput.y < 0)
            turnDirection = -turnDirection;

        float turn = turnDirection * rotationSpeed * Time.fixedDeltaTime;
        Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);
        rb.MoveRotation(rb.rotation * turnRotation);
    }
}