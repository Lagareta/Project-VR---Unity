using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrocoTar : MonoBehaviour
{
    [SerializeField] Transform[] Positions;
    [SerializeField] float speed;
    int NextPosIndex = 0;
    Transform NextPos;

    Animator anim;
    bool KeyPress = false;

    // Start is called before the first frame update
   

    void Start()
    {
        NextPos = Positions[0];
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetKey(KeyCode.H))
        {
            KeyPress = true;

        }
        if (KeyPress)
        {
            //StartCoroutine(Wait());
            if (transform.position == NextPos.position)
            {

                //anim.SetBool("Walk_Anim", false);
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
                //anim.SetBool("Walk_Anim", true);

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
