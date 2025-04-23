using UnityEngine;

public interface IMovementInput
{
    public Vector2 GetMovementInput();
    public bool IsJumpPressed();
}
