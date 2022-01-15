using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ATMRush.PlayerControls 
{
    [CreateAssetMenu(menuName = "ATMRush/Player/Movement Settings")]
    public class PlayerMovementSettings : ScriptableObject
    {
        [SerializeField] private float _swipeSpeed;
        public float SwipeSpeed { get { return _swipeSpeed; } }

        [SerializeField] private float _moveSpeed;
        public float MoveSpeed { get { return _moveSpeed; } }
    }
}
