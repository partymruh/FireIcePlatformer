using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHover : MonoBehaviour
{
    private bool mouseOver;
    public float propScale;
    private float baseScale;
    public float speedConst;

    // Start is called before the first frame update
    void Start()
    {
        mouseOver = false;
        baseScale = transform.localScale.x;
    }

    private void FixedUpdate()
    {
        if (mouseOver && transform.localScale.x < baseScale * propScale)
        {
            transform.localScale += new Vector3(((baseScale * propScale) - baseScale) / speedConst, ((baseScale * propScale) - baseScale) / speedConst, ((baseScale * propScale) - baseScale) / speedConst);
        }
        else if (!mouseOver && transform.localScale.x > baseScale)
        {
            transform.localScale -= new Vector3(((baseScale * propScale) - baseScale) / speedConst, ((baseScale * propScale) - baseScale) / speedConst, ((baseScale * propScale) - baseScale) / speedConst);
        }
    }

    private void OnMouseEnter()
    {
        mouseOver = true;
    }

    private void OnMouseExit()
    {
        mouseOver = false;
    }
}
