using System.Collections;
using Character;
using GameFramework.AcceptanceTesting;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

namespace Tests.Runtime
{
    public class OriCoreGameAcceptanceTests : CoreGameAcceptanceTests<OriTestSetup>
    {
        private const string K_PLAYER_CHARACTER_NAME = "Ori";

        [UnityTest]
        public IEnumerator Character_moves_to_given_direction()
        {
            yield return Given(Player).is_playing_the_core_game();
            yield return When(Input).is_given();
            yield return Then(Character).moves_to_the_given_direction();
        }
        
        
        
        
        public override IEnumerator is_playing_the_core_game()
        {
            yield return starts_the_core_game();
            yield return is_in_the_tutorial_level();
        }

        private static IEnumerator starts_the_core_game()
        {
            SceneManager.LoadScene("Scenes/TutorialLevel");
            yield return new WaitUntil(() => SceneManager.sceneCount > 0);
        }

        private static IEnumerator is_in_the_tutorial_level()
        {
            yield return new WaitUntil(() => SceneManager.GetActiveScene().name.Contains("TutorialLevel"));
        }

        public override IEnumerator is_given()
        {
            GameObject character = AcceptanceTestUtility.FindOrThrow(K_PLAYER_CHARACTER_NAME);
            
            yield return character;
            
            VirtualInput characterInput = character.GetComponent<CharacterCore>().GetCoreComponent<VirtualInput>();
            characterInput.SetInput(Vector2.right);
        }

        public override IEnumerator moves_to_the_given_direction()
        {
            GameObject character = GameObject.Find(K_PLAYER_CHARACTER_NAME);
            
            yield return character;

            Vector2 currentVelocity = character.GetComponent<CharacterCore>().GetCoreComponent<Movement>()
                .CurrentVelocity;
            float actualDirectionAngle = Vector2.Angle(Vector2.right, currentVelocity);
            Assert.That(actualDirectionAngle, Is.LessThan(5f));
        }
    }
}