using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
    public class SoliderObserveAT : ActionTask
    {
        public Blackboard targetBlackboard;
        public AudioClip song;

        private AudioSource source;

        private int lastStrikePlayed = 0;

        protected override void OnExecute()
        {
            source = agent.GetComponent<AudioSource>();
            lastStrikePlayed = 0;
        }

        protected override void OnUpdate()
        {
            if (targetBlackboard == null)
            {
                EndAction(false);
                return;
            }

            float movements = targetBlackboard.GetVariableValue<float>("movements");

            // Strike 1
            if (movements >= 1f && lastStrikePlayed < 1)
            {
                Debug.Log("Strike 1");
                source.PlayOneShot(song);
                lastStrikePlayed = 1;
            }

            // Strike 2
            if (movements >= 2f && lastStrikePlayed < 2)
            {
                Debug.Log("Strike 2");
                source.PlayOneShot(song);
                lastStrikePlayed = 2;
            }

            // Strike 3
            if (movements >= 3f && lastStrikePlayed < 3)
            {
                Debug.Log("Strike 3");
                source.PlayOneShot(song);
                lastStrikePlayed = 3;

                EndAction(true);
            }
        }
    }
}