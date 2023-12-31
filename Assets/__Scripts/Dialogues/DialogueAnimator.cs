using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueAnimator : MonoBehaviour
{
    public Animator startAnim;
    public DialogueManager dm;

    private void OnTriggerEnter2D(Collider2D collision)
    { 
        startAnim.SetBool("startOpen", true);
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (startAnim != null)
        {
        startAnim.SetBool("startOpen", false);
        dm.EndDialogue();
        }
    }

}
