using TMPro;
using UnityEditor.ShortcutManagement;
using UnityEngine;
using UnityEngine.UI;

public class PushWaterItem : MonoBehaviour
{
    [SerializeField] private PushWaterSO PushWater;
    [SerializeField] private int indexLevel;
    [SerializeField] private int indexSave;

    [Header("UI Text")]
    [SerializeField] private TextMeshProUGUI nameTxt;
    [SerializeField] private TextMeshProUGUI levelTxt;
    [SerializeField] private TextMeshProUGUI coolDownTxt;
    [SerializeField] private TextMeshProUGUI pointTxt;
    [SerializeField] private TextMeshProUGUI unlockCostTxt;
    [SerializeField] private Button UpgrateBtn;

    private void Start()
    {
        indexLevel = PushWater.indextLevel;
        indexSave = PlayerPrefs.GetInt("indexLevel");
        Debug.Log(indexSave);
        loadAtribute();

        UpgrateBtn.onClick.AddListener(() => Upgrate());
    }

    private void Update()
    {
        PlayerPrefs.SetInt("indexLevel", indexLevel);
    }

    void loadAtribute()
    {
        nameTxt.text = PushWater.nameSkill;
        levelTxt.text = $"{indexSave + 1}";
        coolDownTxt.text = PushWater.infor[indexSave].coolDonw.ToString();
        pointTxt.text = PushWater.infor[indexSave].force.ToString();
        unlockCostTxt.text = PushWater.infor[indexSave].UnlockCost.ToString();
    }

    void Upgrate()
    {
        indexSave++;

        loadAtribute();
        if (indexSave == PushWater.infor.Length - 1) UpgrateBtn.interactable = false;
    }
}
