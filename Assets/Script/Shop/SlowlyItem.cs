using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SlowlyItem : MonoBehaviour
{
    [SerializeField] private SlowlySO Slowly;
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
        currentIndex = Slowly.indexLevel;
        loadAtribute();

        UpgrateBtn.onClick.AddListener(() => Upgrate());
    }

    void loadAtribute()
    {
        nameTxt.text = Slowly.nameSkill;
        levelTxt.text = $"{currentIndex + 1}";
        coolDownTxt.text = Slowly.infor[currentIndex].coolDown.ToString();
        pointTxt.text = Slowly.infor[currentIndex].TimeStopMove.ToString();
        unlockCostTxt.text = Slowly.infor[currentIndex].UnlockCost.ToString();
    }

    void Upgrate()
    {

        currentIndex++;
        loadAtribute();
        if (currentIndex == Slowly.infor.Length - 1) UpgrateBtn.interactable = false;
    }
}
