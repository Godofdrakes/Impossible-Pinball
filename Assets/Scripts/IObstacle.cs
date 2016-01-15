using System;
using UnityEngine;

namespace Obstacles
{
    public delegate void DOnHit(Bumper bumper);

    public interface IObstacle
    {

        bool IsObjectEnabled { get; set; }

        event DOnHit OnHit;
    }
}