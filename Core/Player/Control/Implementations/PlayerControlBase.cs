using UnityEngine;
using Services;

namespace Player
{
    public sealed class PlayerControlBase : IPlayerControl
    {
        private float _directionRotateVertical;
        private float _directionRotateHorizontal;
        private float _directionZoom;
        private float _currentSpeed;

        private Vector3 _directionMove;
        private Vector3 _neededPosition;

        private GameObject _playerObject;

        private ConfigPlayerControlEditor _configPlayerControlEditor;


        void IPlayerControl.Initialization(in GameObject playerObject, in ConfigPlayerControlEditor configPlayerControlEditor)
        {
            _configPlayerControlEditor = configPlayerControlEditor;
            _playerObject = playerObject;
        }

        void IPlayerControl.Move()
        {
            if (InputService.AxisKeyLeftShift != 0.0f)
                _currentSpeed = _configPlayerControlEditor.speedFastMove;
            else 
                _currentSpeed = _configPlayerControlEditor.speedMove;


            _directionMove = new Vector3(InputService.AxisVerticalMove * _currentSpeed * Time.deltaTime,
                                                0.0f,
                                                InputService.AxisHorizontalMove * _currentSpeed * Time.deltaTime);

            _playerObject.transform.parent.parent.Translate(_directionMove, Space.Self);
        }

        void IPlayerControl.Rotate()
        {
            _directionRotateVertical += InputService.AxisMouseY * InputService.AxisMouseFireSecond
                                        * _configPlayerControlEditor.speedRotation * Time.deltaTime;

            _directionRotateVertical = Mathf.Clamp(_directionRotateVertical,
                                                   _configPlayerControlEditor.minVerticalAngle,
                                                   _configPlayerControlEditor.maxVerticalAngle);

            _directionRotateHorizontal += InputService.AxisMouseX * InputService.AxisMouseFireSecond
                                          * _configPlayerControlEditor.speedRotation * Time.deltaTime;

            Quaternion targetRotationZ = Quaternion.Euler(0.0f, 0.0f, _playerObject.transform.parent.localRotation.z + _directionRotateVertical);
            Quaternion targetRotationY = Quaternion.Euler(0.0f, _playerObject.transform.parent.parent.localRotation.y + _directionRotateHorizontal, 0.0f);

            _playerObject.transform.parent.localRotation = Quaternion.Lerp(_playerObject.transform.parent.localRotation, targetRotationZ, _configPlayerControlEditor.timeSpeedRotation);
            _playerObject.transform.parent.parent.localRotation = Quaternion.Lerp(_playerObject.transform.parent.parent.localRotation, targetRotationY, _configPlayerControlEditor.timeSpeedRotation);
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