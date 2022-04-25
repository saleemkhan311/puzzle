using System.Collections;
using System.Collections.Generic;
using UnityEngine;
  
public class Collision : MonoBehaviour
{
    Vector2 tempPos;
    bool moving;
    public GameObject Swap;
    public Vector2 resetPos;
    Vector2 colliderPos;
    bool isPickedUp;
    float moves;
    private void Start()
    {
        resetPos = transform.position;
    }
   
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetMouseButtonUp(0) && isPickedUp)
        {
            collision.transform.position = resetPos;

            GameManager.singleton.moves++;
            //FindObjectOfType<SwapManager>().Swap(collision.transform, this.gameObject.transform);
            
        }  
    }


    private void OnMouseDrag()
    {
        isPickedUp = true;
    }
    private void OnMouseUp()
    {
        isPickedUp = false;
        resetPos = this.transform.position;

    }
    private void OnMouseDown()
    {
        resetPos = this.transform.position;
    }

}
