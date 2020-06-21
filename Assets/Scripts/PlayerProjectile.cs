using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    public float speed;

    private void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
}
