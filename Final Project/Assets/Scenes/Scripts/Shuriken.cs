using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shuriken : MonoBehaviour
{
    public Rigidbody projectile;
    public Transform Spawnpoint;
    public int throwSpeed = 0;

    private bool hasWeapon;
    GameObject weapon;

    // Start is called before the first frame update
    void Start()
    {
        hasWeapon = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire0") && hasWeapon == true)
        {
            Rigidbody clone;
            clone = (Rigidbody)Instantiate(projectile, Spawnpoint.position,  Quaternion.identity);
            clone.velocity = Spawnpoint.TransformDirection(Vector3.forward * throwSpeed);
        }

        weapon = GameObject.FindGameObjectWithTag("Weapon");
        if (weapon != null)
        {
            if (Vector3.Distance(weapon.transform.position, Spawnpoint.position) > 40)
            {
                Destroy(weapon);
            }
        }
    }

    void OnTriggerEnter(Collider other)

    {
        if (other.gameObject.CompareTag("WeaponPickup"))
        {
            //Instantiate(pickupEffect, other.transform.position, other.transform.rotation);
            Destroy(other.gameObject);
            hasWeapon = true;
        }

    }
}
