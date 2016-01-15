namespace Obstacles
{
    public delegate void DOnHit(Bumper bumper);

    public interface IObstacle
    {
        event DOnHit OnHit;
    }
}