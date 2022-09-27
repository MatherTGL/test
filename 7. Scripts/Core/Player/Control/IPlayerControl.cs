using UnityEngine;

namespace Player
{
    public interface IPlayerControl
    {
        void Initialization(in GameObject playerObject, in ConfigPlayerControlEditor configPlayerControlEditor);
        void Move();
        void Rotate();
        void Zoom();
    }
}