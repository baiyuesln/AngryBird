using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackBrid : Brid
{
    public float boomRadius = 2.5f;
    protected override void FullTimeSkill()
    {
        Collider2D[] collider2Ds = Physics2D.OverlapCircleAll(transform.position, boomRadius);
        foreach(Collider2D collider in collider2Ds)
        {
            Destructible des = collider.GetComponent<Destructible>();
            if(des != null)
            {
                des.TakeDamage(int.MaxValue);
            }
        }
        state = BirdState.WaitToDie;
        LoadNextBird();
    }
}
