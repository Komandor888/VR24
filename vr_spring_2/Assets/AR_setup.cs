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
            Debug.LogError("AR �� �������������� �� ���� ����������");
            // ����� ����� �������� UI ��������� ������������
        }
        else
        {
            // AR ��������������, ����� ���������� �������������
            Debug.Log("AR ��������������, ���������: " + ARSession.state);
        }
    }
}