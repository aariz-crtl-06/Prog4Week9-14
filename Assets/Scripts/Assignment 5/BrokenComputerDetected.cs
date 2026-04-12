using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Conditions
{

    public class BrokenComputerDetected : ConditionTask
    {

        public BBParameter<GameObject> foundComputer;
        public BBParameter<float> scanRadius = 10f;
        public BBParameter<LayerMask> scanLayers;

        private Collider[] results = new Collider[20];

        protected override bool OnCheck()
        {
            int count = Physics.OverlapSphereNonAlloc(
                agent.transform.position,
                scanRadius.value,
                results,
                scanLayers.value
            );

            for (int i = 0; i < count; i++)
            {
                Computer computer = results[i].GetComponent<Computer>();

                if (computer != null && computer.isBroken)
                {
                    foundComputer.value = computer.gameObject;
                    return true;
                }
            }

            foundComputer.value = null;
            return false;
        }
    }
}