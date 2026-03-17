using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions
{

	public class FindClosestTargetAT : ActionTask
	{

		public BBParameter<Collider[]> targetsNearby;
		public BBParameter<int> numOfTargets;
		public BBParameter<Transform> target;

		protected override void OnExecute()
		{
			Transform closestTarget = null;
			float distanceToBeat = float.MaxValue;

			for (int i = 0; i < numOfTargets.value; i++)
			{

				Transform currentTarget = targetsNearby.value[i].transform;

				float distanceToTarget = Vector3.Distance(agent.transform.position, currentTarget.position);
				if (distanceToTarget < distanceToBeat)
				{
					distanceToBeat = distanceToTarget;
					closestTarget = currentTarget;
				}

			}
			target.value = closestTarget;
			EndAction(true);

		}
	}
}