using UnityEngine;


namespace TheRetroCarInSpaceShooter
{
    internal sealed class BackgroundScroller : MonoBehaviour
    {
        #region Fields

        [SerializeField] private float _speedOfScroll;
        private readonly float _endPoint = 30.0f;
        private Vector3 _startPosition;

        #endregion


        #region UnityMethods

        private void Start()
        {
            _startPosition = transform.position;
        }

        private void Update()
        {
            Scroll();
        }

        #endregion


        #region Methods

        private void Scroll()
        {
            var moveTheBackground = Mathf.Repeat(Time.time * _speedOfScroll, _endPoint);
            transform.position = _startPosition + new Vector3(moveTheBackground,0.0f, 0.0f);
        }

        #endregion
    }
}