using System.Threading.Tasks;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float Playerspeed = 1f;
    public float PlayerHp = 5f;
    public float Cooldown = 0.7f;
    public float AttackRange = 0.1f;
    public Vector3 inputVec;

    public Transform attackPoint;
    public LayerMask enemyLayer;

    Rigidbody2D rigid;
    SpriteRenderer spriter;
    Animator anim;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigid = gameObject.GetComponent<Rigidbody2D>();
        spriter = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Cooldown += Time.deltaTime;
        if (Cooldown >= 0.7f)
        {
            Attack();
        }
    }
    void FixedUpdate()
    {
        Move();
    }
    void Move()
    {
        inputVec.x = Input.GetAxisRaw("Horizontal");
        float newX = transform.position.x + inputVec.x * Playerspeed * Time.deltaTime;
        float minX = -7f;
        float maxX = 7f;
        newX = Mathf.Clamp(newX, minX, maxX);

        transform.position = new Vector3(newX, transform.position.y, transform.position.z);

        if (inputVec.x != 0)
        {
            Vector3 attackPos = attackPoint.localPosition;
            attackPos.x = Mathf.Abs(attackPos.x) * Mathf.Sign(inputVec.x);
            attackPoint.localPosition = attackPos;
        }
    }
    void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, AttackRange, enemyLayer);
            foreach (Collider2D enemy in hitEnemies)
            {
                Enemy enemyScript = enemy.GetComponent<Enemy>();
                if (enemyScript != null)
                {
                    enemyScript.TakeDamage(1);
                }
                else
                {
                    Base baseScript = enemy.GetComponent<Base>();
                    if (baseScript != null)
                    {
                        baseScript.TakeDamage(1);
                    }
                }
            }

            anim.SetTrigger("doAttack");
            Cooldown = 0f;
        }
    }

    void LateUpdate()
    {
        if (inputVec.x != 0)
        {
            spriter.flipX = inputVec.x < 0;
        }
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(attackPoint.position, AttackRange);
        }
    }

}
