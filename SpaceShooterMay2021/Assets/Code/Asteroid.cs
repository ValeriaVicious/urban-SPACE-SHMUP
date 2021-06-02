using UnityEngine;


namespace TheRetroCarInSpaceShooter
{
    internal sealed class Asteroid : Enemy
    {
        #region Fields

        [SerializeField] private GameObject _asteroidExplosionPrefab;
        [SerializeField] private float _rotation;
        [SerializeField] private float _maxSpeed;
        [SerializeField] private float _minSpeed;
        [SerializeField] private float _minScaleOfAsteroidSize = 0.5f;
        [SerializeField] private float _maxScaleOfAsteroidSize = 2.0f;

        private Rigidbody _asteroidBody;

        #endregion


        #region UnityMethods

        private void Awake()
        {
            _boundsCheck = GetComponent<BoundsCheck>();
        }

        private void Start()
        {
            _asteroidBody = GetComponent<Rigidbody>();
            SetAsteroidCharacteristics();
        }

        private void Update()
        {
            MoveTheEnemy();
            CheckTheObjectExtendsOffTheBottomOfTheScreen();
        }

        #endregion


        #region Methods

        private void SetAsteroidCharacteristics()
        {
            var speed = Random.Range(_minSpeed, _maxSpeed);
            var scaleOfAsteroid = Random.Range(_minScaleOfAsteroidSize, _maxScaleOfAsteroidSize);

            _asteroidBody.transform.localScale *= scaleOfAsteroid;
            _asteroidBody.angularVelocity = Random.insideUnitSphere * _rotation;
            _asteroidBody.velocity = new Vector3(0.0f, 0.0f, -speed);
        }

        #endregion

    }
}
