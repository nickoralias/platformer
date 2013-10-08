using UnityEngine;
using System.Collections;

public class CLICK_TO_MOVE : MonoBehaviour {
	
	private Vector3 destination;
	private Vector3 move;
	public ParticleEmitter fireworks;
	public ParticleEmitter firework;
	public float stoppingDistance = 10f;
	public float drag;
	public float speed = 10f;
	
	// Use this for initialization
	void Start () {
		destination = rigidbody.position;
	}
	
	void FixedUpdate () {
				
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit rayHit = new RaycastHit(); //reserving space in memory
		
		if (Input.GetMouseButtonDown(0) && Physics.Raycast(ray, out rayHit))
		{
			destination = rayHit.point;
			firework = Instantiate(fireworks, destination, Quaternion.identity) as ParticleEmitter;
			fireworks.Emit();
		}	
		
		move = destination - rigidbody.position;
		
		if (rigidbody.position != destination)
		{
			rigidbody.AddForce(move.normalized * speed, ForceMode.VelocityChange);
			if (move.magnitude < stoppingDistance)
			{
				drag = 15;
			}
			rigidbody.drag = drag;
		}	
	}
	
	// Update is called once per frame
	void Update () {
		drag = 0;
	}
}
