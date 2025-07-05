using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

namespace IacEnemyLogic
{
	public class PlayerMovement : MonoBehaviour
	{
		#region Consts

		private const int RAYCAST_DISTANCE = 1000;

		#endregion

		#region Statics

		private static int SpeedMagnitudeParam = Animator.StringToHash("SpeedMagnitude");

		#endregion

		#region Editor

		[SerializeField] private InputActionReference _mouseClickAction;
		[SerializeField] private InputActionReference _mousePositionAction;
		[SerializeField] private LayerMask _groundLayer;
		[SerializeField] private NavMeshAgent _navMeshAgent;
		[SerializeField] private Animator _animator;
		[SerializeField] private Camera _rayCastCamera;

		#endregion

		#region Methods

		private void OnEnable()
		{
			_mouseClickAction.action.performed += OnMouseClick;
		}

		private void OnDisable()
		{
			_mouseClickAction.action.performed -= OnMouseClick;
		}

		private void OnMouseClick(InputAction.CallbackContext context)
		{
			var mousePosition = _mousePositionAction.action.ReadValue<Vector2>();
			var ray = _rayCastCamera.ScreenPointToRay(mousePosition);
			if (Physics.Raycast(ray, out var hit, RAYCAST_DISTANCE, _groundLayer)) _navMeshAgent.SetDestination(hit.point);
		}

		private void Update()
		{
			_animator.SetFloat(SpeedMagnitudeParam, _navMeshAgent.velocity.magnitude);
		}

		public void StopMovement()
		{
			_navMeshAgent.isStopped = true;
			_navMeshAgent.ResetPath();
			_navMeshAgent.velocity = Vector3.zero;
		}

		private void FootStep()
		{
		}
		
		#endregion
	}
}