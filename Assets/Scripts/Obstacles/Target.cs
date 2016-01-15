using Obstacles;
using UnityEngine;

//[RequireComponent(typeof(Light))]
public class Target : MonoBehaviour, IObstacle
{
    public Bumper Obstacle;
    public MeshRenderer Light;

    public bool IsObjectEnabled  {
        get {
            return Obstacle.IsObjectEnabled;
        }
        set {
            if (value == false)
            {
                Obstacle.IsObjectEnabled = false;
                SetColor(Color.yellow);
            }
            else
            {
                Obstacle.IsObjectEnabled = true;
                SetColor(Color.blue);
            }

        }
    }

    public event DOnHit OnHit;

    public void SetColor( Color c ) {
        Light.material.SetColor("_EmissionColor", c );
    }
}