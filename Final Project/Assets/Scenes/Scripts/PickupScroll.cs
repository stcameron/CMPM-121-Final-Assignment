using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickupScroll : MonoBehaviour
{

    //public GameObject pickupEffect;
    public Text countText;
    public Text finishText;
    public int count;


    public int CurrentHealth { get; set; }
    public int MaxHealth { get; set; }

    public Slider HealthBar;


    // Start is called before the first frame update
    void Start()
    {

        count = 0;
        SetCountText();
        finishText.text = "";

        //Healthbar
        MaxHealth = 150;
        CurrentHealth = 0;
        HealthBar.value = CurrentHealth;


    }

    void Update()
    {
        if (CurrentHealth > MaxHealth) CurrentHealth = MaxHealth;
        HealthBar.value = CurrentHealth;
    }

    void OnTriggerEnter(Collider other)

    {

        if (other.gameObject.CompareTag("Scroll"))
        {
            //Instantiate(pickupEffect, other.transform.position, other.transform.rotation);
            Destroy(other.gameObject);
            count += 1;
            SetCountText();
            CurrentHealth += 50;
        }

        else if(other.gameObject.CompareTag("Finish"))
        {
            if (count >= 6)
            {
                finishText.text = "You Win!\n You found all 6 Scrolls";
            }
            else finishText.text = "You Finished! But You Only Found\n " + count.ToString() + " Scrolls\n Try to find them All!";
        }
    }

    void SetCountText()
    {
        countText.text = "Scroll: " + count.ToString();
    }

}
