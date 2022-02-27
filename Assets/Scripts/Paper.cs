using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paper : OutlinedInteractable
{
    public AudioClip pickUpPaperSound;
    private void Start()
    {
        base.Start();
    }

    public override void OnInteract()
    {
        AudioSource.PlayClipAtPoint(pickUpPaperSound, transform.position);
        FactoryLevel.Instance.AddPaper(this);
    }
}
