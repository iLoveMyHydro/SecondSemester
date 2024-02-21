using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    #region Parameter

    #region Const

    private const string loadLevel = "All Stuff together";

    private const string loadOptions = "Options";

    #endregion

    #endregion

    #region Load GameScene

    /// <summary>
    /// Changes the scene to the main Game if you press the button
    /// </summary>
    public void LoadGameScene()
    {
        SceneManager.LoadScene(loadLevel);
    }

    #endregion

    #region LoadOptions

    /// <summary>
    /// Changes the Scene to the Options if you press the button
    /// </summary>
    public void LoadOptions()
    {
        SceneManager.LoadScene(loadOptions);
    }

    #endregion

    #region QuitGame

    /// <summary>
    /// Ends the game if you press the button
    /// </summary>
    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
    Application.Quit();
#endif
    }

    #endregion
}