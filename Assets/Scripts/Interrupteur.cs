using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interrupteur : MonoBehaviour
{

    DoorScript locked;
    [SerializeField] GameObject croco;

    public AudioSource OpenDoor;
    public Transform PlayerCamera;
    [Header("MaxDistance you can push the switch.")]
    public float MaxDistance = 10;


   

    // Start is called before the first frame update
    void Awake()
    {
        
        locked = croco.GetComponent<DoorScript>();
       
    }

    // Update is called once per frame
    void Update()
    {
        
        
        //Debug.Log(locked.Lock);

        if (Input.GetKeyDown(KeyCode.I))
        {
            Pressed();

        }

    }


    void Pressed()
    {
        //This will name the Raycasthit and came information of which object the raycast hit.
        RaycastHit interrupthit;



        //Delete if you dont want Text in the Console saying that You Press F.
        Debug.Log("You Press I");



      

        if (Physics.Raycast(PlayerCamera.transform.position, PlayerCamera.transform.forward, out interrupthit, MaxDistance))
        {

            Debug.Log("Hello");
            // if raycast hits, then it checks if it hit an object with the tag Door.
            if (interrupthit.transform.tag == "Interrupteur")
            {
               
                OpenDoor.Play();

                // accesses the bool named "isOnFire" and changed it's value.
                locked.Lock = false;

                Debug.Log(locked.Lock);

            }
        }





    }
}
