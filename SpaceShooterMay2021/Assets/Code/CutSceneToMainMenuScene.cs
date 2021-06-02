using UnityEngine;
using UnityEngine.SceneManagement;


namespace TheRetroCarInSpaceShooter
{
    internal sealed class CutSceneToMainMenuScene : MonoBehaviour
    {
        #region Fields

        [SerializeField] private GameObject _panel;

        #endregion


        #region UnityMethods

        private void Update()
        {
            GoToMainMenu();
        }

        #endregion


        #region Methods

        private void GoToMainMenu()
        {
            if (_panel.activeSelf)
            {
                SceneManager.LoadScene(Constants.MainMenuScene);
            }
            else
            {
                return;
            }
        }

        #endregion
    }
}