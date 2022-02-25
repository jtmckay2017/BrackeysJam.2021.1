using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paper : OutlinedInteractable
{
    private void Start()
    {
        base.Start();
    }

    public override void OnInteract()
    {
        FactoryLevel.Instance.AddPaper(this);
    }
}
