using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FieldControl : MonoBehaviour
{

    public static List<GameObject> m_currentBalls;
    private GameObject[] m_balls;

    [SerializeField][Range(0,10)] private int m_tiltForce = 5;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update ()
	{
	    m_currentBalls = new List<GameObject>(GameObject.FindGameObjectsWithTag(SRTags.Ball));
	    if (Input.GetKeyDown(KeyCode.Z))
	    {
	        TiltLeft();
	    }
        if (Input.GetKeyDown(KeyCode.Slash))
        {
            TiltRight();
        }
    }

    public void TiltRight()
    {
        Debug.Log("About to Tilt");
        foreach (GameObject ball in m_currentBalls)
        {
            ball.GetComponent<Rigidbody>().AddForce(Vector3.right * m_tiltForce * .1f, ForceMode.Impulse);
            Debug.Log("Tilted");
        }
    }
    public void TiltLeft()
    {
        Debug.Log("About to Tilt");
        foreach (GameObject ball in m_currentBalls)
        {
            ball.GetComponent<Rigidbody>().AddForce(Vector3.left * m_tiltForce * .1f, ForceMode.Impulse);
            Debug.Log("Tilted");
        }
    }
}
