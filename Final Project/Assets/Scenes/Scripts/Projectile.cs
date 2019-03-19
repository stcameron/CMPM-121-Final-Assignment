using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Breakable"))
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
}
