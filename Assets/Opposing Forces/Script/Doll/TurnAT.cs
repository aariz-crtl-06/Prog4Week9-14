using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class TurnAT : ActionTask {

		public BBParameter<float> timer;
		public AudioClip song;

		private AudioSource source;


		
		protected override void OnExecute() {
			//Gather audio, play it, and set the timer
            source = agent.GetComponent<AudioSource>();
            source.PlayOneShot(song);
            timer.value = 5.2f;
		}

	
		protected override void OnUpdate() {
            timer.value-= Time.deltaTime;

            //Once the timer is done, end the task
            if (timer.value <= 0) {
				EndAction(true);
            }
        }
	}
}