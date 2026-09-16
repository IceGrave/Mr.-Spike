using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DeathCount : MonoBehaviour
{
    public static DeathCount instance;
    public int deathCount;
    [SerializeField] private Text deathText;
    void Awake()
    {
        // Ensures that the death count is not reset and stays the same when the player dies.
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
    public void addDeath()
    {
        deathCount += 1;
        deathText.text = deathCount.ToString();
    }
}
