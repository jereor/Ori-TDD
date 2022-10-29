using UnityEngine;

namespace Character
{
    public class Movement
    {
        public Vector2 CurrentVelocity { get; private set; }

        public static Movement Create()
        {
            return new Movement();
        }

        public void Move(Vector2 direction)
        {
            CurrentVelocity += direction;
        }
    }
}