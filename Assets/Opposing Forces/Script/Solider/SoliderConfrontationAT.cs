using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class SoliderConfrontationAT : ActionTask {

        public AudioSource source1;
        public AudioSource source2;
        public AudioSource source3;

        public AudioClip clip1;
        public AudioClip clip2;
        public AudioClip clip3;
        protected override void OnExecute()
        {
            if (source1 != null && clip1 != null)
                source1.PlayOneShot(clip1);

            if (source2 != null && clip2 != null)
                source2.PlayOneShot(clip2);

            if (source3 != null && clip3 != null)
                source3.PlayOneShot(clip3);

            EndAction(true);
        }
    }
}