using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class forklift : OutlinedInteractable
{

    public AudioClip forkliftSound = default;
    public Animator animForks;
    public Animator animPallet;
    private bool forkliftDone = false;

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void OnInteract()
    {
        if (!forkliftDone)
        {
            playAnim();
        }
    }


    public void playAnim()
    {
        forkliftDone = true;
        animForks.SetTrigger("playforklift");
        animForks.SetTrigger("liftpallet");
        animPallet.SetTrigger("liftpallet");
        AudioSource.PlayClipAtPoint(forkliftSound, transform.position);
    }
}
