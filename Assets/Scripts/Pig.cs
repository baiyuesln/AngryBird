using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pig : Destructible
{
    public int score = 3000;
    public override void Dead()
    {
        base.Dead();
        Manager.Instance.OnPigDead();
        ScoreManager.Instance.ShowScore(transform.position,score);
    }

    protected override void PlayAudioCollision()
    {
        AudioManager.Instance.PlayPigCollision(transform.position);
    }

    protected override void PlayAudioDestoryed()
    {
    }
}
