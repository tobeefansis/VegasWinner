using System;
using System.Collections;
using System.Linq;
using DG.Tweening;
using PlayerWallet;
using UnityEngine;

namespace Wheel
{
    public class WheelPresenter
    {
        private readonly WheelModel _model;
        private readonly WheelView _view;
        public event Action<Bubble> OnWinSpin;
        public WheelPresenter(WheelModel model, WheelView view)
        {
            _model = model;
            _view = view;
            view.OnSpin += Spin;
        }

        private void Spin()
        {
            if (_model.IsSpinning)return;
            BeginSpin();
            var randomIndex = UnityEngine.Random.Range(0, _model.Bubbles.Count);
            var randomBubble = _model.Bubbles.ElementAt(randomIndex).Value;
            float additionRotation = UnityEngine.Random.Range(4, 40);
            float rotation = 360 * _model.SpinCount+ randomIndex*45;
            _view.wheel.rotation =
                Quaternion.Euler(new Vector3(0,0,rotation+additionRotation));
            _view.StartCoroutine(Spinning(rotation+additionRotation,4,randomBubble));
        }

        private void BeginSpin()
        {
            _model.IsSpinning = true;
        }  
        private void EndSpin(Bubble endBubble)
        {
            _model.IsSpinning = false;
            if (endBubble.type==Bubble.Type.Empty)return;
            OnWinSpin?.Invoke(endBubble);
        }
        
        private IEnumerator Spinning(float rotationValue, float timeToRotation,Bubble endBubble )
        {
            float time = 0;
            var start = _view.wheel.rotation.eulerAngles;
            var end = new Vector3(0, 0, rotationValue);
            while (time<=timeToRotation)
            {
                yield return null;
                time += Time.deltaTime;
                var normalized = time / timeToRotation;

                _view.wheel.rotation =
                    Quaternion.Euler(Vector3.Lerp(
                        start,
                        end,
                        _model.curve.Evaluate(normalized)
                        ));
            }
            EndSpin(endBubble);
        }

        private void Refresh()
        {
            _view.Set(_model.Bubbles);
        }
        public void Init()
        {
            Refresh();
        }
    }
}