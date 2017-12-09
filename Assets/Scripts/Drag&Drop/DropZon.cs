using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropZon : MonoBehaviour,IPointerEnterHandler,IDropHandler,IPointerExitHandler {

	public void OnPointerEnter(PointerEventData eventdata)
    {
       // Debug.Log("PointerEnter:"+this.gameObject.name);
        if (eventdata.pointerDrag != null)
        {
            eventdata.pointerDrag.GetComponent<Draggble>().parentToReturn = this.transform;
        }
    }
    public void OnDrop(PointerEventData eventdata)
    {
        //Debug.Log("PointerDrop"+ this.gameObject.name);

        
    }
    public void OnPointerExit(PointerEventData eventdata)
    {

    }
}
