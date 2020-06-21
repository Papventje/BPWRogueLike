using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Transform target;

    public GameObject laser;
    public GameObject EMObject;

    public float speed;
    public float distanceToPlayer;
    public float fireDistance;
    public float fireRate;
    float dist;
    float nextFire;

    private void Start()
    {
        target = GameObject.Find("Player").GetComponent<Transform>();
        Instantiate(EMObject, new Vector3(transform.position.x, transform.position.y + 2, transform.position.z), target.rotation);
    }

    private void Update()
    {

        dist = Vector3.Distance(target.position, transform.position);

        if(dist > distanceToPlayer)
            transform.position = Vector3.MoveTowards(transform.position,target.position, speed * Time.deltaTime);

        if (dist < fireDistance)
            Shoot();

        Vector3 targetDirection = target.position - transform.position;
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, 10 * Time.deltaTime, 0.0f);
        transform.rotation = Quaternion.LookRotation(newDirection);

        
    }

    void FloatUpwards(float height)
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, height, transform.position.z), 1f * Time.deltaTime);
    }

    void Shoot()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;

            GameObject enemyBullet = Instantiate(laser, transform.position, transform.rotation);
            Vector3 targetDirection = target.transform.position - transform.position;
            enemyBullet.transform.rotation = Quaternion.LookRotation(targetDirection);
        }
    }
}
