using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameStateData
{
    public Vector2 playerPos;
    public List<Vector2> boxPositions;

    public GameStateData(Vector2 playerPos, List<Vector2> boxPositions)
    {
        this.playerPos = playerPos;
        this.boxPositions = new List<Vector2>(boxPositions);
    }
}
