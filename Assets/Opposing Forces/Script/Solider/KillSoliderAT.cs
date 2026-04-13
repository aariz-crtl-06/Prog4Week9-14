using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using static Unity.VisualScripting.Member;


namespace NodeCanvas.Tasks.Actions {

	public class KillSoliderAT : ActionTask {

        public AudioSource source;
		public GameObject panel;
        public AudioClip clip;

        //Once player is reached, play the sound and show the panel, emulating the player being elimated
        protected override void OnExecute() {
            panel.SetActive(true);
            if (source != null && clip != null)
                source.PlayOneShot(clip);
            EndAction(true);
        }

		
	}
}