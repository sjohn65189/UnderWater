using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GrabbablePlacer : MonoBehaviour
{
    public int pedestalNum;
    private GameObject invalidTxt;
    private float timer = 0.0001f;
    private bool valid = false;

    private void Awake()
    {
        invalidTxt = GameObject.Find("[] HUD Info []");
    }

    // Start is called before the first frame update
    void Start()
    {
        invalidTxt.SetActive(false);
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
            if (other.CompareTag("Placeable"))
            {
                if (other.name == "Item1")
                {
                    placeable1.transform.position = hitbox1.transform.position;
                    placeable1.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                    placeable1.transform.eulerAngles = new Vector3(0, 0, 0);
                    placeable1.GetComponent<XRGrabInteractable>().enabled = false;
                    hitbox1.GetComponent<ParticleSystem>().Play();
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
    } 
}
