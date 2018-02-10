using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;  

public class UI_event : MonoBehaviour,  
IPointerClickHandler,  
IPointerDownHandler,  
IPointerEnterHandler,  
IPointerExitHandler,  
IPointerUpHandler,  
ISelectHandler,  
IUpdateSelectedHandler,  
IDeselectHandler,  
IDragHandler,  
IEndDragHandler,  
IDropHandler,  
IScrollHandler,  
IMoveHandler  
{  
	public delegate void VoidDelegate(GameObject go);  
	public VoidDelegate onClick;  
	public VoidDelegate onDown;  
	public VoidDelegate onEnter;  
	public VoidDelegate onExit;  
	public VoidDelegate onUp;  
	public VoidDelegate onSelect;  
	public VoidDelegate onUpdateSelect;  
	public VoidDelegate onDeSelect;  
	public VoidDelegate onDrag;  
	public VoidDelegate onDragEnd;  
	public VoidDelegate onDrop;  
	public VoidDelegate onScroll;  
	public VoidDelegate onMove;  
	
	public object parameter;  
	
	public void OnPointerClick(PointerEventData eventData) { if (onClick != null) onClick(gameObject); }  
	public void OnPointerDown(PointerEventData eventData) { if (onDown != null) onDown(gameObject); }  
	public void OnPointerEnter(PointerEventData eventData) { if (onEnter != null) onEnter(gameObject); }  
	public void OnPointerExit(PointerEventData eventData) { if (onExit != null) onExit(gameObject); }  
	public void OnPointerUp(PointerEventData eventData) { if (onUp != null) onUp(gameObject); }  
	public void OnSelect(BaseEventData eventData) { if (onSelect != null) onSelect(gameObject); }  
	public void OnUpdateSelected(BaseEventData eventData) { if (onUpdateSelect != null) onUpdateSelect(gameObject); }  
	public void OnDeselect(BaseEventData eventData) { if (onDeSelect != null) onDeSelect(gameObject); }  
	public void OnDrag(PointerEventData eventData) { if (onDrag != null) onDrag(gameObject); }  
	public void OnEndDrag(PointerEventData eventData) { if (onDragEnd != null) onDragEnd(gameObject); }  
	public void OnDrop(PointerEventData eventData) { if (onDrop != null) onDrop(gameObject); }  
	public void OnScroll(PointerEventData eventData) { if (onScroll != null) onScroll(gameObject); }  
	public void OnMove(AxisEventData eventData) { if (onMove != null) onMove(gameObject); }  
	
	static public UI_event Get (GameObject go){
		UI_event listener = go.GetComponent<UI_event>();
		if (listener == null) listener = go.AddComponent<UI_event>();
		return listener;
	}
}  


//=====使用方式：=====

/*
UI_event.Get(btn.gameObject).onClick = OnClickBtn;     
UI_event.Get(btn.gameObject).parameter = index;     

private void OnClickBtn(GameObject go)     
{     
	int index = (int)UUIEventListener.Get(go).parameter;     
	Debug.Log("您单击的索引为：" + index);     
} 
*/
