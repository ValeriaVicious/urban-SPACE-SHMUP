using UnityEngine;


namespace TheRetroCarInSpaceShooter
{
    internal sealed class EnemyMovementOnABezierCurve : Enemy
    {
        #region Fields

        [SerializeField] private float _lifeTime = 5.0f;
        [SerializeField] private float _minRange = 2.0f;
        [SerializeField] private float _maxRange = 2.75f;

        private Vector3[] _points;
        private Vector3 _pointOne;
        private Vector3 _pointTwo;
        private float _birthTime;

        #endregion


        #region UnityMethods

        private void Start()
        {
            CalculatingTheTrajectoryOfMotionByLinearInterpolationOfABezierCurve();
        }

        #endregion


        #region Methods

        private void CalculatingTheTrajectoryOfMotionByLinearInterpolationOfABezierCurve()
        {
            _points = new Vector3[3];
            _points[0] = Position;

            float xMin = -_boundsCheck.CameraWidth + _boundsCheck.Radius;
            float xMax = _boundsCheck.CameraWidth - _boundsCheck.Radius;

            Vector3 vector;
            vector = Vector3.zero;
            vector.x = Random.Range(xMin, xMax);
            vector.y = -_boundsCheck.CameraHeight * Random.Range(_minRange, _maxRange);
            _points[1] = vector;

            vector = Vector3.zero;
            vector.y = Position.y;
            vector.x = Random.Range(xMin, xMax);
            _points[2] = vector;
            _birthTime = Time.time;
        }

        protected override void MoveTheEnemy()
        {
            float u = (Time.time - _birthTime) / _lifeTime;

            if (u > 1)
            {
                Destroy(gameObject);
                return;
            }

            _pointOne = (1 - u) * _points[0] + u * _points[1];
            _pointTwo = (1 - u) * _points[1] + u * _points[2];
            Position = (1 - u) * _pointOne + u * _pointTwo;
        }

        #endregion
    }
}
