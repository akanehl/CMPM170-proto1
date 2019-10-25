using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dadInteraction : MonoBehaviour
{
    //variables to keep track of interactable object in range
    bool inRange = false;
    GameObject interactObj;
    // Start is called before the first frame update
    void Start()
    {
        interactObj = null;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightShift))
        {
            interact();
        }
    }
    //function executed when the player is in range and attempts to interact with an object
    void interact()
    {
        Debug.Log("interacting");
        if (inRange)
        {
            if (interactObj.tag == "Stove")
            {
                cook();
            }
            if (interactObj.tag == "Baby")
            {
                spray();
            }
        }
    }
    //function to trigger the cooking event
    void cook()
    {
        Debug.Log("cooking");
        //call function in game state management
    }
    //function to spray baby
    void spray()
    {
        interactObj.GetComponent<babyInteraction>().sprayed();
        //call function in baby interaction
    }
    //trigger functions to keep track of when the player is in range of an interactable object
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
}
