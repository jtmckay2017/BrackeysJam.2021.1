using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestInteractable : PhysicsObject
{
    private Outline _outline;

    // Start is called before the first frame update
    void Start()
    {
        _outline = GetComponent<Outline>();
        _outline.OutlineWidth = 0f;
        _outline.OutlineMode = Outline.Mode.OutlineAll;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void OnFocus()
    {
        _outline.OutlineWidth = 4f;
    }

    public override void OnInteract()
    {
        if (_outline.OutlineColor == Color.red)
        {
            _outline.OutlineColor = Color.white;
        } else
        {
            _outline.OutlineColor = Color.red;
        }
    }

    public override void OnLoseFocus()
    {
        _outline.OutlineWidth = 0f;
    }


}
