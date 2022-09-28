using UnityEngine;
using Sirenix.OdinInspector;
using Player;
using System.Collections;

namespace Services
{
    public sealed class PlayerDataControlService : MonoBehaviour
    {
        [SerializeField]
        private IConfigDataPlayer _IConfigDataPlayer;


        private void Awake()
        {
            _IConfigDataPlayer = new ConfigDataPlayerEditor();
            Debug.Log(_IConfigDataPlayer);
            _IConfigDataPlayer.Initialization(_IConfigDataPlayer);
        }

        private void Start() => StartCoroutine(TimeControlCoroutine());

        private IEnumerator TimeControlCoroutine()
        {
            while (true)
            {
                yield return new WaitForSecondsRealtime(1);
                _IConfigDataPlayer.RecalculateTime();
            }
        }
    }
}