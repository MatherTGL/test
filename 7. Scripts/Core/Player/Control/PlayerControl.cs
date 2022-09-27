using UnityEngine;
using Sirenix.OdinInspector;

namespace Player
{
    [RequireComponent(typeof(RaycastCameraCenter))]
    public sealed class PlayerControl : MonoBehaviour
    {
        [SerializeField, BoxGroup("Parameters", false), LabelText("Config Control"), Required]
        private ConfigPlayerControlEditor _configPlayerControlEditor;


        private void Awake()
        {
            if (_configPlayerControlEditor.typeMovement == ConfigPlayerControlEditor.TypeMovement.Object)
                _configPlayerControlEditor.IplayerControl = new PlayerControlObject();
                
            else if (_configPlayerControlEditor.typeMovement == ConfigPlayerControlEditor.TypeMovement.Base)
                _configPlayerControlEditor.IplayerControl = new PlayerControlBase();
        }

        private void Start()
        {
            _configPlayerControlEditor.IplayerControl.Initialization(gameObject, _configPlayerControlEditor);
        }

        private void FixedUpdate()
        {
            _configPlayerControlEditor.IplayerControl.Move();
            _configPlayerControlEditor.IplayerControl.Rotate();
            _configPlayerControlEditor.IplayerControl.Zoom();
        }
    }
}