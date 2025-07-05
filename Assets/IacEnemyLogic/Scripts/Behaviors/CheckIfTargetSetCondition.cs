using System;
using Unity.Behavior;
using UnityEngine;

namespace IacEnemyLogic.Behaviors
{
	[Serializable]
	[Unity.Properties.GeneratePropertyBag]
	[Condition("CheckIfTargetSet", story: "Checks if [Target] set", category: "Conditions",
		id: "9392165f3be654b5bd0d5a8a9cb36fac")]
	public partial class CheckIfTargetSetCondition : Condition
	{
		[SerializeReference] public BlackboardVariable<GameObject> Target;

		public override bool IsTrue()
		{
			return Target.Value != null;
		}
	}
}