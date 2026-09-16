using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
    public void startGame()
    {
        SceneManager.LoadScene("Level1");
    }
}
