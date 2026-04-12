using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System.Collections.Generic;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
    public class ScanComputersAT : ActionTask
    {
        public BBParameter<List<Collider>> computers;
        public BBParameter<GameObject> targetComputer;
        public BBParameter<float> scanRadius = 5f;
        public BBParameter<LayerMask> scanLayers;

        private Collider[] results = new Collider[10];

        protected override void OnExecute()
        {
            if (computers.value == null)
            {
                computers.value = new List<Collider>();
            }
        }

        protected override void OnUpdate()
        {
            computers.value.Clear();

            int numberOfTargets = Physics.OverlapSphereNonAlloc(
                agent.transform.position,
                scanRadius.value,
                results,
                scanLayers.value
            );

            for (int i = 0; i < numberOfTargets; i++)
            {
                if (results[i] == null)
                    continue;

                computers.value.Add(results[i]);

                Computer computer = results[i].GetComponentInParent<Computer>();

                if (computer != null && computer.isBroken)
                {
                    targetComputer.value = computer.gameObject;
                    EndAction(true);
                    return;
                }
            }

            targetComputer.value = null;
            EndAction(false);
        }
    }
}