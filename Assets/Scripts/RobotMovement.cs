using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotMovement: MonoBehaviour
{
	public Transform PlayerCamera;
	[Header("MaxDistance you can open or close the door.")]
	public float MaxDistance = 30;

	private bool Walk_anim = false;

	public Vector3 rot;
	float rotSpeed = 40f;
	Animator anim;

	public AudioSource OpenDoor;
	// Use this for initialization
	void Awake()
	{
		anim = gameObject.GetComponent<Animator>();
		gameObject.transform.eulerAngles = rot;
	}

	// Update is called once per frame
	void Update()
	{
		gameObject.transform.eulerAngles = rot;

		if (Input.GetKey(KeyCode.C))
        {
			CheckKey();
			
		}
		

	}

	void CheckKey()
	{
		RaycastHit robothit;

		if (Physics.Raycast(PlayerCamera.transform.position, PlayerCamera.transform.forward, out robothit, MaxDistance))
		{
			

			// if raycast hits, then it checks if it hit an object with the tag Door.
			if (robothit.transform.tag == "robotSphere")
			{
				Debug.Log("ça marche");
				anim = robothit.transform.GetComponent<Animator>();
				// Walk
				OpenDoor.Play();

				Walk_anim = !Walk_anim;

				anim.SetBool("Walk_Anim", !Walk_anim);
				
				
			}
			
			
		}

	
	}

}
