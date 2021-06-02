using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;


namespace TheRetroCarInSpaceShooter
{
    internal sealed class Main : MonoBehaviour
    {
        #region Fields

        static public Main MainSingleton;

        [SerializeField] private GameObject[] _prefabEnemies;
        [SerializeField] private float _enemySpawnPerSecond = 0.5f;
        [SerializeField] private float _enemyPositioningOffset = 1.5f;

        private BoundsCheck _boundsCheck;

        #endregion


        #region UnityMethod

        private void Awake()
        {
            MainSingleton = this;
            _boundsCheck = GetComponent<BoundsCheck>();
            Invoke(nameof(SpawnEnemy), 1.0f / _enemySpawnPerSecond);
        }

        #endregion


        #region Methods

        private void SpawnEnemy()
        {
            int index = Random.Range(0, _prefabEnemies.Length);
            GameObject enemyObject = Instantiate(_prefabEnemies[index]);

            float enemyPadding = _enemyPositioningOffset;
            if (enemyObject.GetComponent<BoundsCheck>() != null)
            {
                enemyPadding = Mathf.Abs(enemyObject.GetComponent<BoundsCheck>().Radius);
            }

            Vector3 startPositionOfEnemyShip = Vector3.zero;
            float xMin = -_boundsCheck.CameraWidth + enemyPadding;
            float xMax = _boundsCheck.CameraWidth - enemyPadding;
            startPositionOfEnemyShip.x = Random.Range(xMin, xMax);
            startPositionOfEnemyShip.y = _boundsCheck.CameraHeight + enemyPadding;
            enemyObject.transform.position = startPositionOfEnemyShip;

            Invoke(nameof(SpawnEnemy), 1.0f / _enemySpawnPerSecond);
        }

        internal void DelayedRestart(float gameRestartDelay)
        {
            Invoke(nameof(Restart), gameRestartDelay);
        }

        private void Restart()
        {
            SceneManager.LoadScene(Constants.SceneOfGame);
        }

        #endregion
    }
}