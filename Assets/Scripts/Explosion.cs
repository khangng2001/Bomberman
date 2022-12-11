using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public AnimatedSprite start;
    public AnimatedSprite middle;
    public AnimatedSprite end;
    
    /*public AnimatedSprite activeSprite;*/
    public void SetActiveRenderer(AnimatedSprite sprite)
    {
        start.enabled = sprite == start;
        middle.enabled = sprite == middle;
        end.enabled = sprite == end;
        //activeSprite = sprite;
    }

    public void SetDirection(Vector2 direction)
    {
        float angle = Mathf.Atan2(direction.y, direction.x);
        transform.rotation = Quaternion.AngleAxis(angle*Mathf.Rad2Deg, Vector3.forward);
    }

    public void DestroyAfter(float seconds)
    {
        Destroy(gameObject, seconds);
        
    }

 
}
