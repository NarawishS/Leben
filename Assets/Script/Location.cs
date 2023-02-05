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
            switch (GameManager.Instance.state)
            {
                case GameState.P1Turn:
                    GameManager.Instance.player1.transform.DOMove(transform.position, 0.5f).SetEase(Ease.InOutQuad);
                    Debug.Log("Do action: Player DOMove");
                    timer.DecreaseTime(2);
                    break;
                case GameState.P2Turn:
                    GameManager.Instance.player2.transform.DOMove(transform.position, 0.5f).SetEase(Ease.InOutQuad);
                    Debug.Log("Do action: Player DOMove");
                    timer.DecreaseTime(2);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}