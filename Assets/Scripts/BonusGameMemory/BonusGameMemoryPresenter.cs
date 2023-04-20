using System;
using System.Collections;
using BonusSystem;
using PlayerWallet;
using UnityEngine;
using Random = UnityEngine.Random;

namespace BonusGameMemory
{
    public class BonusGameMemoryPresenter
    {
        private readonly BonusGameMemoryModel _bonusGameMemoryModel;
        private readonly BonusModel _bonusModel;
        private readonly BonusGameMemoryView _view;
        private Coroutine _restartingCoroutine;
        private Coroutine _timerCoroutine;

        public BonusGameMemoryPresenter(BonusGameMemoryModel bonusGameMemoryModel, BonusModel bonusModel,
            BonusGameMemoryView view)
        {
            _bonusGameMemoryModel = bonusGameMemoryModel;
            _bonusModel = bonusModel;
            _view = view;

            foreach (var holder in _view.holders)
            {
                holder.OnClick += HolderOnClick;
            }

            _view.OnRestart += ViewOnRestart;
            Restart();
        }

        private void ViewOnRestart()
        {
            _restartingCoroutine = _view.StartCoroutine(Restarting());
        }

        private void HolderOnClick(BonusGameMemoryHolderView holder)
        {
            if (_bonusGameMemoryModel.gameState == BonusGameMemoryModel.State.Close) return;
            if(holder.isOpen) return;
            
            holder.SetOpen();
            if (_bonusGameMemoryModel.selectType == holder.bubbleType)
            {
                _bonusGameMemoryModel.openCount++;
                if (_bonusGameMemoryModel.openCount == _bonusGameMemoryModel.maxOpenCount)
                {
                    Win();
                }
            }
            else
            {
                Lose();
            }
        }

        private void Win()
        {
            _bonusModel.BonusSpinCount += _bonusGameMemoryModel.spinCount;
            _bonusModel.BonusMaxSpinCount += _bonusGameMemoryModel.spinCount;
            _bonusModel.Change();
            Stop();
            _view.winTitle.SetActive(true);
        }

        private void Lose()
        {
            Stop();
            _view.loseTitle.SetActive(true);
        }

        private void Stop()
        {
            _view.selectBubbleText.text = "";
            _view.timerText.text = "";
            _view.buttonObject.SetActive(true);
            if (_restartingCoroutine != null)
            {
                _view.StopCoroutine(_restartingCoroutine);
            }

            if (_timerCoroutine != null)
            {
                _view.StopCoroutine(_timerCoroutine);
            }

            _bonusGameMemoryModel.gameState = BonusGameMemoryModel.State.Close;
        }

        private IEnumerator Restarting()
        {
            _view.buttonObject.SetActive(false);
            Restart();
            Show();
            _bonusGameMemoryModel.gameState = BonusGameMemoryModel.State.View;
            _timerCoroutine = _view.StartCoroutine(Timer(_bonusGameMemoryModel.timeToView));
            yield return _timerCoroutine;

            Hide();

            _bonusGameMemoryModel.gameState = BonusGameMemoryModel.State.Opening;
            _timerCoroutine = _view.StartCoroutine(Timer(_bonusGameMemoryModel.timeToOpen));
            yield return _timerCoroutine;
            Show();
            _view.buttonObject.SetActive(true);
            _bonusGameMemoryModel.gameState = BonusGameMemoryModel.State.Close;
        }

        private IEnumerator Timer(float timeWait)
        {
            var time = timeWait;
            while (time > 0)
            {
                time -= Time.deltaTime;
                _view.timerText.text = $"{(int) time}";
                yield return null;
            }
        }

        private void Show()
        {
            foreach (var holder in _view.holders)
            {
                holder.SetOpen();
            }
        }

        private void Hide()
        {
            foreach (var holder in _view.holders)
            {
                holder.SetClose();
            }
        }

        private void Restart()
        {
            _bonusGameMemoryModel.selectType = (Bubble.Type) Random.Range(0, 7);
            var color = _bonusGameMemoryModel.selectType switch
            {
                Bubble.Type.Yellow => "FEE052",
                Bubble.Type.Aqua => "31E3FD",
                Bubble.Type.Purple => "E958D8",
                Bubble.Type.Green => "3FC425",
                Bubble.Type.Blue => "607BFD",
                Bubble.Type.Orange => "FE9D2F",
                Bubble.Type.Red => "FE5657",
                _ => ""
            };

            _view.selectBubbleText.text =
                $" open all <color=#{color}>{_bonusGameMemoryModel.selectType}</color> balls ";
            _bonusGameMemoryModel.openCount = 0;
            _bonusGameMemoryModel.maxOpenCount = 0;
            _view.loseTitle.SetActive(false);
            _view.winTitle.SetActive(false);
            foreach (var holder in _view.holders)
            {
                var type = (Bubble.Type) Random.Range(0, 7);
                holder.SetType(type);
                if (type == _bonusGameMemoryModel.selectType)
                {
                    _bonusGameMemoryModel.maxOpenCount++;
                }
            }
        }
    }
}