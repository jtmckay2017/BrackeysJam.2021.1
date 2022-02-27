using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPadCode : OutlinedInteractable
{
    public AudioClip buttonClickSound = default;
    public int keyValue = 1;
    private Animator _anim;
    private Vector3 _startPosition;
    private bool clicked = true;

    private void Start()
    {
        base.Start();
        _anim = GetComponent<Animator>();
        _startPosition = transform.position;
    }

    private void Update()
    {

    }

    public override void OnInteract()
    {
        _anim.SetTrigger("button");
        AudioSource.PlayClipAtPoint(buttonClickSound, transform.position);
    }

   

}
