using IacEnemyLogic;
using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable]
[GeneratePropertyBag]
[NodeDescription("DetectTargetInRange", story: "Detects [Target] in range using [DetectorScript]",
	category: "Action/Detect", id: "8638e6205c65057b55a07fe049b88d8d")]
public partial class DetectTargetInRangeAction : Action
{
	[SerializeReference] public BlackboardVariable<GameObject> Target;
	[SerializeReference] public BlackboardVariable<TargetInRangeDetector> DetectorScript;

	protected override Status OnUpdate()
	{
		Target.Value = DetectorScript.Value.DetectTarget();
		Debug.Log($"DetectTargetInRangeAction: {Target.Value}");
		return Target.Value == null ? Status.Failure : Status.Success;
	}
}