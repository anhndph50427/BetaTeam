using UnityEngine;

public class SunFlower : MonoBehaviour
{
    [SerializeField] private GameObject sun_Prefab;
    [SerializeField] private Transform posStop;
    
    void Start()
    {
        InvokeRepeating("spanwSun", 3, 4); // Hàm gọi methodName sau thời gian và sau đó sẽ lặp lại theo giây
    }

    void spanwSun()
    {
        GameObject sun = Instantiate(sun_Prefab , new Vector3(transform.position.x + Random.Range(-0.5f , 0.5f) , transform.position.y + Random.Range(0,0.5f)) , Quaternion.identity);
        sun.GetComponent<Sun>().stopPos = posStop.position.y;
    }


}
