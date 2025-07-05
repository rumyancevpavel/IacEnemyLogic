using UnityEngine;

namespace IacEnemyLogic
{
	public class DamageReceiver : MonoBehaviour
	{
		#region Statics
		private static int GetHitAnimationParam = Animator.StringToHash("GetHit");
		#endregion

		#region Editor
		
		[SerializeField] private Animator _animator;
		[SerializeField] private CameraShakeEffect _cameraShakeEffect;
		[SerializeField] private PlayerMovement _playerMovement;
		[SerializeField] private ParticleSystem _impactParticles;

		#endregion
		
		#region Methods
		
		public void Damage()
		{
			if (_animator != null)
			{
				if (_playerMovement != null) _playerMovement.StopMovement();
				PlayCameraShake();
				PlayParticles();
				_animator.SetTrigger(GetHitAnimationParam);
			}
		}

		private void PlayParticles()
		{
			if (_impactParticles != null) _impactParticles.Play();
		}

		private void PlayCameraShake()
		{
			if (_cameraShakeEffect != null) _cameraShakeEffect.StartShake();
		}
		
		#endregion
	}
}