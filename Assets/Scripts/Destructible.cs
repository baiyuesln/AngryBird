using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour
{
    public int maxHP = 100;
    private int currentHP;

    public List<Sprite> injuredSpriteList;
    private SpriteRenderer spriteRenderer;

    private GameObject boomPrefab;
    private void Start()
    {
        currentHP = maxHP;
        spriteRenderer = GetComponent<SpriteRenderer>();
        boomPrefab = Resources.Load<GameObject>("Boom1");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        TakeDamage((int)collision.relativeVelocity.magnitude * 10);
    }

    public void TakeDamage(int damage)
    {
        currentHP -= damage;
        if (currentHP <= 0)
        {
            Dead(); 
            return;

        }
        //��������ʧ��Ѫ�����Ծ��ֵ�Ѫ���õ���Ҫ��ʵ��sprite���
        Sprite beforeSprite = spriteRenderer.sprite;
        int index = (int)((maxHP - currentHP) / (maxHP / (injuredSpriteList.Count + 1.0f))) - 1;
        if (index > 0)
        {
            spriteRenderer.sprite = injuredSpriteList[index];
        }
        if (beforeSprite != spriteRenderer.sprite)
        {
            PlayAudioCollision();
        }
    }

    public virtual void Dead()
    {
        PlayAudioCollision();
        GameObject.Instantiate(boomPrefab,transform.position,Quaternion.identity);
        Destroy(gameObject) ;
    }

    protected virtual void PlayAudioCollision()
    {
        AudioManager.Instance.PlayWoodCollision(transform.position);
    }

    protected virtual void PlayAudioDestoryed()
    {
        AudioManager.Instance.PlayWoodDestoryed(transform.position);
    }
}
