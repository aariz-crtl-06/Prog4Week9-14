using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class TurnAT : ActionTask {

		public BBParameter<float> timer;
		public AudioClip song;

		private AudioSource source;


		
		protected override void OnExecute() {
            source = agent.GetComponent<AudioSource>();
            source.PlayOneShot(song);
            timer.value = 5f;
		}

	
		protected override void OnUpdate() {
            timer.value-= Time.deltaTime;

			if (timer.value <= 0) {
				EndAction(true);
            }
        }
	}
}