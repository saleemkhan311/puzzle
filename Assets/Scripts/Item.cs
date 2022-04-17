using UnityEngine;

public class Item : MonoBehaviour
{
    public delegate void DragEndedDalegate(Item dragAbles);

    public DragEndedDalegate dragEndedCallBack;

    private Sprite _sprite;

    private bool _isMoving;

    public Transform spot;
    public Transform newSpot;

    public void Setup(Sprite sprite, Transform spotTransform)
    {
        _sprite = sprite;
        spot = spotTransform;
    }

    public void UpdateRenderer()
    {
        GetComponent<SpriteRenderer>().sprite = _sprite;
    }

    private void Update()
    {
        if (_isMoving == true)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector2(mousePos.x, mousePos.y);
        }
    }
    private void OnMouseDrag()
    {
       // if (!_isMoving) return;
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector2(mousePos.x, mousePos.y);
        _isMoving = true;
    }

    private void OnMouseDown()
    {
        if (GameManager.Singleton.win == true) return;
        if (GameManager.Singleton.lose == true) return;
        Debug.Log("Drag");
        _isMoving = true;
    }

    private void OnMouseUp()
    {
        _isMoving = false;
        //if (newSpot == null) return;
        
        // dragEndedCallBack(this);
    }
}