using Godot;
using System;

namespace ARPG.Enemies
{
    internal class EnemyCharacterStates
    {
        private float _speed;
        private Vector2 _startPosition;
        private Vector2 _endPosition;
        private Vector2 _moveDirection;
        private float _limit;

        public Vector2 Velocity { get { return _speed * _moveDirection.Normalized(); } }
        public Vector2 MovementDirection { get { return _moveDirection.Normalized(); } }


        public EnemyCharacterStates(
            Vector2 startPosition,
            Vector2 endPosition,
            float speed = 1.0f,
            float limit = 0.5f
        )
        {
            _startPosition = startPosition;
            _endPosition = endPosition;
            _speed = speed;
            _limit = limit;
        }

        private void ChangeDirection()
        {
            (_startPosition, _endPosition) = (_endPosition, _startPosition);
        }


        public void UpdateMovementStates(Vector2 position)
        {
            _moveDirection = (_endPosition - position);
            if(_moveDirection.Length() < _limit)
            {
                ChangeDirection();
            }
        }

    }
}
