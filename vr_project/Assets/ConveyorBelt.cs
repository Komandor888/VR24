using UnityEngine;
using System.Collections.Generic;

public class ConveyorBelt : MonoBehaviour
{
    public float speed = 1f;
    public Vector3 direction = Vector3.forward;
    [SerializeField] private float beltOffset = 0.5f; // ������ ��� ����������

    private void OnCollisionStay(Collision collision)
    {
        Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
        if (rb != null)
        {
            // ��������� ������ ������� ��� ����������
            Vector3 pos = collision.transform.position;
            pos.y = transform.position.y + beltOffset;
            collision.transform.position = pos;

            // ���������� ������
            rb.velocity = direction * speed;
        }
    }
}