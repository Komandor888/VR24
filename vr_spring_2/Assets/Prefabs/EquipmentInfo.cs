using UnityEngine;
using TMPro; // ¬ажно!

public class EquipmentInfo : MonoBehaviour
{
    [SerializeField] private GameObject infoPanel; // —юда Panel
    [SerializeField] private TextMeshProUGUI titleText; // —юда TextMeshPro
    [SerializeField] private TextMeshProUGUI descriptionText;

    public void ToggleInfoPanel()
    {
        infoPanel.SetActive(!infoPanel.activeSelf);
    }
}