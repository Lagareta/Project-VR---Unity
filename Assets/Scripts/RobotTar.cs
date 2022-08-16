using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotTar : MonoBehaviour
{
    public Transform PlayerCamera;
    [Header("MaxDistance you can open or close the door.")]
    public float MaxDistance = 30;

    [SerializeField] Transform[] Positions;
    [SerializeField] float speed;
    int NextPosIndex = 0;
    Transform NextPos;

    public Vector3 rot;
    float rotSpeed = 20f;
    Animator anim;
    bool KeyPress = false;

    public AudioSource OpenDoor;

    // Start is called before the first frame update
    void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
        gameObject.transform.eulerAngles = rot;
    }

    void Start()
    {
        NextPos = Positions[0];
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.eulerAngles = rot;

        if (Input.GetKey(KeyCode.P))
        {
            KeyPress = true;

        }


    }

    void Pressed()
    {
        RaycastHit robothit;



        //Delete if you dont want Text in the Console saying that You Press F.
        Debug.Log("You Press P");





        if (Physics.Raycast(PlayerCamera.transform.position, PlayerCamera.transform.forward, out robothit, MaxDistance))
        {

            // if raycast hits, then it checks if it hit an object with the tag Door.
            if (robothit.transform.tag == "robotSphere")
            {
                if (KeyPress)
                {

                    //StartCoroutine(Wait());
                    if (transform.position == NextPos.position)
                    {

                        anim.SetBool("Walk_Anim", false);
                        //transform.Rotate(new Vector3(0, 90, 0), Space.World);
                        //yield return new WaitForSeconds(3);

                        NextPosIndex++;
                        if (NextPosIndex >= Positions.Length)
                        {
                            NextPosIndex = Positions.Length;
                        }
                        else
                        {

                            NextPos = Positions[NextPosIndex];
                        }
                    }
                    else
                    {
                        transform.position = Vector3.MoveTowards(transform.position, NextPos.position, speed * Time.deltaTime);
                        anim.SetBool("Walk_Anim", true);

                    }
                }
            }
        }
    }

    IEnumerator Wait()
    {

        //transform.Rotate(rot * Time.deltaTime);

        if (transform.position == NextPos.position)
        {
           
            anim.SetBool("Walk_Anim", false);
            //transform.Rotate(new Vector3(0, 90, 0), Space.World);
            yield return new WaitForSeconds(3);

            NextPosIndex++;
            if (NextPosIndex >= Positions.Length)
            {
                NextPosIndex = Positions.Length;
            }
            else
            {

                NextPos = Positions[NextPosIndex];
            }

        }
        
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, NextPos.position, speed * Time.deltaTime);
            anim.SetBool("Walk_Anim", true);

        }
        




    }

}
