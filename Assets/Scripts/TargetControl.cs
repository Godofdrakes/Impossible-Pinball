using UnityEngine;
using System.Collections;

public class TargetControl : MonoBehaviour
{

    public GameObject Target;
    public MeshRenderer LED;
    
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        LED.material.SetColor("_EmissionColor", Color.blue);
    }
}