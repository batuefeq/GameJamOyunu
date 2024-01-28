using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBody : MonoBehaviour
{
    public float rotationSpeed = 5f; // Rotasyon hýzý

    private void Update()
    {
        // Objeyi hareket ettiren Rigidbody bileþenini al
        Rigidbody2D rb = GetComponentInParent<Rigidbody2D>();

        if (rb.velocity.magnitude > 0.1f)
        {
            float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;

            Quaternion targetRotation = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    
        }
    }

}
