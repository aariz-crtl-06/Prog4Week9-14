using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Conditions
{

	public class ScanForTargetsCT : ConditionTask
	{

		public BBParameter<Collider[]> targets;
		public BBParameter<float> scanRadius;
		public BBParameter<LayerMask> scanLayers;

		protected override bool OnCheck()
		{
			int numberOfTargets = Physics.OverlapSphereNonAlloc(agent.transform.position, scanRadius.value, targets.value, scanLayers.value);

			if (numberOfTargets > 0)
			{
				return true;
			}

			else
			{
				return false;
			}
		}
	}
}