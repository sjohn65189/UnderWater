using UnityEngine;
using UnityEngine.SceneManagement; // Required for scene management

public class RestartGame : MonoBehaviour
{
    // This method restarts the game by loading the first scene
    public void RestartEntireGame()
    {
        // Loads the first scene by its build index (0)
        // Assuming the first scene is the start of your game
        SceneManager.LoadScene(1);
    }
}
