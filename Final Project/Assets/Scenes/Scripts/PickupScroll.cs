using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickupScroll : MonoBehaviour
{

    //public GameObject pickupEffect;
    public Text countText;
    private int count;


    public int CurrentHealth { get; set; }
    public int MaxHealth { get; set; }

    public Slider HealthBar;


    // Start is called before the first frame update
    void Start()
    {

        count = 0;
        SetCountText();

        //Healthbar
        MaxHealth = 100;
        CurrentHealth = MaxHealth;
        HealthBar.value = CurrentHealth;


    }

    void Update()
    {
        HealthBar.value = CurrentHealth;
        if (Input.GetKeyDown(KeyCode.X))
        {
            DealDamage(5);
        }
    }


    void DealDamage(int damageValue)
    {
        CurrentHealth -= damageValue;
        if (CurrentHealth <= 0)
        {
            Die();
        }
    }


    void Die()
    {
        CurrentHealth = 0;
        Debug.Log("you are dead");
    }


    void OnTriggerEnter(Collider other)

    {

        if (other.gameObject.CompareTag("Scroll"))
        {
            //Instantiate(pickupEffect, other.transform.position, other.transform.rotation);
            Destroy(other.gameObject);
            count += 1;
            SetCountText();
            CurrentHealth += 35;
        }
    }

    void SetCountText()
    {
        countText.text = "Scroll: " + count.ToString();
    }

}
