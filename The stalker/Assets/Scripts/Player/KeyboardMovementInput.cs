using UnityEngine;

public class KeyboardMovementInput : IMovementInput
{
    public Vector2 GetMovementInput()
    {
        return new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }

    public bool IsJumpPressed()
    {
        return Input.GetButtonDown("Jump");
    }
}
