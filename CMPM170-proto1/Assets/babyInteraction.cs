using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class babyInteraction : MonoBehaviour
{
    //variables to keep track of interactable object in range
    bool inRange = false;
    GameObject interactObj;
    public GameObject indicatorPrefab;
    //boolean to keep track of charge
    bool isCharged = false;

    // Start is called before the first frame update
    void Start()
    {
        interactObj = null;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void setFire()
    {

    }

    //function to be called when player attempts to interact
    void interact()
    {
        if (inRange)
        {
            if (interactObj.tag == "Outlet")
            {
                grabCharge();
            }
            if (interactObj.tag == "Chair" && isCharged)
            {
                setFire();
            }
        }
    }

    void grabCharge()
    {
        if (!isCharged)
        {
            isCharged = true;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        interactObj = col.gameObject;
        inRange = true;
    }
    void OnTriggerExit2D(Collider2D col)
    {
        interactObj = null;
        inRange = false;
    }
    public void sprayed()
    {
        if (isCharged)
        {
            Debug.Log("extinguished");
            isCharged = false;
        }
    }
    public void checkInput()
    {
        if (inRange)
        {
            if (this.gameObject.name == "Baby_1" && Input.GetKeyDown(KeyCode.E))
            {
                interact();
            }
            else if (this.gameObject.name == "Baby_2" && Input.GetKeyDown(KeyCode.Y))
            {
                interact();
            }
            else if (this.gameObject.name == "Baby_1" && Input.GetKeyDown(KeyCode.O))
            {
                interact();
            }
        }
    }
}
