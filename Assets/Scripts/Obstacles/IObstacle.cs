using System;
using UnityEngine;

namespace Obstacles
{
    public delegate void DOnHit(IObstacle sourceObject);

    public interface IObstacle
    {

        bool IsObjectEnabled { get; set; }

        GameObject gameObject { get; }

        event DOnHit OnHit;
    }
}