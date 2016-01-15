using Obstacles;
using UnityEngine;

//[RequireComponent(typeof(Light))]
public class Target : MonoBehaviour, IObstacle
{
    public IObstacle obstacle;
    public MeshRenderer Light;

    public bool IsObjectEnabled { get; set; }

    public event DOnHit OnHit;

    // Use this for initialization
    private void Start()
    {
        Light = new MeshRenderer();
    }

    // Update is called once per frame
    private void Update()
    {
        if (obstacle.IsObjectEnabled)
        {
            Light.material.SetColor("_EmissionColor", Color.blue);
            Debug.Log("Setting Color to blue");
        }
    }
}