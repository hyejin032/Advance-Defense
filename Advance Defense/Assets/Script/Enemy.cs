using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int hp = 3;
    public float moveSpeed = 2f;
    public float attackCooldown = 1.5f;
    public float attackRange = 0.5f;
    public int damage = 1;
    public LayerMask PlayerLayer;
    public Transform attackPoint;
    private float lastAttackTime;
    SpriteRenderer spriter;
    Animator anim;
    Collider2D col;

    void Start()
    {
        spriter = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        Collider2D col = GetComponent<Collider2D>();
        if (attackPoint == null)
        {
            attackPoint = transform.Find("AttackPointE");
        }
    }
    void Update()
    {
        Collider2D[] targets = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, PlayerLayer);
        if (targets.Length == 0)
        {
            transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
        }
        else if (Time.time - lastAttackTime >= attackCooldown)
        {
            foreach (Collider2D target in targets)
            {
                Base baseScript = target.GetComponent<Base>();
                if (baseScript != null)
                {
                    baseScript.TakeDamage(damage);
                }

                PlayerMovement playerScript = target.GetComponent<PlayerMovement>();
                if (playerScript != null)
                {
                    playerScript.PlayerHp -= damage;
                }
            }

            anim.SetTrigger("doAttack");
            lastAttackTime = Time.time;
        }
    }
    void OnDrawGizmosSelected()
    {
        if (attackPoint != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(attackPoint.position, attackRange);
        }
    }
    public void TakeDamage(int damage)
    {
        hp -= damage;
        if (hp > 0)
        {
            anim.SetTrigger("doHit");
        }
        if (hp <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        anim.SetTrigger("doDie");
        Destroy(gameObject, 1);
    }
}