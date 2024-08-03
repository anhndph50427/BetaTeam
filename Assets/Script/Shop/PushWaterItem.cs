using TMPro;
using UnityEditor.ShortcutManagement;
using UnityEngine;
using UnityEngine.UI;

public class PushWaterItem : MonoBehaviour
{
    [SerializeField] private PushWaterSO PushWater;
    [SerializeField] private int currentIndex;

    [Header("UI Text")]
    [SerializeField] private TextMeshProUGUI nameTxt;
    [SerializeField] private TextMeshProUGUI levelTxt;
    [SerializeField] private TextMeshProUGUI coolDownTxt;
    [SerializeField] private TextMeshProUGUI pointTxt;
    [SerializeField] private TextMeshProUGUI unlockCostTxt;
    [SerializeField] private Button UpgrateBtn;

    private void Start()
    {
        currentIndex = PushWater.indextLevel;
        loadAtribute();

        UpgrateBtn.onClick.AddListener(() => Upgrate());
    }

    void loadAtribute()
    {
        nameTxt.text = PushWater.nameSkill;
        levelTxt.text = $"{currentIndex + 1}";
        coolDownTxt.text = PushWater.infor[currentIndex].coolDonw.ToString();
        pointTxt.text = PushWater.infor[currentIndex].force.ToString();
        unlockCostTxt.text = PushWater.infor[currentIndex].UnlockCost.ToString();
    }

    void Upgrate()
    {
        currentIndex++;

        loadAtribute();
        if (currentIndex == PushWater.infor.Length - 1) UpgrateBtn.interactable = false;
    }
}
