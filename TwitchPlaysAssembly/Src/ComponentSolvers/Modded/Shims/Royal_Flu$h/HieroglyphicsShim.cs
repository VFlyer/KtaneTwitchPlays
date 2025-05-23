﻿using System.Collections;

[ModuleID("hieroglyphics")]
public class HieroglyphicsShim : ComponentSolverShim
{
	public HieroglyphicsShim(TwitchModule module)
		: base(module)
	{
	}

	protected override IEnumerator ForcedSolveIEnumeratorShimmed()
	{
		if (Unshimmed.ForcedSolveMethod == null) yield break;
		var coroutine = (IEnumerator) Unshimmed.ForcedSolveMethod.Invoke(Unshimmed.CommandComponent, null);
		yield return coroutine;
		while (!Module.BombComponent.IsSolved)
			yield return true;
	}
}
