using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystal : MonoBehaviour
{

    // initially crystal is active
    public bool Active = true;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.rotation = Quaternion.Euler(45f, Time.timeSinceLevelLoad * 60f, 45f);
	}

    // when sphere touches crystal
    private void OnTriggerEnter(Collider collidedWithObj)
    {
        Debug.Log("Collided with " + collidedWithObj.name);

        if (!Active) return;
        if (collidedWithObj.name != "Sphere") return;

        var audioSource = GetComponent<AudioSource>();
        audioSource.Play();

        var renderer = GetComponent<Renderer>();
        renderer.enabled = false;
        Active = false;

        FindObjectOfType<GameController>().UpdateCrystalCounterText();
    }
}
