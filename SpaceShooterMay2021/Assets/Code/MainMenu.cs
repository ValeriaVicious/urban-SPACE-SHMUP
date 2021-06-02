using UnityEngine;
using UnityEngine.SceneManagement;


namespace TheRetroCarInSpaceShooter
{
    internal sealed class MainMenu : MonoBehaviour
    {
        #region Methods

        public void StartButton()
        {
            SceneManager.LoadScene(Constants.SceneOfGame);
        }

        public void OptionsButton()
        {
            SceneManager.LoadScene(Constants.SceneOfOptions);
        }

        public void AboutAuthorButton()
        {
            SceneManager.LoadScene(Constants.SceneOfAboutAuthor);
        }

        public void ExitButton()
        {
            Application.Quit();
        }

        public void BackToMainMenu()
        {
            SceneManager.LoadScene(Constants.MainMenuScene);
        }

        #endregion
    }
}