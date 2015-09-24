
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(MegaTankWheels))]
public class MegaTankWheelsEditor : Editor
{
	public override void OnInspectorGUI()
	{
		EditorGUIUtility.LookLikeControls();
		DrawDefaultInspector();
	}

#if UNITY_5_1 || UNITY_5_2
	[DrawGizmo(GizmoType.NotInSelectionHierarchy | GizmoType.Pickable | GizmoType.InSelectionHierarchy)]
#else
	[DrawGizmo(GizmoType.NotSelected | GizmoType.Pickable | GizmoType.SelectedOrChild)]
#endif
	static void RenderGizmo(MegaTankWheels track, GizmoType gizmoType)
	{
		if ( (gizmoType & GizmoType.Active) != 0 && Selection.activeObject == track.gameObject )
		{
			Gizmos.matrix = track.transform.localToWorldMatrix;
			Gizmos.DrawWireSphere(Vector3.zero, track.radius);
		}
	}
}