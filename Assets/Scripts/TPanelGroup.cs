using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TPanelGroup : MonoBehaviour
{

    private Bumper[] m_children = null;

    private int ActiveChildren
    {
        get
        {
            int n = 0;
            foreach (Bumper child in m_children)
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
        m_children = GetComponentsInChildren<Bumper>();
        Debug.Log("Current number of children: " + ActiveChildren);


	    foreach (Bumper bumper in m_children)
	    {
            bumper.OnHit += OnHit;
        }
	}

    private void OnHit(Bumper bumper)
    {
        DeactivateChild(bumper);
        
        
    }

    // Update is called once per frame
	void Update () {
	    if (ActiveChildren == 0)
	    {
	        StartCoroutine(ActivateChildren());
	    }
	}

    void DeactivateChild(Bumper bumper)
    {
        bumper.IsObjectEnabled = false;
        Debug.Log("Child Deactivated. Current Children: " + ActiveChildren);
        Debug.Log(m_children.Length);
    }

    IEnumerator ActivateChildren()
    {
        yield return new WaitForSeconds(0.5f);
        foreach (Bumper bumper in m_children)
        {
            bumper.IsObjectEnabled = true;
        }
    }
}
