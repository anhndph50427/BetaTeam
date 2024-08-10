using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlantSlot : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [Header("Ui canvas")]
    [SerializeField] private Canvas canvans; 
    [SerializeField] private CanvasGroup canvasGroup;
    private Vector3 Pos; // Pos dùng để lưu vị trí kéo thả

    [Header("Object Drag")]        
    [SerializeField] private GameObject Plant_Object; // Object để sinh ra khi thả
    [SerializeField] private Image Object_Card;


    [SerializeField] int price;
    [SerializeField] TextMeshProUGUI TextPrice;

    private void Start()
    {  
        if(TextPrice != null)
        {
            TextPrice.text = price.ToString();
        }
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        if(!buyPlant()) return;

        Object_Card.gameObject.SetActive(true);
        Pos = Object_Card.rectTransform.anchoredPosition; // gán vị trí neo của object_card cho pos
        canvasGroup.blocksRaycasts = false; // Cho phép Raycast có thể xuyên qua đối tượng
        canvasGroup.alpha = 0.6f;
        DropObjectCurrent.objectCurrent = Plant_Object;
        
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!buyPlant()) return;

        Object_Card.rectTransform.anchoredPosition += eventData.delta / canvans.scaleFactor; // Tính toán kéo thả trong UI, eventData.delta: dùng để lưu trữ vị trí chuột giữa các fame
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (!buyPlant()) return;

        Object_Card.gameObject.SetActive(false);
        Object_Card.rectTransform.anchoredPosition = Pos;
        canvasGroup.blocksRaycasts = true;
        GamePlay.instance.sunScore -= price;

        DropObjectCurrent.objectCurrent = null;
    }


    bool buyPlant()
    {
        if(GamePlay.instance.sunScore >= price)
        {
            return true;
        }
        return false;

    }
}
