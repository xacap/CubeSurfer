using UnityEngine;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class GridViewController : MonoBehaviour, IDragHandler, IEndDragHandler
{
    private Grid grid;

    private enum DraggedDirection
    {
        Up,
        Down,
        Right,
        Left
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("Press position + " + eventData.pressPosition);
        Debug.Log("End position + " + eventData.position);
        Vector3 dragVectorDirection = (eventData.position - eventData.pressPosition).normalized;
        Debug.Log("norm + " + dragVectorDirection);
        GetDragDirection(dragVectorDirection);
    }

    public void OnDrag(PointerEventData eventData)
    {

    }

    private DraggedDirection GetDragDirection(Vector3 dragVector)
    {
        float positiveX = Mathf.Abs(dragVector.x);
        float positiveY = Mathf.Abs(dragVector.y);
        DraggedDirection draggedDir;
        if (positiveX > positiveY)
        {
            draggedDir = (dragVector.x > 0) ? DraggedDirection.Right : DraggedDirection.Left;
        }
        else
        {
            draggedDir = (dragVector.y > 0) ? DraggedDirection.Up : DraggedDirection.Down;
        }
        Debug.Log(draggedDir);
        return draggedDir;
    }
  
}