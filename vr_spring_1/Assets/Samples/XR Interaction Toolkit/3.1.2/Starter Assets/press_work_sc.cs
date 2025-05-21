using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class press_work_sc : MonoBehaviour
{
    public Vector3 leftPos; // ������� �����
    public Vector3 rightPos; // ������� ������

    public void OnSliderMoved(float value)
    {
        transform.position = Vector3.Lerp(leftPos, rightPos, value);
    }
}