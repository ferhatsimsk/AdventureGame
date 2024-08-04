using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{


    public GameObject dialogue1;
    public GameObject dialogue2;
    public GameObject dialogue3;
    //public GameObject dialogueDown;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Dialogue1"))
        {
            dialogue1.SetActive(true);
        }
        else if (other.CompareTag("Dialogue2"))
        {
            dialogue2.SetActive(true);
        }
        else if (other.CompareTag("Dialogue3"))
        {
            dialogue3.SetActive(true);
        }
        //else if(other.CompareTag("DialogueDown"))
        //{
        //    dialogueDown.SetActive(true);
        //}

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Dialogue1"))
        {
            dialogue1.SetActive(false);
        }
        else if (other.CompareTag("Dialogue2"))
        {
            dialogue2.SetActive(false);
        }
        else if (other.CompareTag("Dialogue3"))
        {
            dialogue3.SetActive(false);
        }
        //else if (other.CompareTag("DialogueDown"))
        //{
        //    dialogueDown.SetActive(false);
        //}
    }

}
