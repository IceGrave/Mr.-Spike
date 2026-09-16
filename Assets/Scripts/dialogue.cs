using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
public class DialogueSystem : MonoBehaviour
{
    // This script is used to display dialogue in the game. 
    [SerializeField] private Text dialogueText;
    [SerializeField] private string[] dialogueLines;
    [SerializeField] private GameObject Textbox;
    [SerializeField] private Player player;
    // Stores the names of the scenes that have already shown the dialogue, so that the dialogue is not shown again.
    private static HashSet<string> shownDialogueScenes = new HashSet<string>();
    // Keeps track of the current line of dialogue that needs to be displayed.
    private int currentLineIndex = 0;

    void Start()
    {
        string currentScene = SceneManager.GetActiveScene().name;
        // Checks if the level has already shown dialogue, if it has then the player is allowed to move and there is no dialogue box shown.
        if (shownDialogueScenes.Contains(currentScene))
        {
            player.EnableMovement();
            Textbox.SetActive(false);
            return;
        }
        // If the level has not shown dialogue, the player movement is disabled and the dialogue starts.
        player.DisableMovement();
        currentLineIndex = 0;
        dialogueText.text = dialogueLines[currentLineIndex];
    }
    void Update()
    {
        // When the player presses return, the next line of dialogue is shown. Once all lines have been shown, the player is allowed to move and the dialogue is hidden.
        if (Input.GetKeyDown(KeyCode.Return))
        {
            currentLineIndex++;
            if (currentLineIndex < dialogueLines.Length)
            {
                dialogueText.text = dialogueLines[currentLineIndex];
            }
            else
            {
                shownDialogueScenes.Add(SceneManager.GetActiveScene().name);
                player.EnableMovement();
                Textbox.SetActive(false);
            }
        }
    }
}

