using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionMenu : MonoBehaviour
{
    #region Parameter

    #region Const

    private const string LoadMenuString = "Starting Screen";

    #endregion

    #region Bool

    private bool fullScreen = true;

    #endregion

    #endregion

    #region Load Main Menu

    /// <summary>
    /// Changes between the Scenes
    /// </summary>
    public void LoadMenu()
    {
        SceneManager.LoadScene(LoadMenuString);
    }

    #endregion

    #region Fullscreen

    /// <summary>
    /// Changes to either Fullscreen or windowed
    /// </summary>
    public void Fullscreen()
    {
        if (fullScreen)
        {
            Screen.fullScreenMode = FullScreenMode.Windowed;
            fullScreen = false;
        }
        else
        {
            Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen;
            fullScreen = true;

        }
    }

    #endregion
}