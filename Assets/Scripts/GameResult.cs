using UnityEngine;
[CreateAssetMenu]
public class GameResult : ScriptableObject
{
    public int IndexWinner = -1;
    public int FervorWinner = 0;
    public int PopulationWinner = 0;
    public int TotalGameTurns = 0;
    public float TotalTime = 0f;
    public void Reset()
    {
        IndexWinner = -1;
        FervorWinner = 0;
        PopulationWinner = 0;
        TotalGameTurns = 0;
        TotalTime = 0f;
    }
}