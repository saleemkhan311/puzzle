using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapController  : Collision
{
    public List<GameObject> snapePoints;
    public List<Items> DragAbles;
    float snapeRange = 1f;
    Vector2 Tempos;

    
    
    public int Moves;
    void Start()
    {
        foreach (Items items in DragAbles )
        {
            items.dragEndedCallBack = OnDrageEnded;
        }

    }


    void OnDrageEnded(Items items)
    {
        Transform closestSnapePoint = null;
        float closestDistance = -1; 
        foreach(GameObject snapePoint in snapePoints)
        {
           float currentDistance = Vector2.Distance(items.transform.position, snapePoint.transform.position);
            if (closestSnapePoint == null || currentDistance < closestDistance)
            {
                closestSnapePoint = snapePoint.transform;
                closestDistance = currentDistance;
                Tempos = snapePoint.transform.position;
            }
        }
        if(closestSnapePoint != null && closestDistance <= snapeRange)
        {
            items.transform.position = closestSnapePoint.position;
            resetPos = items.transform.position;
           
            //Moves++;
          
        }
    }  
}
