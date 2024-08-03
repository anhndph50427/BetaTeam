using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopUI : MonoBehaviour
{
    public GameObject[] target;
    public int Coins;

    public Button NextBtn;
    public Button PreviouBtn;

    public int selectIndex;
    void Start()
    {
        showGameObject(target[0]);

        if (selectIndex == target.Length - 1) NextBtn.interactable = false;
        if(selectIndex == 0) PreviouBtn.interactable = false;

        NextBtn.onClick.AddListener(() => Next());
        PreviouBtn.onClick.AddListener(() => Previous());
    }

    void showGameObject(GameObject obj)
    {
        foreach(GameObject gameObject in target)
        {
            gameObject.SetActive(false);
        }

        if(obj != null)
        {
            obj.SetActive(true);
        }
    }
    
    void Next()
    {
        target[selectIndex].SetActive(false);
        selectIndex++;
        target[selectIndex].SetActive(true);

        if (selectIndex == target.Length - 1) NextBtn.interactable = false;
        if(!PreviouBtn.interactable) PreviouBtn.interactable = true;

    }

    void Previous()
    {
        target[selectIndex].SetActive(false);
        selectIndex--;
        target[selectIndex].SetActive(true);
        

        if(selectIndex == 0) PreviouBtn.interactable = false;
        if(!NextBtn.interactable) NextBtn.interactable = true;

    }
}
