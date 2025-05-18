using UnityEngine;
using System.Collections;

public class Base : MonoBehaviour
{
    public float BaseHp = 5f;

    public Sprite hitSprite;  
    public Sprite desSprite;

    SpriteRenderer spriter;
    Sprite originalSprite;

    void Start()
    {
        spriter = GetComponent<SpriteRenderer>();
        originalSprite = spriter.sprite;  // 원래 스프라이트 저장
    }

    public void TakeDamage(int damage)
    {
        BaseHp -= damage;

        if (BaseHp > 0)
        {
            spriter.sprite = hitSprite;
            StartCoroutine(ResetSpriteAfterDelay(0.3f));  // 0.3초 후 원래 스프라이트로 복원
        }
        else
        {
            Die();
        }
    }

    IEnumerator ResetSpriteAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        spriter.sprite = originalSprite;
    }

    void Die()
    {
        spriter.sprite = desSprite;
        Destroy(gameObject, 3f);
    }
}
