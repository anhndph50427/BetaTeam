using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MowerItem : MonoBehaviour
{
    [SerializeField] private MowerSO mower;
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
        currentIndex = mower.indexLevel;
        loadAtribute();

        UpgrateBtn.onClick.AddListener(() => Upgrate());

    }

    void loadAtribute()
    {
        nameTxt.text = mower.nameSkill;
        levelTxt.text = $"{currentIndex + 1}";
        coolDownTxt.text = mower.infor[currentIndex].coolDown.ToString();
        pointTxt.text = mower.infor[currentIndex].reduceSpeed.ToString();
        unlockCostTxt.text = mower.infor[currentIndex].UnlockCost.ToString();
    }

    void Upgrate()
    {
        currentIndex++;

        loadAtribute();
        if (currentIndex == mower.infor.Length - 1) UpgrateBtn.interactable = false;
    }
}
