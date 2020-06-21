using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTowardsPlayer : MonoBehaviour
{
    Transform target;
    float speed = 5;

    private void Start()
    {
        target = GameObject.Find("Player").GetComponent<Transform>() ;
    }

    private void Update()
    {
        Vector3 vectorToTarget = target.position - transform.position;
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * speed);
    }
}
