using UnityEngine;
using Services;

namespace Player
{
    public sealed class PlayerControlObject : IPlayerControl
    {
        private float _directionRotateVertical;
        private float _directionRotateHorizontal;
        private float _directionZoom;

        private Vector3 _neededPosition;

        private GameObject _playerObject;

        private ConfigPlayerControlEditor _configPlayerControlEditor;


        void IPlayerControl.Initialization(in GameObject playerObject, in ConfigPlayerControlEditor configPlayerControlEditor)
        {
            _configPlayerControlEditor = configPlayerControlEditor;
            _playerObject = playerObject;
        }

        void IPlayerControl.Move() {}

        void IPlayerControl.Rotate()
        {
            _directionRotateVertical = Mathf.Clamp(_directionRotateVertical,
                                                   _configPlayerControlEditor.minVerticalAngle,
                                                   _configPlayerControlEditor.maxVerticalAngle);

            _directionRotateVertical += InputService.AxisMouseY
                                        * InputService.AxisMouseFireSecond
                                        * _configPlayerControlEditor.speedRotation
                                        * Time.deltaTime;
            
            _directionRotateHorizontal += InputService.AxisMouseX
                                          * InputService.AxisMouseFireSecond
                                          * _configPlayerControlEditor.speedRotation
                                          * Time.deltaTime;


            Quaternion currentRotation = _playerObject.transform.parent.localRotation;

            Quaternion targetRotation = Quaternion.Euler(_playerObject.transform.parent.localRotation.x,
                                                         _playerObject.transform.parent.localRotation.y + _directionRotateHorizontal,
                                                         _playerObject.transform.parent.localRotation.z + _directionRotateVertical);

            _playerObject.transform.parent.localRotation = Quaternion.Lerp(currentRotation, targetRotation, _configPlayerControlEditor.timeSpeedRotation);
        }

        void IPlayerControl.Zoom()
        {
            _directionZoom = Mathf.SmoothStep(_directionZoom, InputService.AxisScrollWheel * _configPlayerControlEditor.speedZoom, _configPlayerControlEditor.timeSpeedZoom);

            _neededPosition = _playerObject.transform.localPosition + (Vector3.right * _directionZoom);
            _neededPosition.x = Mathf.Clamp(_neededPosition.x, _configPlayerControlEditor.minZoomCameraDistance, _configPlayerControlEditor.maxZoomCameraDistance);

            _playerObject.transform.localPosition = Vector3.Lerp(_playerObject.transform.localPosition, _neededPosition, _configPlayerControlEditor.timeSpeedZoom);
        }
    }
}