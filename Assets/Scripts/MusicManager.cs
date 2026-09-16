using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    public static MusicManager instance;
    private AudioSource audioSource;
    [SerializeField] private AudioClip HappyMusic;
    [SerializeField] private AudioClip ScaryMusic;
    [SerializeField] private AudioClip MetalMusic;
    private void Awake()
    {
        // Ensures that the music stays throughout the game and doesn't get destroyed. 
        audioSource = GetComponent<AudioSource>();
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Chooses which background music to play based on what level Player is on.
        if (scene.buildIndex > 10 && scene.buildIndex != 13)
        {
            audioSource.clip = MetalMusic;
        }
        else if (scene.buildIndex > 5 && scene.buildIndex != 13)
        {
            audioSource.clip = ScaryMusic;
        }
        else
        {
            audioSource.clip = HappyMusic;
        }
        playMusic();
    }
    public void stopMusic()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }
    public void playMusic()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }
}
