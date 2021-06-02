using UnityEngine;


namespace TheRetroCarInSpaceShooter
{
    internal sealed class EnemyMovingFromTopToBottomInASineWave : Enemy
    {
        #region Fields

        [SerializeField] private float _waveFrequency = 2.0f;
        [SerializeField] private float _waveWidth = 4.0f;
        [SerializeField] private float _waveRotationY = 45.0f;
        [SerializeField] private float _rotationForce = 3.0f;

        private float _firstValueX;
        private float _birthTime;

        #endregion


        #region UnityMethods

        private void Start()
        {
            _firstValueX = Position.x;
            _birthTime = Time.time;
        }

        #endregion


        #region Methods

        protected override void MoveTheEnemy()
        {
            Vector3 position = Position;
            float age = Time.time - _birthTime;
            float theta = Mathf.PI * _rotationForce * age / _waveFrequency;
            float sin = Mathf.Sin(theta);
            position.x = _firstValueX + _waveWidth * sin;
            Position = position;

            Vector3 rotation = new Vector3(0.0f, sin * _waveRotationY, 0.0f);
            transform.rotation = Quaternion.Euler(rotation);
            base.MoveTheEnemy();
        }

        #endregion
    }
}

