
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
        public BBParameter<bool> isObserving;
        public BBParameter<float> movements;

        private Vector3 lastPlayPos = Vector3.zero;

        public float rotationSpeed = 540f;
        public float targetRotation = 180f;
        public float observeDuration = 4f;
        public float moveThreshold = 0.05f;

        private float rotatedAmount = 0f;
        private bool movementAlreadyCounted = false;

        protected override void OnExecute()
        {
            //reset variables for the observe phase
            rotatedAmount = 0f;
            isObserving.value = false;
            observeTimer.value = observeDuration;
            movementAlreadyCounted = false;
        }

        protected override void OnUpdate()
        {
            //Safety check
            if (dollRot.value == null || playerPos.value == null)
            {
                EndAction(false);
                return;
            }

            // Rotate until target rotation is reached if not obsreving yet
            if (!isObserving.value)
            {
                float step = rotationSpeed * Time.deltaTime;

                if (rotatedAmount + step > targetRotation)
                {
                    step = targetRotation - rotatedAmount;
                }

                dollRot.value.Rotate(0f, step, 0f);
                rotatedAmount += step;

                //If the rotation is at the target, start observing
                if (rotatedAmount >= targetRotation)
                {
                    isObserving.value = true;
                    observeTimer.value = observeDuration;
                    lastPlayPos = playerPos.value.position;
                    movementAlreadyCounted = false;
                }

                return;
            }

            // Observe phase
            observeTimer.value -= Time.deltaTime;

            Vector3 currentPos = playerPos.value.position;
            Vector3 storedPos = lastPlayPos;

            currentPos.y = 0f;
            storedPos.y = 0f;

            //If a movement hasn't been counted yet, and the player has moved more than the threshold, count a movement
            if (!movementAlreadyCounted && Vector3.Distance(storedPos, currentPos) > moveThreshold)
            {
                movements.value += 1f;
                movementAlreadyCounted = true;
            }

            //Once observing timer is done, end the task
            if (observeTimer.value <= 0f)
            {
                EndAction(true);
            }
        }

        //Stops observing at stop so it doesn't count any more movements
        protected override void OnStop()
        {
            isObserving.value = false;
        }
    }
}