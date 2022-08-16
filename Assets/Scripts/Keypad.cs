using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Keypad : MonoBehaviour
{
    public string password = "846325";
    private string userInput = "";

    public Animator Door;

   

    public AudioClip clickSound;
    public AudioClip openSound;
    public AudioClip noSound;
    AudioSource audioSource;

    private void Start()
    {
        userInput = "";
        audioSource = GetComponent<AudioSource>();
    }

    public void ButtonClicked(string number)
    {
        audioSource.PlayOneShot(clickSound);
        userInput += number;
        if (userInput.Length >= 6)
        {
            //check password
            if(userInput == password)
            {
                Debug.Log("Entry Allowed");
                audioSource.PlayOneShot(openSound);
                Door.SetBool("Opened", true);
              
            }
            else
            {
                Debug.Log("Entry Denyied");
                userInput = "";
                audioSource.PlayOneShot(noSound);
                
            }
        }

    }
}
