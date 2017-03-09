using UnityEngine;
using System.Collections;

public class PickUp : MonoBehaviour {
	public Transform player;
	public float throwForce = 10;
	bool hasPlayer = false;
	bool beingCarried = false;

	void OnTriggerEnter(Collider other)
	{
		hasPlayer = true;
	}

	void OnTriggerExit(Collider other)
	{
		hasPlayer = false;
	}	

	void Update()
	{
		if(beingCarried)
		{
			if(Input.GetMouseButtonDown(0))
			{
				rigidbody.isKinematic = false;
				transform.parent = null;
				beingCarried = false;
				rigidbody.AddForce(player.forward * throwForce);
			}
		}
		else
		{
			if(Input.GetMouseButtonDown(0) && hasPlayer)
			{
				rigidbody.isKinematic = true;
				transform.parent = player;
				beingCarried = true;
			}
		}
	}
}
