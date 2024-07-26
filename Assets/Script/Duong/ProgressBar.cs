using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public Image progressBarFill; // Đối tượng Image dùng làm fill cho Progress Bar
    public RectTransform zombieHead; // Đối tượng RectTransform cho đầu zombie
    public float levelDuration = 120f; // Thời gian của một cấp độ (ví dụ: 120 giây)
    private float elapsedTime = 0f; // Thời gian đã trôi qua

    public GameObject[] flags; // Các đối tượng cờ
    public float[] flagPositions; // Vị trí của các cờ trên thanh tiến trình (giá trị từ 0-1)

    void Start()
    {
    }

    void Update()
    {
        // Cập nhật thời gian đã trôi qua
        elapsedTime += Time.deltaTime;
        // Tính toán tiến trình dựa trên thời gian đã trôi qua
        float progress = elapsedTime / levelDuration;
        // Đảm bảo giá trị tiến trình nằm trong khoảng 0-1
        progressBarFill.fillAmount = Mathf.Clamp01(progress);

        // Cập nhật vị trí của ZombieHead dựa trên tiến trình
        Vector2 position = zombieHead.anchoredPosition;
        position.x = progressBarFill.rectTransform.rect.width * progress;
        zombieHead.anchoredPosition = position;

        // Kiểm tra và kích hoạt các cờ
        for (int i = 0; i < flags.Length; i++)
        {
            if (progress >= flagPositions[i] && !flags[i].activeSelf)
            {
                flags[i].SetActive(true);
                // Gọi hàm để xử lý đợt zombie mới
                TriggerZombieWave(i);
            }
        }
    }

    void TriggerZombieWave(int waveIndex)
    {
        // Xử lý logic cho đợt zombie mới
        Debug.Log("Zombie wave " + waveIndex + " triggered!");
    }
}
