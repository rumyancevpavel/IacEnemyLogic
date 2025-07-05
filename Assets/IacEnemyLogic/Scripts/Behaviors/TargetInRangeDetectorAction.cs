using System;
using Unity.Behavior;
using Unity.Properties;
using UnityEngine;
using Action = Unity.Behavior.Action;

namespace IacEnemyLogic.Behaviors
{
	[Serializable]
	[GeneratePropertyBag]
	[NodeDescription("RangeDetector", story: "[Detector] tries to find [Target] within a range", category: "Action",
		id: "8214cca45b30e8658ebddd085ed762b3")]
	public partial class TargetInRangeDetectorAction : Action
	{
		[SerializeReference] public BlackboardVariable<TargetInRangeDetector> Detector;
		[SerializeReference] public BlackboardVariable<GameObject> Target;

		protected override Status OnStart()
		{
			return Status.Running;
		}

		protected override Status OnUpdate()
		{
			if (Detector.Value.DetectTargets(out var target))
				Target.Value = target;
			else
				Target.Value = null;
			return Target.Value == null ? Status.Failure : Status.Success;
		}
	}
}