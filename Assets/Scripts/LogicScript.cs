using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LogicScript : MonoBehaviour
{
    public GameObject gameOverScreen;
    public AudioSource gameOverSound;
    [SerializeField] private DeathCount deathCount;
    [SerializeField] private GameObject deathNum;
    [SerializeField] private MusicManager MusicManager;
    public void gameOver()
    {
        // Ensures that the counter that we want to show gets used and counts the number of deaths correctly
        DeathCount.instance.addDeath();
        // Restarts game after a second, plays game over sounds and stops music
        Invoke("restartGame", 1f);
        MusicManager.instance.stopMusic();
        gameOverSound.Play();
    }
    public void restartGame()
    {
        SceneManager.LoadScene("Level1");
    }
}
