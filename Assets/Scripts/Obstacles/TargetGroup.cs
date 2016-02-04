using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Obstacles;
using UnityEngine;

public class TargetGroup : MonoBehaviour
{
    private List<IObstacle> m_children = new List<IObstacle>();

    private int ActiveChildren
    {
        get
        {
            var n = 0;
            foreach (var child in m_children)
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
    private void Start()
    {
        m_children = new List<IObstacle>(GetComponentsInChildren<IObstacle>()
            .Where(obstacle => obstacle.gameObject.transform.parent == gameObject.transform));
        Debug.Log("Current number of children: " + ActiveChildren);


        foreach (var obstacle in m_children)
        {
            obstacle.OnHit += OnHit;
        }
    }

    private void OnHit(IObstacle obstacle)
    {
        DeactivateChild(obstacle);
    }

    // Update is called once per frame
    private void Update()
    {
        if (ActiveChildren == 0)
        {
            StartCoroutine(ActivateChildren());
        }
    }

    private void DeactivateChild(IObstacle obstacle)
    {
        obstacle.IsObjectEnabled = false;
        Debug.Log("Child Deactivated. Current Children: " + ActiveChildren);
    }

    private IEnumerator ActivateChildren()
    {
        yield return new WaitForSeconds(0.5f);
        foreach (var obstacle in m_children)
        {
            obstacle.IsObjectEnabled = true;
        }
    }
}