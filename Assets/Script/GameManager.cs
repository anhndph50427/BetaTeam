using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public PushWaterSO PushWater;
    public MowerSO mowerSO;
    public SlowlySO Slowly;

    private void Awake()
    {
        if(Instance != null)
        {
            DestroyImmediate(Instance);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}
