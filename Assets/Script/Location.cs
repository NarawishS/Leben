using System;
using UnityEngine;
using DG.Tweening;

namespace Script
{
    public class Location : MonoBehaviour
    {
        private void OnMouseDown()
        {
            Player.Instance.transform.DOMove(transform.position, 0.5f).SetEase(Ease.InOutQuad);
        }
    }
}