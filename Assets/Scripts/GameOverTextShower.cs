using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameOverTextShower : MonoBehaviour
{

    public GameResult GameOverResults;
    public Text PlayerShower;
    public Text StatsShower;
    public AudioSource Source;
    public AudioClip[] Clips;

    public string[] Citations;
    public string GalliPhrase;
    public string RomansPhrase;
    public Text CitShower;

    void Start()
    {
        Source.clip = Clips[GameOverResults.IndexWinner];
        Source.time = 0f;
        Source.Play();
        PlayerShower.text = (GameOverResults.IndexWinner == 0 ? RomansPhrase : GalliPhrase);
        StatsShower.text = "The game lasted for " + GameOverResults.TotalGameTurns + " turns, for a total duration of " + GameOverResults.TotalTime + " seconds.";
        CitShower.text = Citations[Random.Range(0, Citations.Length)];
    }

}
