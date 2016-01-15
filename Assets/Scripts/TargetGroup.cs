using System;
using UnityEngine;
using System.Collections;
using Obstacles;
using UnityEngine.UI;

public class TargetGroup : MonoBehaviour
{
    private IObstacle[] m_children = null;

    private int ActiveChildren
    {
        get
        {
            int n = 0;
            foreach (IObstacle child in m_children)
            {
                if (child.IsObjectEnabled)
                {
                    ++n;
                }
            }
            return n;
        }
    }

	// Use this for initialization
	void Start ()
    {
        m_children = GetComponentsInChildren<IObstacle>();
        Debug.Log("Current number of children: " + ActiveChildren);


	    foreach (IObstacle obstacle in m_children)
	    {
            obstacle.OnHit += OnHit;
        }
	}

    private void OnHit(IObstacle obstacle)
    {
        DeactivateChild(obstacle);
    }

    // Update is called once per frame
	void Update () {
	    if (ActiveChildren == 0)
	    {
	        StartCoroutine(ActivateChildren());
	    }
	}

    void DeactivateChild(IObstacle obstacle)
    {
        obstacle.IsObjectEnabled = false;
        Debug.Log("Child Deactivated. Current Children: " + ActiveChildren);
    }

    IEnumerator ActivateChildren()
    {
        yield return new WaitForSeconds(0.5f);
        foreach (IObstacle obstacle in m_children)
        {
            obstacle.IsObjectEnabled = true;
        }
    }
}
