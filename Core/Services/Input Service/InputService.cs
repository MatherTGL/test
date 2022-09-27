using UnityEngine;
using Sirenix.OdinInspector;

namespace Services
{
    [AddComponentMenu("Services/Input Service")]
    [RequireComponent(typeof(TimeAccelerationService))]
    [RequireComponent(typeof(PlayerDataControlService))]
    public sealed class InputService : MonoBehaviour
    {
        #region Variables

        #region Move
        [ShowInInspector, ReadOnly, Sirenix.OdinInspector.Title("Axis", TitleAlignment = TitleAlignments.Centered)]
        [LabelText("Horizontal Move"), Sirenix.OdinInspector.Title("Move")]
        private static float _axisHorizontalMove;
        public static float AxisHorizontalMove => _axisHorizontalMove;

        [ShowInInspector, ReadOnly, LabelText("Vertical Move")]
        private static float _axisVerticalMove;
        public static float AxisVerticalMove => _axisVerticalMove;
        #endregion

        #region Mouse
        [ShowInInspector, ReadOnly, LabelText("Mouse X")]
        [Sirenix.OdinInspector.Title("Mouse")]
        private static float _axisMouseX;
        public static float AxisMouseX => _axisMouseX;

        [ShowInInspector, ReadOnly, LabelText("Mouse Y")]
        private static float _axisMouseY;
        public static float AxisMouseY => _axisMouseY;

        [ShowInInspector, ReadOnly, LabelText("Scroll Wheel")]
        private static float _axisScrollWheel;
        public static float AxisScrollWheel => _axisScrollWheel;

        [ShowInInspector, ReadOnly, LabelText("Scroll Wheel")]
        private static float _axisMouseFireFirst;
        public static float AxisMouseFireFirst => _axisMouseFireFirst;

        [ShowInInspector, ReadOnly, LabelText("Scroll Wheel")]
        private static float _axisMouseFireSecond;
        public static float AxisMouseFireSecond => _axisMouseFireSecond;
        #endregion

        #region Keys
        [ShowInInspector, ReadOnly, LabelText("Key Space")]
        [Sirenix.OdinInspector.Title("Keys")]
        private static float _axisKeySpace;
        public static float AxisKeySpace => _axisKeySpace;

        [ShowInInspector, ReadOnly, LabelText("Key Space")]
        private static float _axisKeyLeftShift;
        public static float AxisKeyLeftShift => _axisKeyLeftShift;

        [ShowInInspector, ReadOnly, LabelText("Key Number 1")]
        private static float _axisKeyNumberFirst;
        public static float AxisKeyNumberFirst => _axisKeyNumberFirst;

        [ShowInInspector, ReadOnly, LabelText("Key Number 2")]
        private static float _axisKeyNumberSecond;
        public static float AxisKeyNumberSecond => _axisKeyNumberSecond;

        [ShowInInspector, ReadOnly, LabelText("Key Number 3")]
        private static float _axisKeyNumberThird;
        public static float AxisKeyNumberThird => _axisKeyNumberThird;
        #endregion

        #endregion


        private void Start() => DontDestroyOnLoad(gameObject.transform.parent);

        private void Update() => DetectInput();

        private void DetectInput()
        {
            _axisHorizontalMove = Input.GetAxis("Horizontal");
            _axisVerticalMove = Input.GetAxis("Vertical");

            _axisMouseX = Input.GetAxis("Mouse X");
            _axisMouseY = Input.GetAxis("Mouse Y");
            _axisScrollWheel = Mathf.Clamp(Input.GetAxisRaw("Mouse ScrollWheel"), -2.0f, 2.0f);

            _axisMouseFireFirst = Input.GetAxisRaw("Fire1");
            _axisMouseFireSecond = Input.GetAxisRaw("Fire2");

            _axisKeySpace = Input.GetAxisRaw("Space");
            _axisKeyLeftShift = Input.GetAxisRaw("LShift");
            
            _axisKeyNumberFirst = Input.GetAxisRaw("Number1");
            _axisKeyNumberSecond = Input.GetAxisRaw("Number2");
            _axisKeyNumberThird = Input.GetAxisRaw("Number3");
        }
    }
}