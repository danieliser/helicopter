using UnityEngine;

public class CameraMovement : MonoBehaviour{

	public float screenPctg;
	public float maxAngle = 30f;
	public Transform other;

	private Vector3 originalLocalPos, otherLocalPos;
	private Quaternion originalLocalRot, otherLocalRot;

	private Vector3 mousePrev;
	void Start(){
		mousePrev = Input.mousePosition;

		originalLocalPos = transform.localPosition;
		originalLocalRot = transform.localRotation;
		otherLocalPos = other.localPosition;
		otherLocalRot = other.localRotation;
	}

	public void Update(){
		Vector3 mouseCurr = Input.mousePosition;
		float deltaY = Screen.height * screenPctg - mouseCurr.y;
		float pctg = deltaY / (Screen.height * screenPctg);

		pctg = Mathf.Clamp01(pctg);

		transform.localPosition = Vector3.Lerp(originalLocalPos, otherLocalPos, pctg);
		transform.localRotation = Quaternion.Lerp(originalLocalRot, otherLocalRot, pctg);

		/*Vector3 rotationVector = new Vector3(1, 0, 0);

		Quaternion rotation = Quaternion.Euler(rotationVector * pctg * -maxAngle);		
		transform.localRotation = rotation;
		mousePrev = mouseCurr;*/
	}
}