using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;

public class VirtualJoystick : MonoBehaviour,IPointerUpHandler,IPointerDownHandler,IDragHandler {
	private Image bg;
	private Image stick;
	private Vector3 inputVector;
	Vector2 pos;
	PointerEventData ped;
	public int movementRange=100;
	Vector3 m_StartPos;
	Vector2 newPos;
	int deltaX,deltaY;
	float angle,sign;
	void Start()
	{
		bg = GetComponent<Image> ();
		stick = transform.GetChild (0).GetComponent<Image> ();
		m_StartPos = stick.transform.position;
		newPos = Vector2.zero;
	}

	public virtual void OnDrag(PointerEventData data){
		int deltaX = (int)(data.position.x - m_StartPos.x);
		deltaX = Mathf.Clamp(deltaX, - movementRange, movementRange);
		newPos.x = deltaX;

		deltaY = (int)(data.position.y - m_StartPos.y);
		deltaY = Mathf.Clamp(deltaY, -movementRange, movementRange);
		newPos.y = deltaY;


		angle = Vector2.Angle (newPos, Vector2.right);
		sign = (Vector2.Dot (Vector2.up,newPos) < 0) ? 1.0f : -1.0f;
	}
	public virtual void OnPointerDown(PointerEventData data){
		OnDrag (data);
	}
	public virtual void OnPointerUp(PointerEventData data){
		newPos = Vector2.zero;
	}

	public float Angle()
	{		
		return angle * sign;
	}

	public float Value()
	{
		return newPos.magnitude;
	}
}
