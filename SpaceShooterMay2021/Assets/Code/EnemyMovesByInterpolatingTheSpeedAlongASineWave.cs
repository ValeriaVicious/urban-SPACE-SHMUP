using UnityEngine;


namespace TheRetroCarInSpaceShooter
{
    internal sealed class EnemyMovesByInterpolatingTheSpeedAlongASineWave : Enemy
    {
        #region Fields

        [SerializeField] private float _sinEccentricity = 0.6f;
        [SerializeField] private float _lifetime = 10.0f;
        [SerializeField] private float _angle = 2.0f;
        [SerializeField] private float _borderToRandomlyChangeThePoints = 0.5f;
        private Vector3 _randomPointOnTheLeftScreen;
        private Vector3 _randomPointOnTheRightScreen;
        private float _birthTime;

        #endregion


        #region UnityMethods

        private void Start()
        {
            DeterminingAndRandomlyChangingTheStartAndEndPoint();
        }

        #endregion


        #region Methods

        private void DeterminingAndRandomlyChangingTheStartAndEndPoint()
        {
            _randomPointOnTheLeftScreen = Vector3.zero;
            _randomPointOnTheLeftScreen.x = -_boundsCheck.CameraWidth - _boundsCheck.Radius;
            _randomPointOnTheLeftScreen.y = Random.Range(-_boundsCheck.CameraHeight, _boundsCheck.CameraHeight);

            _randomPointOnTheRightScreen = Vector3.zero;
            _randomPointOnTheRightScreen.x = _boundsCheck.CameraWidth + _boundsCheck.Radius;
            _randomPointOnTheRightScreen.y = Random.Range(-_boundsCheck.CameraWidth, _boundsCheck.CameraHeight);

            if (Random.value > _borderToRandomlyChangeThePoints)
            {
                _randomPointOnTheLeftScreen.x *= -1;
                _randomPointOnTheRightScreen.x *= -1;
            }

            _birthTime = Time.time;
        }

        protected override void MoveTheEnemy()
        {
            float u = (Time.time - _birthTime) / _lifetime;

            if (u > 1)
            {
                Destroy(gameObject);
                return;
            }

            u += _sinEccentricity * (Mathf.Sin(u * Mathf.PI * _angle));
            Position = (1 - u) * _randomPointOnTheLeftScreen + u * _randomPointOnTheRightScreen;
        }

        #endregion
    }
}
