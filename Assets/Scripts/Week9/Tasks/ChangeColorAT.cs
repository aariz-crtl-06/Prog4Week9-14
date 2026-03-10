using UnityEngine;
using NodeCanvas.Framework;
using ParadoxNotion.Design;


namespace NodeCanvas.Tasks.Actions {

	public class ChangeColorAT : ActionTask
	{
		public BBParameter<Renderer> renderer;
		public Color color;
		public bool randomColor = false;
		protected override void OnExecute()
		{
			if (randomColor) renderer.value.material.color = new Color(Random.value, Random.value, Random.value, 1f);
			else renderer.value.material.color = color;
				EndAction(true);
		}

	}
}