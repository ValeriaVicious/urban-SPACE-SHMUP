using UnityEngine;


namespace TheRetroCarInSpaceShooter
{
    internal sealed class PauseMenu : MonoBehaviour
    {
        #region Fields

        [SerializeField] private GameObject _pauseMenuUI;
        public static bool IsPausedGame = false;

        #endregion


        #region UnityMethods

        private void Update()
        {
            CheckThePause();
        }

        #endregion


        #region Methods

        private void CheckThePause()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (IsPausedGame)
                {
                    Resume();
                }
                else
                {
                    Pause();
                }
            }
        }

        public void Resume()
        {
            _pauseMenuUI.SetActive(false);
            Time.timeScale = 1.0f;
            IsPausedGame = false;
        }

        public void Pause()
        {
            _pauseMenuUI.SetActive(true);
            Time.timeScale = 0.0f;
            IsPausedGame = true;
        }

        #endregion
    }
}