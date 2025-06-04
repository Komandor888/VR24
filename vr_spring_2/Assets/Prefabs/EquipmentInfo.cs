using UnityEngine;
using TMPro; // �����!

public class EquipmentInfo : MonoBehaviour
{
    [SerializeField] private GameObject infoPanel; // ���� Panel
    [SerializeField] private TextMeshProUGUI titleText; // ���� TextMeshPro
    [SerializeField] private TextMeshProUGUI descriptionText;

    public void ToggleInfoPanel()
    {
        infoPanel.SetActive(!infoPanel.activeSelf);
    }
}