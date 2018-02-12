using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{

    public Transform ObjectToTrack;

    public Vector3 delta;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
    // fixed because of shaking camera)
	void FixedUpdate () {
        // camera looking at ball
		transform.LookAt(ObjectToTrack);
        // change camera position

            var trackedRigidbody = ObjectToTrack.GetComponent<Rigidbody>();
	        var speed = trackedRigidbody.velocity.magnitude;
	        // objecToTrack.position = positon of the ball; delta = camera offset; speed = speed of the ball
    
            var targetPosition = ObjectToTrack.position + delta * (speed / 20f + 1);
            //smoothing camera tracking
	    transform.position = Vector3.Lerp(transform.position, targetPosition, Time.smoothDeltaTime * 2f);
	}
}
