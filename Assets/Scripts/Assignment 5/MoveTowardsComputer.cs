using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
    [Category("Movement/Direct")]
    [Description("Moves the agent towards target per frame without pathfinding, safely handling null target")]
    public class MoveTowardsComputer : ActionTask<Transform>
    {
        public BBParameter<GameObject> target;
        public BBParameter<float> speed = 2f;
        public BBParameter<float> stopDistance = 0.1f;
        public bool waitActionFinish = true;

        protected override void OnUpdate()
        {
            if (target.value == null)
            {
                EndAction(false);
                return;
            }

            Vector3 targetPos = target.value.transform.position;

            if ((agent.position - targetPos).magnitude <= stopDistance.value)
            {
                EndAction(true);
                return;
            }

            agent.position = Vector3.MoveTowards(agent.position, targetPos, speed.value * Time.deltaTime);

            if (!waitActionFinish)
            {
                EndAction(true);
            }
        }
    }
}