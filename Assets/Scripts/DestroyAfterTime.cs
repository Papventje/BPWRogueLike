using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{
    public float destroyTimer;

    private void Start()
    {
        DestroyGameObject(destroyTimer);
    }

    public void DestroyGameObject(float timer)
    {
        Destroy(gameObject, timer);
    }
}
