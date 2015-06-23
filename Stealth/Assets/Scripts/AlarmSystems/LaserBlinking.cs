using UnityEngine;
using System.Collections;

public class LaserBlinking : MonoBehaviour {

	public float onTime;
	public float offTime;

	private Renderer rendererObject;
	private Light laserLight;
	private float timer;

	void Awake()
	{
		timer = 0f;

		rendererObject = GetComponent<Renderer> ();
		laserLight = GetComponent<Light> ();
	}

	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (rendererObject.enabled && timer >= offTime)
		{
			SwitchBeam();
		}

		if (!rendererObject.enabled && timer >= offTime) 
		{
			SwitchBeam();
		}
	}

	void SwitchBeam ()
	{
		timer = 0f;

		rendererObject.enabled = !rendererObject.enabled;
		laserLight.enabled = !laserLight.enabled;
	}
}
