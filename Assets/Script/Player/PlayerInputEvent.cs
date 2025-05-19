using System;
using UnityEngine;

public static class PlayerInputEvent
{
    public static event Action<Vector2> OnMoveInput;
    public static event Action OnReMoveInput;
    public static void TriggerMove(Vector2 direction)
    {
        OnMoveInput?.Invoke(direction);
    }
    public static void PlayerReMove()
    {
        OnReMoveInput?.Invoke();
    }

}
