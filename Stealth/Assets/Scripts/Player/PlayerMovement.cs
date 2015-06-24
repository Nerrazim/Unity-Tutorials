using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public AudioClip shoutingClip;
	public float turnSmoothing = 15f;
	public float speedDampTime = 0.1f;

	private Animator anim;
	private HashIDs hash;
	private Rigidbody rb;
	private AudioSource audioSource;

	void Awake () 
	{
		anim = GetComponent<Animator>();
		hash = GameObject.FindGameObjectWithTag(Tags.gameController).GetComponent<HashIDs>();
		rb = GetComponent<Rigidbody> ();
		audioSource = GetComponent<AudioSource> ();

		anim.SetLayerWeight(1, 1f);
	}

	void FixedUpdate () 
	{
		float h = Input.GetAxis ("Horizontal");
		float v = Input.GetAxis ("Vertical");

		bool sneak = Input.GetButton ("Sneak");

		MovementManagement (h, v, sneak);
	}

	void Update()
	{
		bool shout = Input.GetButtonDown("Attract");
		anim.SetBool (hash.shoutingBool, shout);
		AudioManagement (shout);
	}

	void MovementManagement(float h, float v, bool sneaking)
	{
		anim.SetBool (hash.sneakingBool, sneaking);

		if (h != 0f || v != 0f) 
		{
			Rotating (h, v);
			anim.SetFloat (hash.speedFloat, 5.5f, speedDampTime, Time.deltaTime);
		} 
		else 
		{
			anim.SetFloat (hash.speedFloat, 0f);
		}
	}

	void Rotating(float h, float v) 
	{
		Vector3 targetDirection = new Vector3 (h, 0f, v);

		Quaternion targetRotation = Quaternion.LookRotation (targetDirection, Vector3.up);
		Quaternion newRotation = Quaternion.Lerp (rb.rotation, targetRotation, turnSmoothing * Time.deltaTime);
		rb.MoveRotation (newRotation);
	}

	void AudioManagement(bool shout)
	{
		if (anim.GetCurrentAnimatorStateInfo (0).fullPathHash == hash.locomotionState) 
		{
			if(!audioSource.isPlaying) {
				audioSource.Play();
			}
		}
		else 
		{
			audioSource.Stop();
		}

		if (shout) 
		{
			AudioSource.PlayClipAtPoint(shoutingClip, transform.position);
		}
	}
}
