using UnityEngine;
using System.Collections;

public class LEDControl : MonoBehaviour
{

    private Renderer renderer;
    private Material light;

	// Use this for initialization
	void Start ()
	{
	    renderer = GetComponent<Renderer>();
	    light = renderer.material;
	}
	
	// Update is called once per frame
	void Update () {

	    if (Input.GetKeyDown(KeyCode.L))
	    {
            light.SetColor("_EmissionColor", Color.blue);
	    }

	}
}
