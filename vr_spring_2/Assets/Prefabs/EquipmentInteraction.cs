using UnityEngine;

public class EquipmentInteraction : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 10f;
    [SerializeField] private float scaleSpeed = 0.1f;

    private bool isRotating;
    private bool isScaling;
    private Vector2 lastTouchPosition;

    private void Update()
    {
        if (Input.touchCount == 1 && isRotating)
        {
            // Вращение оборудования
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                float rotationX = touch.deltaPosition.x * rotationSpeed * Time.deltaTime;
                float rotationY = touch.deltaPosition.y * rotationSpeed * Time.deltaTime;

                transform.Rotate(Vector3.up, -rotationX, Space.World);
                transform.Rotate(Vector3.right, rotationY, Space.World);
            }
        }
        else if (Input.touchCount == 2)
        {
            // Масштабирование оборудования
            Touch touch0 = Input.GetTouch(0);
            Touch touch1 = Input.GetTouch(1);

            Vector2 touch0PrevPos = touch0.position - touch0.deltaPosition;
            Vector2 touch1PrevPos = touch1.position - touch1.deltaPosition;

            float prevMagnitude = (touch0PrevPos - touch1PrevPos).magnitude;
            float currentMagnitude = (touch0.position - touch1.position).magnitude;

            float difference = currentMagnitude - prevMagnitude;

            transform.localScale += Vector3.one * difference * scaleSpeed * Time.deltaTime;
            transform.localScale = Vector3.Max(transform.localScale, Vector3.one * 0.1f);
        }
    }

    public void ToggleRotation()
    {
        isRotating = !isRotating;
    }
}