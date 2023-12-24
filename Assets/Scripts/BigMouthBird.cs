using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigMouthBird : Brid
{
    protected override void FlyingSkill()
    {
        rgd.velocity = new Vector2(-rgd.velocity.x, rgd.velocity.y);

        transform.localScale = new Vector3(-transform.localScale.x,transform.localScale.y,transform.localScale.z);
    }
}
