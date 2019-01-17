using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingSprite : MonoBehaviour
{
    private RepeatingSpriteController RepeatingSpriteController;
    private float width;

    private void Awake()
    {
        RepeatingSpriteController = GetComponentInParent<RepeatingSpriteController>();
    }

    private void Start()
    {
        RepeatingSpriteController.SpriteExitedView(this);
        width = GetComponent<SpriteRenderer>().size.x;
    }

    public float GetWidth()
    {
        return width;
    }

    private void OnBecameInvisible()
    {
        RepeatingSpriteController.SpriteExitedView(this);
    }

    private void OnBecameVisible()
    {
        RepeatingSpriteController.SpriteEnteredView(this);
    }
}
