using UnityEngine;
using Sirenix.OdinInspector;

namespace Player
{
    [CreateAssetMenu(fileName = "PlayerControlConfig", menuName = "Config/Player/Control/Create Config", order = 51)]
    public sealed class ConfigPlayerControlEditor : ScriptableObject
    {
        [EnumToggleButtons]
        public enum TypeMovement { Object, Space, Base }

        [BoxGroup("Parameters", false)]
        public TypeMovement typeMovement;

        [BoxGroup("Parameters", false)]
        public float speedMove;

        [BoxGroup("Parameters", false)]
        public float speedFastMove;

        [BoxGroup("Parameters", false)]
        public float speedRotation;

        [BoxGroup("Parameters", false)]
        public float speedZoom;

        [BoxGroup("Parameters", false)]
        public float minVerticalAngle = -60.0f;

        [BoxGroup("Parameters", false)]
        public float maxVerticalAngle = 70.0f;

        [BoxGroup("Parameters", false)]
        public float timeSpeedRotation = 0.1f;

        [BoxGroup("Parameters", false)]
        public float timeSpeedZoom = 0.1f;

        [BoxGroup("Parameters", false)]
        public float minZoomCameraDistance;

        [BoxGroup("Parameters", false)]
        public float maxZoomCameraDistance;

        public IPlayerControl IplayerControl;
    }
}