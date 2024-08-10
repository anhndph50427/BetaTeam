using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UImanager : MonoBehaviour
{
    public GameObject parent;
    [Header("UI info")]
    [SerializeField] private Button Login;
    [SerializeField] private Button Register;

    [Header("GameObjec")]
    [SerializeField] private GameObject LoginObj;
    [SerializeField] private GameObject RegisterObj;
    void Start()
    {
        Login.onClick.AddListener(() => login());
        Register.onClick.AddListener(() => Registers());
    }

    void login()
    {
        LoginObj.SetActive(true);
        parent.SetActive(false);
    }

    void Registers()
    {
        RegisterObj.SetActive(true);
        parent.SetActive(false);
    }
    
}
