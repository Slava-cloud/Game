using UnityEngine;

public class hit : MonoBehaviour
{
    private Vector3 originalScale;
    private Color originalColor;
    private bool isHit = false;
    private readonly float hitDuration = 1f;
    private float hitTimer = 0f;
    private Renderer rend;
    private Rigidbody rb;
    private int hp = 3; // Add HP field

    void Start()
    {
        originalScale = transform.localScale;
        rend = GetComponent<Renderer>();
        if (rend != null)
            originalColor = rend.material.color;
        rb = GetComponent<Rigidbody>();
    }

    void OnMouseDown()
    {
        if (!isHit)
        {
            isHit = true;
            hitTimer = 0f;
            transform.localScale = originalScale * 0.5f;
            if (rend != null)
                rend.material.color = Color.red;
            if (rb != null)
                rb.linearVelocity = Vector3.zero;

            hp--; // Decrease HP on hit
            if (hp <= 0)
            {
                Destroy(gameObject); // Destroy enemy if HP is 0
            }
        }
    }

    void Update()
    {
        if (isHit)
        {
            hitTimer += Time.deltaTime;
            if (rb != null)
                rb.linearVelocity = Vector3.zero; // Stop movement

            if (hitTimer >= hitDuration)
            {
                // Restore to normal
                transform.localScale = originalScale;
                if (rend != null)
                    rend.material.color = originalColor;
                isHit = false;
            }
        }
    }
}
