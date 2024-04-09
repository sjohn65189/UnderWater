using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TestingPlacementPuzzle : MonoBehaviour
{
    public int pedestalNum;
    private GameObject invalidTxt;
    private GameObject completeTxt;
    private float timer = 0f;
    private bool valid = false;

    private void Awake()
    {
        invalidTxt = GameObject.Find("Invalid Placement Text");
        completeTxt = GameObject.Find("Completed Puzzle");
    }

    // Start is called before the first frame update
    void Start()
    {
        invalidTxt.SetActive(false);
        completeTxt.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime / 3f;
        }
        else
        {
            if (valid)
            {
                invalidTxt.SetActive(false);
                completeTxt.SetActive(false);
                valid = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        var hitbox1 = GameObject.Find("Pedestal Hitbox");
        var hitbox2 = GameObject.Find("Pedestal Hitbox (1)");
        var hitbox3 = GameObject.Find("Pedestal Hitbox (2)");

        var placeable1 = GameObject.Find("Item1");
        var placeable2 = GameObject.Find("Item2");
        var placeable3 = GameObject.Find("Item3");

        // need to add more else if statements based on how many placement locations there are.
        if (pedestalNum == 1)
        {
            print("In ped1.");
            if (other.CompareTag("Placeable"))
            {
                print("Has correct tag.");
                if (other.name == "Item1")
                {
                    print("Has correct name/should be working now(?)");
                    placeable1.transform.position = hitbox1.transform.position;
                    placeable1.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                    placeable1.transform.eulerAngles = new Vector3(0, 0, 0);
                    placeable1.GetComponent<XRGrabInteractable>().enabled = false;
                    Game.Instance.ped1 = true;
                }
                else
                {
                    print("Piece does not belong here!");
                    invalidTxt.SetActive(true);
                    timer = 1;
                    valid = true;
                }
            }
        }
        else if (pedestalNum == 2)
        {
            if (other.CompareTag("Placeable"))
            {
                if (other.name == "Item2")
                {
                    placeable2.transform.position = hitbox2.transform.position;
                    placeable2.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                    placeable2.transform.eulerAngles = new Vector3(0, 0, 0);
                    placeable2.GetComponent<XRGrabInteractable>().enabled = false;
                    Game.Instance.ped2 = true;
                }
                else
                {
                    print("Piece does not belong here!");
                    invalidTxt.SetActive(true);
                    timer = 1;
                    valid = true;
                }
            }
        }
        else if (pedestalNum == 3)
        {
            if (other.CompareTag("Placeable"))
            {
                if (other.name == "Item3")
                {
                    placeable3.transform.position = hitbox3.transform.position;
                    placeable3.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                    placeable3.transform.eulerAngles = new Vector3(0, 0, 0);
                    placeable3.GetComponent<XRGrabInteractable>().enabled = false;
                    Game.Instance.ped3 = true;
                }
                else
                {
                    print("Piece does not belong here!");
                    invalidTxt.SetActive(true);
                    timer = 1;
                    valid = true;
                }
            }
        }
        print(Game.Instance.ped1 + " " + Game.Instance.ped2 + " " + Game.Instance.ped3);
        // checks if puzzle is completed so the pressure puzzle will unlock
        if (Game.Instance.ped1 & Game.Instance.ped2 & Game.Instance.ped3)
        {
            timer = 2;
            valid = true;
            completeTxt.SetActive(true);
            Game.Instance.UnlockPressure();
        }
    }
}
