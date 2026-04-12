using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
    public class FixComputerAT : ActionTask
    {
        public BBParameter<GameObject> targetComputer;

        protected override void OnExecute()
        {
            if (targetComputer.value == null)
            {
                EndAction(false);
                return;
            }

            Computer comp = targetComputer.value.GetComponent<Computer>();

            if (comp != null)
            {
                comp.FixComputer();
                EndAction(true);
                return;
            }

            EndAction(false);
        }
    }
}