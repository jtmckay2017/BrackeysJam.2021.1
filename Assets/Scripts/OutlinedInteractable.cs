using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Outline))]
public class OutlinedInteractable : Interactable
{
    private Outline _outline;
    [SerializeField, Range(0f, 10f)]
    private float outlineWidth = 4f;
    // Start is called before the first frame update
    protected void Start()
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
        _outline.OutlineWidth = outlineWidth;
    }

    public override void OnInteract()
    {
        if (_outline.OutlineColor == Color.red)
        {
            _outline.OutlineColor = Color.white;
        }
        else
        {
            _outline.OutlineColor = Color.red;
        }
    }

    public override void OnLoseFocus()
    {
        _outline.OutlineWidth = 0f;
    }


}
