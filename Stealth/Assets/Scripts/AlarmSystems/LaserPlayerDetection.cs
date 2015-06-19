using UnityEngine;
using System.Collections;

public class LaserPlayerDetection : MonoBehaviour 
{
	private GameObject player;
	private LastPlayerSighting lastPlayerSighting;
	private Renderer renderer ;

	void Awake()
	{
		player = GameObject.FindGameObjectWithTag (Tags.player);
		lastPlayerSighting = GameObject.FindGameObjectWithTag (Tags.gameController).GetComponent<LastPlayerSighting> ();
		renderer = GetComponent<Renderer> ();
	}

	void OnTriggerStay(Collider other)
	{
		if (renderer.enabled) {
			if (other.gameObject == player) {
				lastPlayerSighting.position = other.transform.position;
			}
		}
	}
}
