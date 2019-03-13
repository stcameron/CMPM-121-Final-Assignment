using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickupScroll : MonoBehaviour
{

    //public GameObject pickupEffect;
    public Text countText;
    private int count;


    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        SetCountText();
        
    }

    // Update is called once per frame
    void Update()
    {

    }


    void OnTriggerEnter(Collider other)

    {

        if (other.gameObject.CompareTag("Scroll"))
        {
            //Instantiate(pickupEffect, other.transform.position, other.transform.rotation);
            Destroy(other.gameObject);
            count += 1;
            SetCountText();
        }
    }

    void SetCountText()
    {
        countText.text = "Scroll: " + count.ToString();
    }

}
