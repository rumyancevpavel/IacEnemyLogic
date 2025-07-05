using UnityEngine;

namespace IacEnemyLogic
{
	public class TargetInRangeDetector : MonoBehaviour
	{
		#region Editor

		[SerializeField] private float _detectionRadius = 10f;
		[SerializeField] private LayerMask _targetMaskMask;
		[SerializeField] private bool _showDebugVisuals = true;

		#endregion

		#region Properties

		public GameObject LastTarget { get; private set; }

		#endregion

		#region Methods

		public bool DetectTargets(out GameObject detectedTarget)
		{
			var colliders = Physics.OverlapSphere(transform.position, _detectionRadius, _targetMaskMask);
			if (colliders.Length > 0)
			{
				LastTarget = colliders[0].gameObject;
			}
			detectedTarget = LastTarget;
			return LastTarget != null;
		}

		private void OnDrawGizmos()
		{
			if (!_showDebugVisuals || enabled == false) return;
			Gizmos.color = LastTarget ? Color.green : Color.yellow;
			Gizmos.DrawWireSphere(transform.position, _detectionRadius);
		}
	
		#endregion
	}
}