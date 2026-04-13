using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
    public class DollCoolDownAT : ActionTask
    {
        public BBParameter<Transform> dollRot;
        public BBParameter<float> coolTimer;

        public float rotationSpeed = 180f;
        public float returnRotation = 180f;
        public float coolDuration = 1f;

        private float rotatedAmount = 0f;
        private bool finishedTurningBack = false;

        protected override void OnExecute()
        {
            //Reset variables for the cooldown phase
            rotatedAmount = 0f;
            finishedTurningBack = false;
            coolTimer.value = coolDuration;
        }

        protected override void OnUpdate()
        {
            //safety check
            if (dollRot.value == null)
            {
                EndAction(false);
                return;
            }

            //rotate back
            if (!finishedTurningBack)
            {
                float step = rotationSpeed * Time.deltaTime;

                if (rotatedAmount + step > returnRotation)
                {
                    step = returnRotation - rotatedAmount;
                }

                //negative step so it turns back the other way
                dollRot.value.Rotate(0f, -step, 0f);
                rotatedAmount += step;

                if (rotatedAmount >= returnRotation)
                {
                    finishedTurningBack = true;
                }

                return;
            }

            //cooldown while staying still
            if (coolTimer.value > 0f)
            {
                coolTimer.value -= Time.deltaTime;
            }

            if (coolTimer.value <= 0f)
            {
                EndAction(true);
            }
        }
    }
}