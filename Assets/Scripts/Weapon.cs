using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float fireRate;
    public float nextFire;

    public float recoilAmount;

    public GameObject projectile;

    private Transform muzzle;

    public Sway recoil;

    public AudioClip weaponSound;
    AudioSource source;

    private void Update()
    {
        Shoot();
        ShootWithInstantiate();
    }

    private void Start()
    {
        muzzle = GameObject.Find("Muzzle").GetComponent<Transform>();

        recoil = GetComponent<Sway>();

        source = GetComponent<AudioSource>();
    }

    public virtual void ShootWithInstantiate()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            source.PlayOneShot(weaponSound);

            nextFire = Time.time + fireRate;
            recoil.StartRecoil(recoilAmount);

            Instantiate(projectile, muzzle.position, muzzle.rotation);
        }
    }

    public virtual void Shoot()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            recoil.StartRecoil(recoilAmount);
            source.PlayOneShot(weaponSound);

            RaycastHit hit;
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, Mathf.Infinity))
            {
                Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward * 20, Color.green);
                if (hit.transform.gameObject.tag == "Enemy")
                {
                    Destroy(hit.transform.gameObject);
                }
            }
        }
    }
}
