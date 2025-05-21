using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class press_work_sc : MonoBehaviour
{
    public Vector3 leftPos; // Позиция слева
    public Vector3 rightPos; // Позиция справа

    public void OnSliderMoved(float value)
    {
        transform.position = Vector3.Lerp(leftPos, rightPos, value);
    }
}