using UnityEngine;


namespace TheRetroCarInSpaceShooter
{
    internal sealed class Projectile : MonoBehaviour
    {
        #region Fields

        private BoundsCheck _boundsCheck;

        #endregion


        #region UnityMethods

        private void Awake()
        {
            _boundsCheck = GetComponent<BoundsCheck>();
        }

        private void Update()
        {
            CheckTheBoundsOffUp();
        }

        #endregion


        #region Methods

        private void CheckTheBoundsOffUp()
        {
            if (_boundsCheck.IsOffUp)
            {
                Destroy(gameObject);
            }
        }

        #endregion
    }
}