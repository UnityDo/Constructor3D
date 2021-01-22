using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Mueve_Editor : Editor {
	//Gira cuando se pulsa la g
	[MenuItem ("Modifica/Rota45 %g")]
	static void  Rotate45() {
		var obj = Selection.activeGameObject;
		obj.transform.Rotate(Vector3.up*45);
	}
	
	[MenuItem ("Modifica/Mueve")]
	static void  Mueve_Diez() {
		var obj = Selection.activeGameObject;
		obj.transform.position = new Vector3 (obj.transform.position.x + 10, obj.transform.position.y, obj.transform.position.z);
	}
	[MenuItem ("Modifica/Duplica")]
	static void  Duplica() {
		Object prefabRoot = PrefabUtility.GetPrefabParent (Selection.activeGameObject);

		if (prefabRoot != null)
			PrefabUtility.InstantiatePrefab (prefabRoot);
		else
			Instantiate (Selection.activeGameObject);
	}

}
