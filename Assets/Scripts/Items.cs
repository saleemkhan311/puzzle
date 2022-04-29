using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
    public delegate void DragEndedDalegate(Items dragAbles);
    public DragEndedDalegate dragEndedCallBack;
    public bool isMoving;
    public Vector2 resetPos;
    SpriteRenderer sprite;
    public GameObject Slot;
    private Vector2 slot_Pos;
    //public GameObject Temp;
    bool isPositioned = false;
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        resetPos = transform.position;
        slot_Pos = Slot.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.singleton.win || GameManager.singleton.lose) { this.enabled = false; }
        Constraint();
        if(Slot !=null)
        {
            Snap();
        }
        
        
        
    }
    private void OnMouseDrag()
    {
        
                if (isMoving)
                {
                        Vector3 mousePos;
                        mousePos = Input.mousePosition;
                        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
                        transform.position = new Vector2(mousePos.x, mousePos.y);
                }
           
    }
    private void OnMouseDown()
    {
      
                Vector3 mousePos;
                mousePos = Input.mousePosition;
                mousePos = Camera.main.ScreenToWorldPoint(mousePos);


                isMoving = true;

                sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 0.5f);
           
    }

    private void OnMouseUp()
    {

                isMoving = false;

                sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 1);
                dragEndedCallBack(this);
            
    }
    
   
    void Snap()
    {
        float Distance = Vector2.Distance(transform.position, slot_Pos);
        if(Distance<=0.5f)
        {
            if(slot_Pos != null) { transform.position = slot_Pos; }
            Invoke("DisableCollider", 1);

            if(!isPositioned )
            {
               
                    GameManager.singleton.scores++;
                    isPositioned = true;
                    
            }

           
        }
    }

    void DisableCollider()
    {
        GetComponent<BoxCollider2D>().enabled = false;

    }
    void Constraint()
    {

        if (transform.position.x > 7.5f)
        {
            transform.position = new Vector2(7.5f, transform.position.y);
        }
        else if (transform.position.x < -4.2)
        {
            transform.position = new Vector2(-4.2f, transform.position.y);
        }

        if (transform.position.y > 3.0f)
        {
            transform.position = new Vector2(transform.position.x, 3.0f);
        }
        else if (transform.position.y < -3.5)
        {
            transform.position = new Vector2(transform.position.x, -3.5f);
        }
    }
    
}
