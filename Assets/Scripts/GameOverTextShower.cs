using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameOverTextShower : MonoBehaviour
{

    public GameResult GameOverResults;
    public Text PlayerShower;
    public Text StatsShower;

    void Start()
    {
        PlayerShower.text = "The winner is PLAYER" + (GameOverResults.IndexWinner + 1) + " with " + GameOverResults.FervorWinner + " fervor and " + GameOverResults.PopulationWinner + " population left!!! Congratz!";
        StatsShower.text = "The game lasted for " + GameOverResults.TotalGameTurns + " turns, for a total duration of " + GameOverResults.TotalTime + " seconds.";
    }

}
