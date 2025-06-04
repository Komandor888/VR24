using UnityEngine;
using UnityEngine.XR.ARFoundation;
using System.Collections;

public class AR_setup : MonoBehaviour
{
    [SerializeField] private ARSession m_Session;
    [SerializeField] private ARRaycastManager m_RaycastManager;
    [SerializeField] private ARPlaneManager m_PlaneManager;

    private void Start()
    {
        StartCoroutine(CheckARSupport());
    }

    private IEnumerator CheckARSupport()
    {
        if (ARSession.state == ARSessionState.None ||
            ARSession.state == ARSessionState.CheckingAvailability)
        {
            yield return ARSession.CheckAvailability();
        }

        if (ARSession.state == ARSessionState.Unsupported)
        {
            Debug.LogError("AR не поддерживается на этом устройстве");
            // Здесь можно показать UI сообщение пользователю
        }
        else
        {
            // AR поддерживается, можно продолжать инициализацию
            Debug.Log("AR поддерживается, состояние: " + ARSession.state);
        }
    }
}