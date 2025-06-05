using UnityEngine;
using System.Collections.Generic;

public class ConveyorBelt : MonoBehaviour
{
    public float speed = 1f;
    public Vector3 direction = Vector3.forward;
    [SerializeField] private float beltOffset = 0.5f; // Высота над конвейером

    private void OnCollisionStay(Collision collision)
    {
        Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
        if (rb != null)
        {
            // Поднимаем объект немного над конвейером
            Vector3 pos = collision.transform.position;
            pos.y = transform.position.y + beltOffset;
            collision.transform.position = pos;

            // Перемещаем объект
            rb.velocity = direction * speed;
        }
    }
}