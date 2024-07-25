using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ImageHoverEffect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    private Image image;
    public Color hoverColor = Color.gray; 
    private Color originalColor;
    public Canvas targetCanvas;

    void Start()
    {
        image = GetComponent<Image>();
        if (image != null)
        {
            originalColor = image.color;

           
            if (image.sprite.texture.isReadable)
            {
                image.alphaHitTestMinimumThreshold = 0.1f;
            }
            else
            {
                Debug.LogError("Texture không thể đọc đượ");
            }
        }
        else
        {
            Debug.LogError("lỗi");
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
            
            targetCanvas.gameObject.SetActive(!targetCanvas.gameObject.activeSelf);
        }
    }
}
