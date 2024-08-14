using System;

public interface IPlayerMover 
{
    public event Action Fall;
    public event Action Land;

    public void SetPlaneSpeed(float speed);
    public void SetVerticalSpeed(float speed);
}