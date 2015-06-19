using UnityEngine;
using System.Collections;

public class LasetBlinking : MonoBehaviour {

	public float onTime;
	public float offTime;

	private Renderer renderer;
	private Light laserLight;
	private float timer;

	void Awake()
	{
		renderer = GetComponent<Renderer> ();
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;

		if (renderer.enabled = !renderer.enabled)
		{
			SwitchBeam();
		}

		if (!renderer.enabled && timer >= offTime) 
		{
			SwitchBeam();
		}
	}

	void SwitchBeam ()
	{
		timer = 0f;

		renderer.enabled = !renderer.enabled;
		laserLight.enabled = !laserLight.enabled;
	}
}
