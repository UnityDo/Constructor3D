using UnityEditor;
using UnityEngine;
using System.Collections;

//Select the dependencies of the found GameObject
public class Crea_Cadena : EditorWindow
{
	public GameObject primero = null;
	public GameObject ultimo = null;
	public GameObject eslabon = null;
	public GameObject aux = null;
	float numero_eslabones=0.0f;
	public float x, y;
	[MenuItem("Constructor/Crea_Cadena")]
	static void Init()
	{
		//UnityEditor.EditorWindow window = GetWindow(typeof(EditorGUIObjectField));
		//window.position = new Rect(0, 0, 250, 250);
		//window.Show();
		Crea_Cadena window = (Crea_Cadena)EditorWindow.GetWindow(typeof(Crea_Cadena));
		window.Show();
	}

	void OnInspectorUpdate()
	{
		Repaint();
	}

	void OnGUI()
	{
		EditorGUILayout.BeginHorizontal();
		numero_eslabones=EditorGUILayout.FloatField("Numero eslabones",numero_eslabones);
		x=EditorGUILayout.FloatField("Pos x",x);
		y=EditorGUILayout.FloatField("Pos y",y);
		primero = (GameObject)EditorGUI.ObjectField(new Rect(3, 23, position.width - 6, 20), "Fijo", primero, typeof(GameObject));


		ultimo = (GameObject)EditorGUI.ObjectField(new Rect(3, 65, position.width - 6, 20), "Bola", ultimo, typeof(GameObject));



		eslabon = (GameObject)EditorGUI.ObjectField(new Rect(3, 125, position.width - 6, 20), "Eslabon", eslabon, typeof(GameObject));



	

		if (GUI.Button (new Rect (3, 165, position.width - 6, 20), "Crea Cadena")) {
			Vector3 pos_inicial = Vector3.zero;
			GameObject clon_primero=Instantiate (primero,pos_inicial,Quaternion.identity) as GameObject;
			clon_primero.AddComponent<Rigidbody> ();
			clon_primero.AddComponent<FixedJoint> ();
			for(int i=0;i<=numero_eslabones;i++){
				if (i == 0) {
					//el primero
					GameObject clon_eslabon=Instantiate (eslabon,clon_primero.transform.position+(2*eslabon.GetComponent<Renderer>().bounds.extents)+clon_primero.GetComponent<Renderer>().bounds.extents,Quaternion.identity) as GameObject;
					clon_eslabon.AddComponent<Rigidbody> ();
					clon_eslabon.AddComponent<HingeJoint> ();
					clon_eslabon.GetComponent<HingeJoint> ().connectedBody = clon_primero.GetComponent<Rigidbody> ();
					clon_eslabon.name="Eslabon_0";
					aux = clon_eslabon;
				}else{
					if (i == numero_eslabones) {
					//ultimo
						GameObject clon_utlimo=Instantiate (ultimo,aux.transform.position-(eslabon.GetComponent<Renderer>().bounds.extents),Quaternion.identity) as GameObject;
						clon_utlimo.AddComponent<Rigidbody> ();
						clon_utlimo.AddComponent<HingeJoint> ();
						clon_utlimo.GetComponent<HingeJoint> ().connectedBody = aux.GetComponent<Rigidbody> ();
					}else{
						//eslabones

						GameObject clon_eslabon=Instantiate (eslabon,aux.transform.position-(eslabon.GetComponent<Renderer>().bounds.extents/2+new Vector3(x,y,0)),Quaternion.identity) as GameObject;
						clon_eslabon.AddComponent<Rigidbody> ();
						clon_eslabon.AddComponent<HingeJoint> ();
						clon_eslabon.GetComponent<HingeJoint> ().connectedBody = aux.GetComponent<Rigidbody> ();
						clon_eslabon.name="Eslabon_"+i;
						if((i+1)%2==0){
							//par
							clon_eslabon.transform.Rotate(new Vector3(0,90,0));
						}
						aux = clon_eslabon;
					}


				}

			}

		}
		EditorGUILayout.EndHorizontal();
	}
}