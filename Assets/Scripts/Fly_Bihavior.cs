using UnityEngine;
using UnityEngine.InputSystem;

public class Fly_Bihavior : MonoBehaviour



{
    [SerializeField] float jumpForce = 7f;
    [SerializeField] float rotationSpeed = 4f;

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (
            (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame) ||
            (Touchscreen.current != null && Touchscreen.current.primaryTouch.press.wasPressedThisFrame)
           )
        {
            Flap();
        }

        RotateBird();
    }

    void Flap()
    {
        // keep current downward speed natural
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0);

        // apply upward impulse
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    void RotateBird()
    {
        float angle = Mathf.Clamp(rb.linearVelocity.y * rotationSpeed, -60, 45);
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameManager.instance.GameOver();
    }
}