using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//小鸟状态，等待，待发射，发射后；
public enum BirdState
{
    Waiting,
    BeforeShoot,
    AfterShoot,
    WaitToDie
}
public class Brid : MonoBehaviour
{ 
    public BirdState state = BirdState.BeforeShoot;
    private bool isMouseDown = false;
    public float maxDistance = 2.5f;
    public float flySpeed = 13f;
    protected Rigidbody2D rgd;
    private Collider2D collider;

    private bool isFlying = true;
    private bool isHaveUsedSkill = false;

    void Start()
    {
        rgd = GetComponent<Rigidbody2D>();
        rgd.bodyType = RigidbodyType2D.Static;
        collider = GetComponent<Collider2D>();
    }

    void Update()
    {
        switch (state)
        {
            case BirdState.Waiting:
                WaitControl();
                break;
            case BirdState.BeforeShoot:
                MoveControl();
                break;
            case BirdState.AfterShoot:
                StopControl();
                SkillControl();
                break;
            case BirdState.WaitToDie:
                break;
            default:
                break;
        }
    }

    private void WaitControl()
    {
        
    }

    private void SkillControl()
    {
        if(isHaveUsedSkill)
        {
            return;
        }
        if(isFlying&&Input.GetMouseButtonDown(0)) 
        {
            FlyingSkill();
            isHaveUsedSkill = true;
        }

        if (Input.GetMouseButtonDown(0))
        {
            FullTimeSkill();
            isHaveUsedSkill = true;
        }
        
    }

    protected virtual void FlyingSkill()
    {
        
    }

    protected virtual void FullTimeSkill()
    {
        
    }

    private void OnMouseDown()
    {
        if(state == BirdState.BeforeShoot && EventSystem.current.IsPointerOverGameObject() == false)
        {
            isMouseDown = true;
            SlingShoot.Instance.StartDraw(transform);
            AudioManager.Instance.PlayBirdSelect(transform.position);
        }
    }

    private void OnMouseUp()
    {
        if (state == BirdState.BeforeShoot && EventSystem.current.IsPointerOverGameObject() == false)
        {
            isMouseDown = false;
            SlingShoot.Instance.EndDraw();
            Fly();
        } 
    }

    private void MoveControl()
    {
        if(isMouseDown)
        {
            transform.position = GetMousePosition();
        }
    }

    private Vector3 GetMousePosition()
    {
        Vector3 centerPosition = SlingShoot.Instance.getCenterPosition();
        Vector3 mp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mp.z = 0;
        Vector3 mouseDir = mp - centerPosition;

        float distance = mouseDir.magnitude;
        if(distance > maxDistance)
        {
            mp = mouseDir.normalized * maxDistance + centerPosition;
        }
        return mp;
    }

    private void Fly()
    {
        rgd.bodyType = RigidbodyType2D.Dynamic;
        rgd.velocity = (SlingShoot.Instance.getCenterPosition() - transform.position).normalized * flySpeed;
        state = BirdState.AfterShoot;
        AudioManager.Instance.PlayBirdFlying(transform.position);
    }

    public void GoState(Vector3 position)
    {
        state = BirdState.BeforeShoot;  
        transform.position = position;
    }

    private void StopControl()
    {
        if(rgd.velocity.magnitude < 0.1f)
        {
            state = BirdState.WaitToDie;
            Invoke("LoadNextBird", 1f);
        }
    }

    protected void LoadNextBird()
    {
        Destroy(gameObject);
        GameObject.Instantiate(Resources.Load<GameObject>("Boom1"), transform.position, Quaternion.identity);
        Manager.Instance.LoadNextBird();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(state == BirdState.AfterShoot)
        {
            isFlying = false;

        }
        if (state == BirdState.AfterShoot && collision.relativeVelocity.magnitude > 5)
        {
            AudioManager.Instance.PlayBirdCollision(transform.position);
        }
    }
}
