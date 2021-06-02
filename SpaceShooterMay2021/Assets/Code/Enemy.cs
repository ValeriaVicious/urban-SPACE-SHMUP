using UnityEngine;


namespace TheRetroCarInSpaceShooter
{
    internal class Enemy : MonoBehaviour
    {
        #region Fields

        [SerializeField] private GameObject _shipExplosion;
        [SerializeField] private float _scaleOfExplosion = 5.0f;
        [SerializeField] private float _speed = 10.0f;
        [SerializeField] private float _fireRate = 0.3f;
        [SerializeField] private float _health = 10.0f;
        [SerializeField] private int _scoreForKillEnemy = 100;

        protected BoundsCheck _boundsCheck;

        #endregion


        #region Properties

        public Vector3 Position
        {
            get
            {
                return transform.position;
            }
            set
            {
                transform.position = value;
            }
        }

        #endregion


        #region UnityMethods

        private void Awake()
        {
            _boundsCheck = GetComponent<BoundsCheck>();
        }

        private void Update()
        {
            MoveTheEnemy();
            CheckTheObjectExtendsOffTheBottomOfTheScreen();
        }

        private void OnCollisionEnter(Collision collision)
        {
            CheckCollision(collision);
        }

        #endregion


        #region Methods

        protected virtual void MoveTheEnemy()
        {
            Vector3 enemyPosition = Position;
            enemyPosition.y -= _speed * Time.deltaTime;
            Position = enemyPosition;
        }

        protected void CheckTheObjectExtendsOffTheBottomOfTheScreen()
        {
            if (_boundsCheck != null && _boundsCheck.IsOffDown)
            {
                Destroy(gameObject);
            }
        }

        private void CheckCollision(Collision collision)
        {
            GameObject otherGameObject = collision.gameObject;

            if (otherGameObject.CompareTag(Constants.ProjectileHero))
            {
                var shipExplosion = Instantiate(_shipExplosion, transform.position, Quaternion.identity);
                shipExplosion.transform.localScale *= _scaleOfExplosion;
            }

            Destroy(otherGameObject);
            Destroy(gameObject);
        }
    }

    #endregion
}
