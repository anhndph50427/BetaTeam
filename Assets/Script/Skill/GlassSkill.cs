
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GlassSkill : MonoBehaviour
{
    [Header("CoolDown")]
    public float CoolDown;
    public float CoolDownTimer;
    public float EffectDuration;
    public bool isOnSkill;

    [Header("Colision info")]
    public Vector2 SizeBox;
    public LayerMask whatIsLayerMask;

    public Button ActiveSkill;

    private void Start()
    {
        ActiveSkill = GameObject.Find("GlassSkillBtn").GetComponent<Button>();
        ActiveSkill.onClick.AddListener(() => onButton());
    }


    private void Update()
    {
        CoolDownTimer -= Time.deltaTime;
        //if (Input.GetKeyDown(KeyCode.Space) && CoolDownTimer < 0)
        //{
        //    Debug.Log("is CoolDown");
        //    CoolDownTimer = CoolDown;
        //    isOnSkill = true;
        //}

        if(CoolDownTimer < 0)
        {
            ActiveSkill.interactable = true;
        }
        else
        {
            ActiveSkill.interactable = false;
        }
    }

    private void onButton()
    {
        Debug.Log("is CoolDown");
        CoolDownTimer = CoolDown;
        isOnSkill = true;
    }

    private void FixedUpdate()
    {
        if (isOnSkill)
        {
            checkEnemy();
        }
    }


    void checkEnemy()
    {
        RaycastHit2D[] hit = Physics2D.BoxCastAll(transform.position, SizeBox, 0, Vector2.down, whatIsLayerMask);
        foreach (var colision in hit)
        {
            if (colision.collider != null)
            {
                StartCoroutine(FreezeEnemy(colision.collider.gameObject));
            }
        }
    }

    IEnumerator FreezeEnemy(GameObject target)
    {
        ZombieBase Enemy = target.GetComponent<ZombieBase>();
        if (Enemy != null)
        {
            Debug.Log("Enemy no movement");
            Enemy.canMove = false;
            yield return new WaitForSeconds(EffectDuration);
            Debug.Log("Enemy movement");
            Enemy.canMove = true;
            isOnSkill = false;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(SizeBox.x, SizeBox.y, 0));
    }
}
