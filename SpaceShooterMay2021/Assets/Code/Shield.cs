using UnityEngine;


namespace TheRetroCarInSpaceShooter
{
    internal sealed class Shield : MonoBehaviour
    {
        #region Fields

        [SerializeField] private float _rotationPerSecond = 0.1f;
        [SerializeField] private int _levelShown = 0;

        private Material _materialOfTheShield;
        private float _displacementInTheTexture = 0.2f;
        private float _degreeOfRotation = 360.0f;

        #endregion


        #region UnityMethods

        private void Start()
        {
            _materialOfTheShield = GetComponent<Renderer>().material;
        }

        private void Update()
        {
            ShieldFunctions();
        }

        #endregion


        #region Methods

        private void ShieldFunctions()
        {
            int currentLevelOfShield = Mathf.FloorToInt(Hero.SingletonHero.ShieldLevel);

            if (_levelShown != currentLevelOfShield)
            {
                _levelShown = currentLevelOfShield;
                _materialOfTheShield.mainTextureOffset = new Vector2(_displacementInTheTexture * _levelShown, 0.0f);
            }
            float rotationZfField = -(_rotationPerSecond * Time.time * _degreeOfRotation) % _degreeOfRotation;
            transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZfField);
        }

        #endregion
    }
}
