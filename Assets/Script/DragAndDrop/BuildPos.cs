using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BuildPos : MonoBehaviour,IDropHandler,IPointerEnterHandler,IPointerExitHandler
{
    private Image ImagePos;
    [SerializeField] private GameObject Pos_Obj; // Plant được sinh ra ở vị trí đặt

    void Start()
    {
        ImagePos = GetComponent<Image>();
    }

    public void OnDrop(PointerEventData eventData) // Hàm Drop được lấy từ IDropHandler, có chức năng thả đến 1 vị trí được xác định
    {
        if(Pos_Obj != null) // Kiểm tra vị trí hiện tại có cây được đặt chưa
        {
            Debug.Log("Vị trí này đã có cây");
        }
        else
        {
            if(eventData.pointerDrag != null) // kiểu tra xem eventData.pointerDrag có được tham chiếu đến đối tượng được kéo không
            {
                Pos_Obj = Instantiate(DragAndDropOBJ.currentObj , transform.position , Quaternion.identity);
            }
        }
    }

    public void OnPointerEnter(PointerEventData eventData) // Hàm có chức năng là trỏ chuột vào đối tượng
    {
        ImagePos.color = new Color(1, 0, 0, 0.5f);
        //Các tham số: red , green , blue , alpha
    }

    public void OnPointerExit(PointerEventData eventData) // Hàm có chức năng là rời việc trỏ chuột vào đối tượng
    {
        ImagePos.color = new Color(1, 0, 0, 0);
    }
}
