using System;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

namespace Script
{
    public class Location : MonoBehaviour
    {
        public Timer timer;
        private void OnMouseDown()
        {
            Player.Instance.transform.DOMove(transform.position, 0.5f).SetEase(Ease.InOutQuad);
            timer.DecreaseTime(2);
        }
    }
}