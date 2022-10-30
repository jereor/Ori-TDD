using Components;
using NUnit.Framework;
using UnityEngine;

namespace Tests.Editor
{
    public class MovementUnitTests
    {
        public class Move
        {
            private static readonly Vector2[] HorizontalVectors = {Vector2.right, Vector2.left};

            [Test]
            public void zero_vector_sets_current_velocity_zero_to_zero()
            {
                Movement movement = Movement.Create();

                movement.Move(Vector2.zero);

                Assert.That(movement.CurrentVelocity, Is.EqualTo(Vector2.zero));
            }
            
            [Test]
            public void horizontal_vector_sets_current_velocity_zero_to_horizontal_velocity([ValueSource(nameof(HorizontalVectors))] Vector2 vector)
            {
                Movement movement = Movement.Create();

                movement.Move(Vector2.right);

                Assert.That(movement.CurrentVelocity, Is.Not.EqualTo(Vector2.zero));
            }
            
        }
    }
}
