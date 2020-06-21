using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchWeapons : MonoBehaviour
{
    public GameObject[] weapons;

    public GameObject[] canvasWeaponIcons;
    public Sprite[] weaponSprites;

    private int currentWeapon;

    private void Start()
    {
        weapons = GameObject.FindGameObjectsWithTag("Gun");

        currentWeapon = 0;

        SelectWeapon();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (currentWeapon >= weapons.Length - 1)
                currentWeapon = 0;
            else
                currentWeapon++;

                SelectWeapon();
        }
            
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (currentWeapon <= 0)
                currentWeapon = weapons.Length - 1;
            else
                currentWeapon--;

            SelectWeapon();
        }
            
    }

    void SelectWeapon()
    {
        int i = currentWeapon;
        foreach(GameObject weapon in weapons)
        {
            weapon.SetActive(false);
            weapons[i].SetActive(true);
        }
    }
}
