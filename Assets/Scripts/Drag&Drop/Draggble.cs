using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class Draggble : MonoBehaviour,IBeginDragHandler,IDragHandler,IEndDragHandler {
    public Transform parentToReturn;
     GameObject placeHolder;
    public void OnBeginDrag(PointerEventData eventdata)
    {
        this.GetComponent<CanvasGroup>().blocksRaycasts = false;
        placeHolder = new GameObject() ;
        placeHolder.transform.SetParent(this.transform.parent);
        LayoutElement el = placeHolder.AddComponent<LayoutElement>();
        LayoutElement cuel = this.GetComponent<LayoutElement>();
        el.preferredHeight = cuel.preferredHeight;
        el.preferredWidth = cuel.preferredWidth;
        el.flexibleWidth = 0;
        el.flexibleHeight = 0;
        
        placeHolder.transform.SetSiblingIndex(this.transform.GetSiblingIndex());
        parentToReturn = this.transform.parent;
        this.transform.SetParent( this.transform.parent.parent);
        
    }
    public void OnDrag(PointerEventData eventdata)
    {
        if (placeHolder.transform.parent != parentToReturn)
        {
            placeHolder.transform.SetParent(parentToReturn);
        }
        this.transform.position = eventdata.position;
        int newSiblingIndex = parentToReturn .childCount;
        for (int i = 0; i < parentToReturn.transform.childCount; i++)
        {
            newSiblingIndex = i;
            if (this.transform.position.x< parentToReturn.transform.GetChild(i).position.x)
            {
                if (placeHolder.transform.GetSiblingIndex()<newSiblingIndex)
                {
                    newSiblingIndex--;
                }                           
                break;
            }
           
        }
        placeHolder.transform.SetSiblingIndex(newSiblingIndex);
    }
    public void OnEndDrag(PointerEventData eventdata)
    {
        this.GetComponent<CanvasGroup>().blocksRaycasts = true;
        this.transform.parent = parentToReturn;
        this.transform.SetSiblingIndex(placeHolder.transform.GetSiblingIndex());
        Destroy(placeHolder);
    }
}
