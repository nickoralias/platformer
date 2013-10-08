using UnityEngine;
using System.Collections;

public class PLATFORMER : MonoBehaviour {
	
	float speed = 1f;
	float jumpSpeed = 10f;
	float playerHeight = 1.1f;
	float stopDrag = 10000000f;

	// Use this for initialization
	void Start () {
	
	}
	
	void FixedUpdate () {
		if (Input.GetKey(KeyCode.LeftArrow)) {
			rigidbody.AddForce(Vector3.left * speed, ForceMode.VelocityChange);
		}
		
		if (Input.GetKeyUp(KeyCode.LeftArrow)) {
			rigidbody.drag = stopDrag;
		}
		
		if (Input.GetKey(KeyCode.UpArrow)) {
			rigidbody.AddForce(Vector3.forward * speed, ForceMode.VelocityChange);
		}
		
		if (Input.GetKeyUp(KeyCode.UpArrow)) {
			rigidbody.drag = stopDrag;
		}
		
		if (Input.GetKey(KeyCode.DownArrow)) {
			rigidbody.AddForce(Vector3.back * speed, ForceMode.VelocityChange);
		}
		
		if (Input.GetKeyUp(KeyCode.DownArrow)) {
			rigidbody.drag = stopDrag;
		}
		
		if (Input.GetKey(KeyCode.RightArrow)) {
			rigidbody.AddForce(Vector3.right * speed, ForceMode.VelocityChange);
		}
		
		if (Input.GetKeyUp(KeyCode.RightArrow)) {
			rigidbody.drag = stopDrag;
		}
		
		
		if (Input.GetKeyDown (KeyCode.Space)) {
			
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit rayHit = new RaycastHit(); //reserving space in memory
			
			if  (Physics.Raycast (rigidbody.position, Vector3.down, playerHeight)) {
				rigidbody.AddForce(Vector3.up * jumpSpeed, ForceMode.VelocityChange);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		rigidbody.drag = 0;
	}
}
