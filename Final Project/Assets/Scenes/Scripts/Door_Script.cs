using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_Script : MonoBehaviour
{
    private bool doorIsOpen = false;
    private bool doorIsOpening = false;
    private bool doorIsClosing = false;
    private bool doorIsClosed = true;
    [SerializeField]
    private GameObject rightDoor;
    [SerializeField]
    private GameObject leftDoor;

    [SerializeField]
    private Transform rightHinge;
    [SerializeField]
    private Transform leftHinge;

    public PickupScroll pickup;
    private int counter;

    // Start is called before the first frame update
    void Start()
    {
        rightHinge = rightDoor.transform.GetChild(0);
        leftHinge = leftDoor.transform.GetChild(0);
        counter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        counter = pickup.count;
    }
    private void OnTriggerEnter(Collider other)
    {
        if ((other.CompareTag("Player") || other.CompareTag("MainCamera")) && counter >= 2)
        {
            
            if (doorIsOpening || doorIsClosing) return;// if the animation is already playing, do nothing

            if (doorIsClosed)//if the door is closed, open it
            {
                doorIsOpening = true;
                StartCoroutine("OpenDoor");
                return;
            }
           
            
        }
    }
    //coroutine for opening door
    IEnumerator OpenDoor()
    {
        if (!doorIsOpening) doorIsOpening = true;
        if (doorIsClosed) doorIsClosed = false;
        for( int i = 0; i < 90; i++)
        {
            rightDoor.transform.RotateAround(rightHinge.position, rightDoor.transform.forward, 1);
            leftDoor.transform.RotateAround(leftHinge.position, leftDoor.transform.forward, -1);
            yield return new WaitForSeconds(0.00001f);
           
            doorIsOpen = true;
            doorIsOpening = false;
        }
    }
    //coroutine for closing door
    IEnumerator CloseDoor()
    {
        if (!doorIsClosing) doorIsClosing = true;
        if (doorIsOpen) doorIsOpen = false;
        for (int i = 0; i < 90; i++)
        {
            rightDoor.transform.RotateAround(rightHinge.position, rightDoor.transform.forward, -1);
            leftDoor.transform.RotateAround(leftHinge.position, leftDoor.transform.forward, 1);
            yield return new WaitForSeconds(0.00001f);
            
            doorIsClosed = true;
            doorIsClosing = false;
        }
    }
}
