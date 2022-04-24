using System.Collections;
using System.Collections.Generic;
using UnityEngine;
  
public class Collision : MonoBehaviour
{
    Vector2 tempPos;
    bool moving;
    
    public Vector2 resetPos;
    Vector2 colliderPos;
    bool mouseUp;
    private void Start()
    {
        resetPos = transform.position;
    }
   
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetMouseButtonUp(0))
        {
            tempPos = resetPos;
            collision.transform.position = resetPos;
            Debug.Log(collision.name);
        }  
    }
    
   
    private void OnMouseUp()
    {
        resetPos = this.transform.position;
    }
   
}
