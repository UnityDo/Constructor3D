using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Constructor : EditorWindow
{
  
    int elementos;
    GameObject objetoPrefab;
    float offx, offy, offz;
    public enum direccion { frente,atras,derecha,izquierda,arriba,abajo}
    public direccion direccionConstruye;
    
    [MenuItem("Window/Constructor")]
    static void Init()
    {
        Constructor ventana = (Constructor)EditorWindow.GetWindow(typeof(Constructor));
        ventana.Show();
    }
    private void OnGUI() { 




        direccionConstruye = (direccion)EditorGUILayout.EnumPopup("Primitive to create:", direccionConstruye);

        offx = EditorGUILayout.FloatField("Off de x", offx);
        offy = EditorGUILayout.FloatField("Off de y", offy);
        offz = EditorGUILayout.FloatField("Off de z", offz);

        elementos = EditorGUILayout.IntField("Numero de elemetos", elementos);

        objetoPrefab = (GameObject)EditorGUILayout.ObjectField(objetoPrefab, typeof(GameObject), true, GUILayout.Width(200));
        if (GUILayout.Button("Crea"))
        {
          
            for (int i = 0; i < elementos; i++)
            {
                CreaPorDireccion(i);


            }
            //Instantiate(objetoPrefab);

        }
    }
    void CreaPorDireccion(int veces)
    {
        GameObject Clon = new GameObject();
        switch ((direccionConstruye))
        {
            case direccion.frente:
                Clon = PrefabUtility.InstantiatePrefab(objetoPrefab) as GameObject;
                Clon.transform.position = Vector3.forward * (Clon.GetComponentInChildren<MeshRenderer>().bounds.size.x+offx)*veces;
                break;
            case direccion.atras:
                Clon = PrefabUtility.InstantiatePrefab(objetoPrefab) as GameObject;
                Clon.transform.position = Vector3.back;
                break;
            case direccion.derecha:
                Clon = PrefabUtility.InstantiatePrefab(objetoPrefab) as GameObject;
                Clon.transform.position = Vector3.right;
                break;
            case direccion.izquierda:
                Clon = PrefabUtility.InstantiatePrefab(objetoPrefab) as GameObject;
                Clon.transform.position = Vector3.left;
                break;
            case direccion.arriba:
                Clon = PrefabUtility.InstantiatePrefab(objetoPrefab) as GameObject;
                Clon.transform.position = Vector3.up;
                break;
            case direccion.abajo:
                Clon = PrefabUtility.InstantiatePrefab(objetoPrefab) as GameObject;
                Clon.transform.position = Vector3.down;
                break;
        }
       
    }
}