using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MyLayers
{
	public static bool IsLayerInMask(int layer, LayerMask mask)
	{
		return ((1 << layer) & mask) != 0;
	}
}
