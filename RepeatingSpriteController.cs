using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RepeatingSpriteController : MonoBehaviour
{
    private List<RepeatingSprite> spritesInView;
    private List<RepeatingSprite> spritesOutOfView;
    private float totalWidthOfSprites;

    private void Awake()
    {
        spritesInView = new List<RepeatingSprite>();
        spritesOutOfView = new List<RepeatingSprite>();
    }

    private void Start()
    {
        totalWidthOfSprites = 0;
        foreach (RepeatingSprite bc in GetComponentsInChildren<RepeatingSprite>())
        {
            totalWidthOfSprites += bc.GetWidth();
        }
    }

    private void MoveSprites(float lastSpritePosition)
    {
        if(spritesInView.Count > 0)
        {
            if (spritesInView.FirstOrDefault().transform.position.x > lastSpritePosition)
            {
                spritesOutOfView.OrderBy(b => b.transform.position.x).FirstOrDefault().transform.position += new Vector3(totalWidthOfSprites, 0, 0);
            }
            else
            {
                spritesOutOfView.OrderBy(b => b.transform.position.x).LastOrDefault().transform.position -= new Vector3(totalWidthOfSprites, 0, 0);
            }
        }
    }

    public void SpriteEnteredView(RepeatingSprite bc)
    {
        spritesInView.Add(bc);
        spritesOutOfView.Remove(bc);
    }

    public void SpriteExitedView(RepeatingSprite bc)
    {
        spritesOutOfView.Add(bc);
        spritesInView.Remove(bc);
        MoveSprites(bc.transform.position.x);
    }
}