using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandCenterTrigger : MonoBehaviour
{
    public GameObject cam1;
    public GameObject cam2;
    public GameObject player;
    public GameObject scratch;
    
 
    public void OnTriggerStay(Collider other)
    {
      
      
             
        if (Input.GetKey(KeyCode.E))
        {
            player.SetActive(false);
            cam1.SetActive(false);
            cam2.SetActive(true);
            PlayerMovement playerMovement = FindObjectOfType<PlayerMovement>();
             playerMovement.enabled = false;
            var showText = FindObjectOfType<Show_text>();
            showText.showDistance = 0;
            scratch.SetActive(true);

        }

        if (Input.GetKey(KeyCode.Escape))
        {
            cam1.SetActive(true);
            cam2.SetActive(false);
            player.SetActive(true);
             PlayerMovement playerMovement = FindObjectOfType<PlayerMovement>();
            playerMovement.enabled = true;
            var showText = FindObjectOfType<Show_text>();
            showText.showDistance = 4;
            scratch.SetActive(false);
        }
        
      
    }


}
