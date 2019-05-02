using UnityEngine;
using System.Collections;

public class MoveCamera : MonoBehaviour {

    public int MaxFrame = 100; 
	public Transform TheCamera;
	public float MoveSpeed = 1 , RotSpeed = 10;
	public bool PressLeftMBToRot = true;
	public bool HideCursor = false;
	public bool CanUpAndDown = true;
	public float UpDownSpeed = 1;

	Vector3 CameraRot;
	void Start()
	{
        Application.targetFrameRate = MaxFrame;
		if (HideCursor)
		{
			Cursor.visible = false;
			Cursor.lockState = CursorLockMode.Locked;
		}
		CameraRot = TheCamera.eulerAngles;
		DeltaRotSpeed = RotSpeed*100;
	}

	float TheX,TheY;
	float DeltaRotSpeed;
	void Update () {
		//Move
		if (Input.GetKey(KeyCode.W)||Input.GetKey(KeyCode.UpArrow))
		{
			transform.position+=new Vector3(TheCamera.forward.x,0,TheCamera.forward.z).normalized*Time.deltaTime*MoveSpeed;
		}
		else if (Input.GetKey(KeyCode.S)||Input.GetKey(KeyCode.DownArrow))
		{
			transform.position-=new Vector3(TheCamera.forward.x,0,TheCamera.forward.z).normalized*Time.deltaTime*MoveSpeed;
		}
		if (Input.GetKey(KeyCode.A)||Input.GetKey(KeyCode.LeftArrow))
		{
			transform.position-=new Vector3(TheCamera.right.x,0,TheCamera.right.z).normalized*Time.deltaTime*MoveSpeed;
		}
		else if (Input.GetKey(KeyCode.D)||Input.GetKey(KeyCode.RightArrow))
		{
			transform.position+=new Vector3(TheCamera.right.x,0,TheCamera.right.z).normalized*Time.deltaTime*MoveSpeed;
		}
		//Camera Rote
		if(PressLeftMBToRot)
		{
			if(Input.GetMouseButton(0))
			{
				TheX = CameraRot.x - Input.GetAxis("Mouse Y")* DeltaRotSpeed * Time.deltaTime;
				if( TheX < -89 ) TheX = -89;
				if( TheX > 89 ) TheX = 89;
				TheY = CameraRot.y - Input.GetAxis("Mouse X")* DeltaRotSpeed * -0.6f * Time.deltaTime;
				CameraRot = new Vector3(TheX,TheY,0);
				TheCamera.eulerAngles = CameraRot;
			}
		}
		else{
			TheX = CameraRot.x - Input.GetAxis("Mouse Y")* DeltaRotSpeed * Time.deltaTime;
			if( TheX < -89 ) TheX = -89;
			if( TheX > 89 ) TheX = 89;
			TheY = CameraRot.y - Input.GetAxis("Mouse X")* DeltaRotSpeed * -0.6f * Time.deltaTime;
			CameraRot = new Vector3(TheX,TheY,0);
			TheCamera.eulerAngles = CameraRot;
		}
		//Cursor Visible
		if(Input.GetKeyUp(KeyCode.Escape))
		{
			HideCursor = !HideCursor;
			Cursor.visible = !HideCursor;
			if (HideCursor)
			{
				Cursor.lockState = CursorLockMode.Locked;
			}
			else 
			{
				Cursor.lockState = CursorLockMode.None;
			}
		}

		//Move Up and Down
		if(CanUpAndDown)
		{
			if(Input.GetKey(KeyCode.Space))
			{
				TheCamera.position+=Vector3.up * 0.1f * UpDownSpeed* Time.deltaTime;
			}
			else if(Input.GetKey(KeyCode.LeftShift))
			{
				TheCamera.position-=Vector3.up * 0.1f * UpDownSpeed* Time.deltaTime;
			}
		}


	}
}
