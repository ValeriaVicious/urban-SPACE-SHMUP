using UnityEngine;


namespace TheRetroCarInSpaceShooter
{
    /// <summary>
    /// Данный код работает только при режиме Ортографии MainCamera.
    /// </summary>
    internal sealed class BoundsCheck : MonoBehaviour
    {
        #region Fields

        [SerializeField] private float _radius = 1.0f;
        [SerializeField] private bool _isKeepOnScreen = true;

        private readonly float _xBoundSize = 2.0f;
        private readonly float _yBoundSize = 2.0f;
        private readonly float _zBoundSize = 0.1f;

        #endregion


        #region Properties

        public float CameraWidth { get; internal set; }
        public float CameraHeight { get; internal set; }
        public float Radius { get; internal set; }
        public bool IsOnScreen { get; internal set; }
        public bool IsOffRight { get; internal set; }
        public bool IsOffLeft { get; internal set; }
        public bool IsOffUp { get; internal set; }
        public bool IsOffDown { get; internal set; }

        #endregion


        #region UnityMethods

        private void Awake()
        {
            CameraHeight = Camera.main.orthographicSize;
            CameraWidth = CameraHeight * Camera.main.aspect;
        }

        private void LateUpdate()
        {
            ObjectPositionCalculation();
        }

        private void OnDrawGizmos()
        {
            if (!Application.isPlaying)
            {
                return;
            }

            Vector3 boundSize = new Vector3(CameraWidth * _xBoundSize, CameraHeight * _yBoundSize, _zBoundSize);
            Gizmos.DrawWireCube(Vector3.zero, boundSize);
        }

        #endregion


        #region Methods

        private void ObjectPositionCalculation()
        {
            Vector3 position = transform.position;
            IsOnScreen = true;
            IsOffRight = IsOffLeft = IsOffUp = IsOffDown = false;

            if (position.x > CameraWidth - _radius)
            {
                position.x = CameraWidth - _radius;
                IsOffRight = true;
            }

            if (position.x < -CameraWidth + _radius)
            {
                position.x = -CameraWidth + _radius;
                IsOffLeft = true;
            }

            if (position.y > CameraHeight - _radius)
            {
                position.y = CameraHeight - _radius;
                IsOffUp = true;
            }

            if (position.y < -CameraHeight + _radius)
            {
                position.y = -CameraHeight + _radius;
                IsOffDown = true;
            }

            IsOnScreen = !(IsOffRight || IsOffLeft || IsOffUp || IsOffDown);

            if (_isKeepOnScreen && !IsOnScreen)
            {
                transform.position = position;
                IsOnScreen = true;
                IsOffRight = IsOffLeft = IsOffUp = IsOffDown = false;
            }
        }

        #endregion
    }
}
