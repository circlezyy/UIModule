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
        placeHolder = new GameObject() ;
        placeHolder.transform.SetParent(this.transform.parent);
        LayoutElement el = placeHolder.AddComponent<LayoutElement>();
        LayoutElement cuel = this.GetComponent<LayoutElement>();
        el.preferredHeight = cuel.preferredHeight;
        el.preferredWidth = cuel.preferredWidth;
        el.flexibleWidth = 0;
        el.flexibleHeight = 0;
        parentToReturn = this.transform.parent;
        this.transform.parent = this.transform.parent.parent;
    }
    public void OnDrag(PointerEventData eventdata)
    {
        this.GetComponent<CanvasGroup>().blocksRaycasts = false;
        this.transform.position = eventdata.position;
    }
    public void OnEndDrag(PointerEventData eventdata)
    {
        this.GetComponent<CanvasGroup>().blocksRaycasts = true;
        this.transform.parent = parentToReturn;
        Destroy(placeHolder);
    }
}
