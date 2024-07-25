using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ImageHoverEffect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    private Image image;
    public Color hoverColor = Color.gray; // Màu khi di chuột vào
    private Color originalColor;
    public Canvas targetCanvas; // Canvas cần ẩn/hiện
    private CanvasGroup canvasGroup;

    void Start()
    {
        image = GetComponent<Image>();
        if (image != null)
        {
            originalColor = image.color;

            // Kiểm tra texture có thể đọc được không trước khi đặt alphaHitTestMinimumThreshold
            if (image.sprite.texture.isReadable)
            {
                image.alphaHitTestMinimumThreshold = 0.1f;
            }
            else
            {
                Debug.LogError("Texture không thể đọc được. Bật 'Read/Write Enabled' trong cài đặt nhập của texture.");
            }

            // Thiết lập CanvasGroup nếu có
            if (targetCanvas != null)
            {
                canvasGroup = targetCanvas.GetComponent<CanvasGroup>();
            }
        }
        else
        {
            Debug.LogError("Image component not found!");
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (image != null)
        {
            image.color = hoverColor;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (image != null)
        {
            image.color = originalColor;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (targetCanvas != null)
        {
            if (canvasGroup != null)
            {
                // Toggle visibility and raycast blocking
                bool isActive = targetCanvas.gameObject.activeSelf;
                targetCanvas.gameObject.SetActive(!isActive);
                canvasGroup.blocksRaycasts = !isActive;
            }
            else
            {
                // Nếu không có CanvasGroup, chỉ cần toggle visibility
                targetCanvas.gameObject.SetActive(!targetCanvas.gameObject.activeSelf);
            }
        }
    }
}
