using UnityEngine;

public interface IMovable
{
    void Move();
    void MoveRight();
    void MoveLeft();
    void ReturnToDefaultSide();
}