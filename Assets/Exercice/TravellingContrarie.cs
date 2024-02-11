using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TravellingContrarie : MonoBehaviour
{
	public Transform target;
	public Camera camera;

	public float witdhConstant;

	private float zoomTime = 3.0f;
	private bool canControlZoom=false;
	private void Awake()
	{
		camera = GetComponent<Camera>();
	}



	private void Start()
	{
		float distance=Vector3.Distance(transform.position , target.position);
		witdhConstant=2 * distance * Mathf.Tan(camera.fieldOfView * 0.5f * Mathf.Deg2Rad);
		StartCoroutine(ZoomIn());
		//Start a automatic zoom effect to prove it work
	}

	private float GetFOV(float currentDistance)
	{
		return 2*Mathf.Atan(witdhConstant/(2*currentDistance))*Mathf.Rad2Deg;
	}



	private void Update()
	{
		float currentDist = Vector3.Distance(transform.position, target.position);
		camera.fieldOfView = GetFOV(currentDist);
		transform.Translate((target.position.x- transform.position.x ) * Vector3.right * Time.deltaTime * 5f);

		if (canControlZoom)
		{
			if (Input.GetKey(KeyCode.KeypadPlus))
			{
				if (currentDist >1.95f)
					transform.Translate(1 * Vector3.forward * Time.deltaTime * 5f);
			}
			if (Input.GetKey(KeyCode.KeypadMinus))
			{

				transform.Translate(-1 * Vector3.forward * Time.deltaTime * 5f);
			}
		}

	}

	//Utilisé simplement pour démontrer que le dolly zoom est fonctionnel au début
	IEnumerator ZoomIn()
	{
		float elapsedTime1=0.0f;
		while (elapsedTime1 < zoomTime)
		{
			float currentDist = Vector3.Distance(transform.position, target.position);
			elapsedTime1 += Time.deltaTime;
			if (currentDist > 1.95f)
				transform.Translate(1 * Vector3.forward * Time.deltaTime * 5f);
			yield return null;
		}
		StartCoroutine(ZoomOut());
	}

	IEnumerator ZoomOut()
	{
		float elapsedTime1 = 0.0f;
		while (elapsedTime1 < zoomTime)
		{
			elapsedTime1 += Time.deltaTime;
			transform.Translate(-2 * Vector3.forward * Time.deltaTime * 5f);
			yield return null;
		}
		canControlZoom = true;
	}
}
