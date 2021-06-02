using UnityEngine;
using UnityEngine.UI;


namespace TheRetroCarInSpaceShooter
{
    internal sealed class Hero : MonoBehaviour
    {
        #region Fields

        [SerializeField] private GameObject _projectilePrefab;
        [SerializeField] private GameObject _playerShipExplosion;
        [SerializeField] private float _projectileSpeed = 40.0f;
        [SerializeField] private float _speedOfTheCar = 30.0f;
        [SerializeField] private float _carTilt = -45.0f;
        [SerializeField] private float _carPitch = 30.0f;
        [SerializeField] private float _gameRestartDelay = 2.0f;
        [SerializeField] private float _scaleOfExplosion = 5.0f;
        [SerializeField] private int _numberOfScore = 25;

        static public Hero SingletonHero;

        private GameObject _lastTriggerGameObject = null;
        private float _shieldLevel = 1;

        #endregion


        #region Properties

        public float ShieldLevel
        {
            get
            {
                return _shieldLevel;
            }
            set
            {
                _shieldLevel = Mathf.Min(value, 4);

                if (value < 0)
                {
                    Destroy(gameObject);
                    Main.MainSingleton.DelayedRestart(_gameRestartDelay);
                }
            }
        }

        #endregion


        #region UnityMethods

        private void Awake()
        {
            if (SingletonHero == null)
            {
                SingletonHero = this;
            }
        }

        private void Update()
        {
            MoveTheCar();
            Shoot();
        }

        private void OnTriggerEnter(Collider other)
        {
            CheckTheCollision(other);
        }

        #endregion


        #region Methods

        private void MoveTheCar()
        {
            float horizontalAxis = Input.GetAxis(Constants.HorizontalInput);
            float verticalAxis = Input.GetAxis(Constants.VerticalInput);

            Vector3 positionOfTheCar = transform.position;
            positionOfTheCar.x += horizontalAxis * _speedOfTheCar * Time.deltaTime;
            positionOfTheCar.y += verticalAxis * _speedOfTheCar * Time.deltaTime;

            transform.position = positionOfTheCar;
            transform.rotation = Quaternion.Euler(verticalAxis * _carPitch, horizontalAxis * _carTilt, 0.0f);
        }

        private void CheckTheCollision(Collider other)
        {
            Transform rootTransform = other.gameObject.transform.root;
            GameObject gameObject = rootTransform.gameObject;

            if (gameObject == _lastTriggerGameObject)
            {
                return;
            }
            _lastTriggerGameObject = gameObject;

            if (gameObject.CompareTag(Constants.Enemy))
            {
                Instantiate(_playerShipExplosion, other.transform.position, Quaternion.identity);
                ShieldLevel--;
                Destroy(other.gameObject);
                Destroy(gameObject);
            }
        }

        private void Shoot()
        {
            if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                Fire();
            }
        }

        private void Fire()
        {
            GameObject projectile = Instantiate(_projectilePrefab);
            projectile.transform.position = transform.position;
            Rigidbody rigidbody = projectile.GetComponent<Rigidbody>();
            rigidbody.velocity = Vector3.up * _projectileSpeed;
        }

        #endregion
    }

}
