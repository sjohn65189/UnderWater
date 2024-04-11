using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


public enum GrabStateType
{
    LOCKED,
    UNLOCKED
}

public class GrabbablePlacer : MonoBehaviour
{
    public int pedestalNum;
    private float timer = 0f;
    private bool valid = false;

    private GameObject hitbox1;
    private GameObject hitbox2;
    private GameObject hitbox3;

    public GrabStateType State { get; private set; }

    private void Awake()
    {
        //invalidTxt = GameObject.Find("[] HUD Wrong Spot []");
        State = GrabStateType.LOCKED;
        hitbox1 = GameObject.Find("Pipe_Valve_Hitbox");
        hitbox2 = GameObject.Find("Pipe_Plus_Hitbox");
        hitbox3 = GameObject.Find("Pipe_T_Better_Hitbox");
    }

    // Start is called before the first frame update
    void Start()
    {
        
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
                //invalidTxt.SetActive(false);
                valid = false;
            }
        }

        switch (State)
        {
            case GrabStateType.LOCKED:
                break;
            case GrabStateType.UNLOCKED:
                Game.Instance.UnlockPressure();
                break;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        
        var placeable1 = GameObject.Find("Pipe_Valve_Piece");
        var placeable2 = GameObject.Find("Pipe_Plus_Piece");
        var placeable3 = GameObject.Find("Pipe_T_Better_Piece");
        
        // need to add more else if statements based on how many placement locations there are.
        if (pedestalNum == 1)
        {
            if (other.CompareTag("Placeable"))
            {
                if (other.name == "HorizontalPiece_Actual" | other.name == "VerticlePiece_Actual")
                {
                    placeable1.transform.position = hitbox1.transform.position;
                    placeable1.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                    placeable1.transform.eulerAngles = new Vector3(0, 0, 0);
                    placeable1.GetComponent<XRGrabInteractable>().enabled = false;
                    Game.Instance.ped1 = true;
                }
                else
                {
                    print("Piece does not belong here!");
                    //invalidTxt.SetActive(true);
                    timer = 1;
                    valid = true;
                }
            }
        }
        else if (pedestalNum == 2)
        {
            if (other.CompareTag("Placeable"))
            {
                if (other.name == "Pipe_Plus_Piece")
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
                    //invalidTxt.SetActive(true);
                    timer = 1;
                    valid = true;
                }
            }
        }
        else if (pedestalNum == 3)
        {
            if (other.CompareTag("Placeable"))
            {
                if (other.name == "Pipe_T_Better_Piece")
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
                    //invalidTxt.SetActive(true);
                    timer = 1;
                    valid = true;
                }
            }
        }
        print(Game.Instance.ped1 + " " + Game.Instance.ped2 + " " + Game.Instance.ped3);
        // checks if puzzle is completed so the pressure puzzle will unlock
        if (Game.Instance.ped1 & Game.Instance.ped2 & Game.Instance.ped3)
        {
            State = GrabStateType.UNLOCKED;
        }
    }
    
    public void UnlockPuzzle()
    {
        print("Unlocking puzzle...");
        hitbox1.SetActive(true);
        hitbox2.SetActive(true);
        hitbox3.SetActive(true);
    }

    public void LockPuzzle()
    {
        print("Locking puzzle...");
        hitbox1.SetActive(false);
        hitbox2.SetActive(false);
        hitbox3.SetActive(false);
    }
}
