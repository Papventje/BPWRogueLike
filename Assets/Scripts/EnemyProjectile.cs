using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public float speed;
    Transform target;

    private void Start()
    {
        Destroy(gameObject, 3f);
        target = GameObject.Find("Player").GetComponent<Transform>();
    }

    private void Update()
    {
        Bullet();
    }

    void Bullet()
    {
        Vector3 targetDirection = target.position - transform.position;
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, .8f * Time.deltaTime, 0.0f);
        transform.rotation = Quaternion.LookRotation(newDirection);

        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
