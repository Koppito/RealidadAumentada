using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class VirtualJoystick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler {

	public enum Axis {Horizontal, Vertical, Both_Axis};
	public Axis AxisToUse;

	private Image bgImg;
	private Image joystickImg;
	private Vector3 inputVector;
	private Vector3 drawingVector;

	void Start() {
		bgImg = GetComponent<Image> ();
		joystickImg = transform.GetChild (0).GetComponent<Image> ();
	}

	public virtual void OnDrag(PointerEventData ped) {
		Vector2 pos;
		if(RectTransformUtility.ScreenPointToLocalPointInRectangle(bgImg.rectTransform, ped.position, ped.pressEventCamera, out pos)) {
			pos.x = (pos.x / bgImg.rectTransform.sizeDelta.x);
			pos.y = (pos.y / bgImg.rectTransform.sizeDelta.y);

			//Detect Axis To Use
			if (AxisToUse == Axis.Both_Axis) {
				drawingVector = new Vector3 (inputVector.x * (bgImg.rectTransform.sizeDelta.x / 3), inputVector.z * (bgImg.rectTransform.sizeDelta.y / 3));
				inputVector = new Vector3 (pos.x, 0, pos.y);
			}
			if (AxisToUse == Axis.Horizontal) {
				drawingVector = new Vector3 (inputVector.x * (bgImg.rectTransform.sizeDelta.x/3), 0);
				inputVector = new Vector3 (pos.x, 0, 0);
			}
			if (AxisToUse == Axis.Vertical) {
				drawingVector = new Vector3 (0, inputVector.z * (bgImg.rectTransform.sizeDelta.y / 3));
				inputVector = new Vector3 (0, 0, pos.y);
			}

			inputVector = (inputVector.magnitude > 1.0f) ? inputVector.normalized : inputVector;

			//Move Joystick IMG
			joystickImg.rectTransform.anchoredPosition = drawingVector;

		}
	}

	public virtual void OnPointerDown(PointerEventData ped) {
		OnDrag (ped);
	}

	public virtual void OnPointerUp(PointerEventData ped) {
		inputVector = Vector3.zero;
		joystickImg.rectTransform.anchoredPosition = Vector3.zero;
	}

	public float Horizontal() {
		if (inputVector.x != 0)
			return inputVector.x;
		else
			return Input.GetAxis ("Horizontal");
	}

	public float Vertical() {
		if (inputVector.z != 0)
			return inputVector.z;
		else
			return Input.GetAxis ("Vertical");
	}
}
