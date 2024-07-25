using UnityEngine;

public class GamePlay : MonoBehaviour
{
    public static GamePlay instance {  get; private set; }
    public LayerMask whatIsMask;
    public int sunScore;
    private void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    private void Update()
    {
        RaycastHit2D touch = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, Mathf.Infinity, whatIsMask);
        if (touch.collider != null)
        {
            if (Input.GetMouseButtonDown(0))
            {
                touch.collider.gameObject.GetComponent<Sun>().isTouch = true;
            }

        }
    }
}
