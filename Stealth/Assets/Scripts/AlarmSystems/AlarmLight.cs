using UnityEngine;
using System.Collections;

public class AlarmLight : MonoBehaviour {

	public float fadeSpeed = 2f;
	public float hightIntensity = 2f;
	public float lowIntensity = 0.5f;
	public float changeMargin = 0.2f;
	public bool alarmOn;

	private float targetIntensity;
	private Light lightComp;

	void Awake()
	{
		lightComp = GetComponent<Light> ();
		lightComp.intensity = 0f;
		targetIntensity = hightIntensity;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (alarmOn) {
			lightComp.intensity = Mathf.Lerp (lightComp.intensity, targetIntensity, fadeSpeed * Time.deltaTime);
			CheckTargetIntensity ();
		} else {
			lightComp.intensity = Mathf.Lerp (lightComp.intensity, 0f, fadeSpeed * Time.deltaTime);
		}
	
	}

	void CheckTargetIntensity()
	{
		if (Mathf.Abs (targetIntensity - lightComp.intensity) < changeMargin) {
			if(targetIntensity == hightIntensity) {
				targetIntensity = lowIntensity;
			}
			else
			{
				targetIntensity = hightIntensity;
			}
		}
	}
}
