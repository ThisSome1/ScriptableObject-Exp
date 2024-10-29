using UnityEngine;

public abstract class PlayerBase : MonoBehaviour, IPlayer
{
    protected abstract void Move(bool isPressed, Vector2 dir);
    public abstract void Taunt(bool isPressed);
}