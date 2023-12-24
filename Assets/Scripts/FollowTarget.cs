using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class FollowTarget : MonoBehaviour
{
    private Transform target;
    public float smoothSpeed = 2.0f;
    
    private void Update()
    {
        if (target != null)
        {
            Vector3 position = transform.position;
            position.x = Mathf.Clamp(target.position.x,0,19);
            transform.position = Vector3.Lerp(transform.position,position,Time.deltaTime*smoothSpeed);
        }
    }

    public void SetTarget(Transform transform)
    {
        this.target = transform;
    }

}
