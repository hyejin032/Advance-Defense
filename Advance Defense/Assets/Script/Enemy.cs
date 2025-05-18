using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int hp = 3;
    
    SpriteRenderer spriter;
    Animator anim;
    Collider2D col;

    void Start()
    {
        spriter = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        Collider2D col = GetComponent<Collider2D>();
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