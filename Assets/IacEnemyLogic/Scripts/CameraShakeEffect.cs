using System.Collections;
using UnityEngine;

namespace IacEnemyLogic
{
	public class CameraShakeEffect : MonoBehaviour
	{
		#region Editor

		[SerializeField] private float _shakeDuration = 0.5f;
		[SerializeField] private float _shakeAmplitude = 0.5f;
		[SerializeField] private float _shakeFrequency = 1f;

		#endregion

		#region Fields

		private Vector3 _originalPosition;
		private float _shakeTime;
		private bool _isShaking;

		#endregion

		#region Methods

		private void Awake()
		{
			_originalPosition = transform.localPosition;
		}

		public void StartShake()
		{
			if (!_isShaking)
				StartCoroutine(ShakeCoroutine());
			else
				_shakeTime = 0;
		}

		private IEnumerator ShakeCoroutine()
		{
			_isShaking = true;
			_shakeTime = 0;
			while (_shakeTime < _shakeDuration)
			{
				_shakeTime += Time.deltaTime;
				var progress = _shakeTime / _shakeDuration;
				var currentAmplitude = _shakeAmplitude * (1f - progress);
				var offsetX = (Mathf.PerlinNoise(Time.time * _shakeFrequency, 0) * 2 - 1) * currentAmplitude;
				var offsetY = (Mathf.PerlinNoise(0, Time.time * _shakeFrequency) * 2 - 1) * currentAmplitude;
				transform.localPosition = _originalPosition + new Vector3(offsetX, offsetY, 0);
				yield return null;
			}
			transform.localPosition = _originalPosition;
			_isShaking = false;
		}

		#endregion
	}
}