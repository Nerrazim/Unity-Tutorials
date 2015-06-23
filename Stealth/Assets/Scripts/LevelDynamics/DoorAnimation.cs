using UnityEngine;
using System.Collections;

public class DoorAnimation : MonoBehaviour {

	public bool requireKey;
	public AudioClip doorSwishClip;
	public AudioClip accessDeniedClip;

	private Animator anim;
	private HashIDs hash;
	private AudioSource audioPlayer;

	private GameObject player;
	private PlayerInventory playerInvetory;
	private int count;

	void Awake()
	{
		anim = GetComponent<Animator> ();
		hash = GameObject.FindGameObjectWithTag (Tags.gameController).GetComponent<HashIDs> ();
		audioPlayer = GetComponent<AudioSource> ();
		player = GameObject.FindGameObjectWithTag (Tags.player);
		playerInvetory = player.GetComponent<PlayerInventory> ();
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject == player) 
		{
			if(requireKey)
			{
				if(playerInvetory.hasKey)
				{
					++count;
				} 
				else
				{
					audioPlayer.clip = accessDeniedClip;
					audioPlayer.Play();
				}
			} 
			else 
			{
				++count;
			}

		} 
		else if(other.gameObject.tag == Tags.enemy)
		{
			if(other is CapsuleCollider)
			{
				++count;
			}
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.gameObject == player || (other.gameObject.tag == Tags.enemy && other is CapsuleCollider)) 
		{
			count = Mathf.Max (0, count - 1);
		}
	}

	void Update()
	{
		anim.SetBool (hash.openBool, count > 0);

		if(anim.IsInTransition(0) && !audioPlayer.isPlaying)
		{
			audioPlayer.clip = doorSwishClip;
			audioPlayer.Play();
		}
	}
}
