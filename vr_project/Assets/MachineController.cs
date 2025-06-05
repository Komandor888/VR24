using UnityEngine;

public class MachineController : MonoBehaviour
{
    public bool isActive = false;
    public Transform processingPoint;
    public float processingTime = 3f;
    public GameObject processedPrefab;

    private GameObject currentObject;
    private float processingTimer = 0f;

    private void Update()
    {
        if (!isActive || currentObject == null) return;

        processingTimer += Time.deltaTime;

        if (processingTimer >= processingTime)
        {
            ProcessObject();
            processingTimer = 0f;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isActive || currentObject != null) return;

        currentObject = other.gameObject;
        other.gameObject.transform.position = processingPoint.position;
        other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
    }

    private void ProcessObject()
    {
        Destroy(currentObject);
        Instantiate(processedPrefab, processingPoint.position, processingPoint.rotation);
        currentObject = null;
    }

    public void ToggleMachine()
    {
        isActive = !isActive;
        // Здесь можно добавить визуальную индикацию состояния
    }
}