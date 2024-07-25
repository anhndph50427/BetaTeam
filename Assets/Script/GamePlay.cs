using UnityEngine;

public class GamePlay : MonoBehaviour
{
    // Thuộc tính singleton để truy cập GamePlay từ bất kỳ đâu
    public static GamePlay instance { get; private set; }

    // LayerMask để xác định lớp các đối tượng mà Raycast sẽ kiểm tra va chạm
    public LayerMask whatIsMask;

    // Biến để lưu trữ số điểm sunScore
    public int sunScore;

    // Phương thức Awake được gọi khi script này được khởi tạo
    private void Awake()
    {
        // Thiết lập singleton instance
        instance = this;
    }

    // Phương thức Update được gọi một lần mỗi khung hình
    private void Update()
    {
        // Tạo một Raycast từ vị trí của chuột trong thế giới tới điểm không giới hạn (Mathf.Infinity)
        RaycastHit2D touch = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, Mathf.Infinity, whatIsMask);

        // Kiểm tra nếu raycast trúng một collider
        if (touch.collider != null)
        {
            // Nếu nhấp chuột trái (chuột số 0) được thực hiện
            if (Input.GetMouseButtonDown(0))
            {
                // Thiết lập biến isTouch của đối tượng bị va chạm thành true
                touch.collider.gameObject.GetComponent<Sun>().isTouch = true;
            }
        }
    }
}
