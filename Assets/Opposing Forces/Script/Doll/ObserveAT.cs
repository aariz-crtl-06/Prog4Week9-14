using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
    public class ObserveAT : ActionTask
    {
        public BBParameter<Transform> playerPos;
        public BBParameter<Transform> dollRot;
        public BBParameter<float> observeTimer;

        private Vector3 lastPlayPos = Vector3.zero;

        public float rotationSpeed = 540f;
        public float targetRotation = 180f;
        public float observeDuration = 4f;

        private float rotatedAmount = 0f;
        private bool isObserving = false;

        protected override void OnExecute()
        {
            if (playerPos.value != null)
            {
                lastPlayPos = playerPos.value.position;
            }

            rotatedAmount = 0f;
            isObserving = false;
            observeTimer.value = observeDuration;
        }

        protected override void OnUpdate()
        {
            if (dollRot.value == null)
            {
                EndAction(false);
                return;
            }

            // Phase 1: rotate until target rotation is reached
            if (!isObserving)
            {
                float step = rotationSpeed * Time.deltaTime;

                // prevent overshooting
                if (rotatedAmount + step > targetRotation)
                {
                    step = targetRotation - rotatedAmount;
                }

                dollRot.value.Rotate(0f, step, 0f);
                rotatedAmount += step;

                if (rotatedAmount >= targetRotation)
                {
                    isObserving = true;
                    observeTimer.value = observeDuration;
                }

                return;
            }

            // Phase 2: stay still and wait
            if (observeTimer.value > 0f)
            {
                observeTimer.value -= Time.deltaTime;
            }

            if (observeTimer.value <= 0f)
            {
                EndAction(true);
            }
        }
    }
}