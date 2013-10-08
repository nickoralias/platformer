using UnityEngine;
using System.Collections;


public class NPT_BOT : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Ray ray = new Ray (transform.position, transform.forward);
		RaycastHit rayHit = new RaycastHit();

		//always walk forward, relative to where I'm facing
		rigidbody.AddRelativeForce(Vector3.forward, ForceMode.VelocityChange);
	
		//if you haven't already, TEST IT, to see if the bot walks forward
		//detect if there's a wall ahead of me; turn left or right if there is
		if(Physics.Raycast(ray, out rayHit, 20f)) {
			float random = Random.Range (0, 10);
			if(random < 5) {
				rigidbody.transform.Rotate(Vector3.up, 90f);
			}	
			else {
				rigidbody.transform.Rotate (Vector3.up, -90f);
			}
		}		
	}
}
