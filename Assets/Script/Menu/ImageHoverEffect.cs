using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEditor;

public class ImageHoverEffect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    private Image image;
    public Color hoverColor = Color.gray;
    private Color originalColor;
    public GameObject targetGameobj;  // Đối tượng cần ẩn/hiện khi click
    public GameObject targetGameobj_2; // Đối tượng thứ hai cần ẩn/hiện khi click
    public SceneAsset sceneToLoad;  // SceneAsset để kéo thả cảnh vào từ Editor
    public bool isStopStart;
    
    void Start()
    {
        image = GetComponent<Image>();
        if (image != null)
        {
            originalColor = image.color;

            // Kiểm tra nếu texture có thể đọc được
            if (image.sprite.texture.isReadable)
            {
                image.alphaHitTestMinimumThreshold = 0.1f;
            }
            else
            {
                Debug.LogError("Texture không thể đọc được. Hãy bật 'Read/Write Enabled' trong cài đặt nhập của texture.");
            }
        }
        else
        {
            Debug.LogError("Không tìm thấy thành phần Image!");
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
        // Ẩn hoặc hiện targetGameobj khi nhấp vào hình ảnh
        if (targetGameobj != null)
        {
            targetGameobj.SetActive(!targetGameobj.activeSelf);
        }

        // Ẩn hoặc hiện targetGameobj_2 khi nhấp vào hình ảnh
        if (targetGameobj_2 != null)
        {
            targetGameobj_2.SetActive(!targetGameobj_2.activeSelf);
        }

        // Chuyển cảnh nếu sceneToLoad không rỗng
        if (sceneToLoad != null)
        {
            GamePlay.GameTime = 0f;
            string sceneName = sceneToLoad.name; 
            SceneManager.LoadScene(sceneName);
            
        }

        // tạm dừng hoặc tiếp tục game
        if (isStopStart)
        {
            GamePlay.instance.gamePaused();
        }
    }
}
