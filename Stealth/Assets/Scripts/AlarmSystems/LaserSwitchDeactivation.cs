using UnityEngine;
using System.Collections;

public class LaserSwitchDeactivation : MonoBehaviour {

	public GameObject laser;                
	public Material unlockedMat;            

	private AudioSource audioPlayer;
	private GameObject player;              
	
	
	void Awake ()
	{
		player = GameObject.FindGameObjectWithTag(Tags.player);
		audioPlayer = GetComponent<AudioSource> ();
	}
	
	
	void OnTriggerStay (Collider other)
	{
		if (other.gameObject == player) {

			if (Input.GetButton ("Switch"))
			{
				LaserDeactivation ();
			}
		}
	}
	
	
	void LaserDeactivation ()
	{
		laser.SetActive(false);

		Renderer screen = transform.Find("prop_switchUnit_screen").GetComponent<Renderer>();

		screen.material = unlockedMat;

		audioPlayer.Play();
	}
}
