using System;
using UnityEngine;

namespace Script
{
    public class FloatingText : MonoBehaviour
    {
        private const float DestroyTime = 1f;

        private void Start()
        {
            Destroy(gameObject, DestroyTime);
        }
    }
}