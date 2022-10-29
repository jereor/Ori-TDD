using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameFramework.AcceptanceTesting
{
    public static class AcceptanceTestUtility
    {
        public static GameObject FindOrThrow(string gameObjectName)
        {
            GameObject gameObject = GameObject.Find(gameObjectName);

            if (gameObject == null)
            {
                throw new NullReferenceException($"GameObject with name {gameObjectName} was not found from {SceneManager.GetActiveScene().name} and method {nameof(FindOrThrow)} threw an exception.");
            }

            return gameObject;
        }
    }
}