using UnityEngine;
using NodeCanvas.Framework;
using ParadoxNotion.Design;


namespace NodeCanvas.Tasks.Conditions {

	public class PlayerInputCT : ConditionTask {

		protected override bool OnCheck() {

			return Input.anyKey;
		}
	}
}