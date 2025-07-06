using System;
using Unity.Behavior;
using UnityEngine;

[Serializable]
[Unity.Properties.GeneratePropertyBag]
[Condition("IsTargetDetected", story: "Checks if [Target] Detected", category: "Conditions",
	id: "c2e2d7174d3408fde520256bb664b998")]
public partial class IsTargetDetectedCondition : Condition
{
	[SerializeReference] public BlackboardVariable<GameObject> Target;

	public override bool IsTrue()
	{
		return Target.Value != null;
	}
}