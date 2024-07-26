using System.Collections.Generic;
using UnityEngine;

public class NotificationManager : MonoBehaviour
{
    [System.Serializable]
    public class Notification
    {
        public GameObject zombiePrefab; // Prefab của zombie
        public string message;          // Nội dung thông báo
        public int showTime;            // Thời gian để in ra thông báo (tính bằng giây)
        public bool hasShown;           // Đã hiển thị hay chưa
    }

    public List<Notification> notifications; // Danh sách các thông báo
    public List<Transform> spawnPoints;      // Danh sách các điểm spawn cho zombie
    public int currentGameTime;              // Thời gian chạy của game

    void Update()
    {
        // Cập nhật thời gian hiện tại của game, làm tròn xuống số nguyên gần nhất
        currentGameTime = Mathf.FloorToInt(Time.time);

        // Kiểm tra từng thông báo
        foreach (Notification notification in notifications)
        {
            if (!notification.hasShown && currentGameTime >= notification.showTime)
            {
                // In ra thông báo
                Debug.Log(notification.message);

                // Chọn một điểm spawn ngẫu nhiên
                int randomIndex = Random.Range(0, spawnPoints.Count);
                Transform spawnPoint = spawnPoints[randomIndex];

                // Tạo zombie tại điểm spawn ngẫu nhiên
                Instantiate(notification.zombiePrefab, spawnPoint.position, Quaternion.identity);

                // Đánh dấu thông báo đã được hiển thị
                notification.hasShown = true;
            }
        }
    }
}
