using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlantSlot : MonoBehaviour, IBeginDragHandler, IDragHandler , IEndDragHandler
{
    [Header("Drag")]
    [SerializeField] private Image Object_Card; // Image sẽ hiện khi kéo
    [SerializeField] private Canvas canvas;
    [SerializeField] private CanvasGroup canvasGroup;
    private Vector3 pos; // Lưu vị trí neo của thẻ

    [Header("Plant Object")]
    [SerializeField] private GameObject Object_Plant;

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("Start on Drag");
        Object_Card.gameObject.SetActive(true);
        pos = Object_Card.rectTransform.anchoredPosition; // lấy vị trí neo ban đầu của thẻ gán cho pos, anchoredPosition: Vị trí của rectTransform so với điểm tham chiếu neo
        canvasGroup.blocksRaycasts = false;
        canvasGroup.alpha = 0.6f;
        DragAndDropOBJ.currentObj = Object_Plant;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("Drag");
        Object_Card.rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor; // Tính toán việc kéo object
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("Kết thúc kéo thả");
        Object_Card.gameObject.SetActive(false);
        Object_Card.rectTransform.anchoredPosition = pos; // Khi kết thúc việc kéo, gắn vị trí điểm neo hiện tại cho pos
        canvasGroup.blocksRaycasts = true;
    }
}
