using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public Camera camReference;
    public GameObject player;
    private Vector3 direction;

    private Weapon[] weapons;
    private Weapon currentWeapon;

    void Start()
    {
        weapons = new Weapon[2];
        weapons[0] = GetComponent<MachineGun>();
        weapons[1] = GetComponent<Pistol>();
        weapons[0].player = player;
        weapons[1].player = player;
        weapons[0].camReference = camReference;
        weapons[1].camReference = camReference;
        currentWeapon = weapons[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space") || Input.GetKeyDown("mouse 0"))
        {
            currentWeapon.TriggerDown();
        }
        if (Input.GetButton("Jump"))
        {
            if (currentWeapon._currentDelay > 0) { currentWeapon._currentDelay--; }
            if (currentWeapon._currentDelay == 0)
            {
                currentWeapon.TriggerHold();
                currentWeapon._currentDelay = currentWeapon._fireDelay;
            }
        }
        if (Input.GetKeyUp("space") || Input.GetKeyUp("mouse 0"))
        {
            currentWeapon.TriggerUp();
        }
        if (Input.GetKeyDown("1"))
        {
            SwapWeapon(0);
        }
        if (Input.GetKeyDown("2"))
        {
            SwapWeapon(1);
        }
    }
    void SwapWeapon(int input)
    {
        currentWeapon = weapons[input];
    }
}
