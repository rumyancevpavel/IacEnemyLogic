using UnityEngine;

namespace IacEnemyLogic
{
	public class DamageMaker : MonoBehaviour
	{
		#region Editor

		[SerializeField] private TargetInRangeDetector _targetInRangeDetector;
		
		#endregion

		#region Methods
		
		public void PerformHit()
		{
			if (_targetInRangeDetector.LastTarget == null)
			{
				return;
			}
			var target = _targetInRangeDetector.LastTarget;
			var handler = target.GetComponent<DamageReceiver>();
			if (handler != null) handler.Damage();
		}
		
		#endregion
	}
}