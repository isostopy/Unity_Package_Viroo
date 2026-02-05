#if VIROO

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using Virtualware.Networking.Client;

public static class RegenerateAllNetworkIdsEditorTool
{
	/// <summary>
	/// Genera una nueva id para cada NetworkObject de la escena. </summary>
	[MenuItem("Isostopy/Viroo Tools/Regenerate All NetworkObject Ids")]
	public static void RegenerateAllNetworkIds()
	{
		var scene = SceneManager.GetActiveScene();
		var networkObjects = GameObject.FindObjectsByType<NetworkObject>(FindObjectsInactive.Include, FindObjectsSortMode.None);

		foreach(var networkObject in networkObjects)
		{
			var newId = NetworkObject.GenerateRandomId(scene);

			Undo.RegisterCompleteObjectUndo(networkObject, "Generadas nuevas id para los NetworkObject de " + scene.name);
			networkObject.ObjectId = newId;
		}
	}
}

#endif
