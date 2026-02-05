using UnityEngine;
using System.Collections.Generic;

#if VIROO
using Viroo.Interactions;
#endif


/// <summary>
/// Carga o descarga subescenas cordinando el cambio a todos los usuarios de la sesion de Viroo.
/// </summary>

#if VIROO
public class SubsceneLoader : BroadcastObjectAction
#else
public class SubsceneLoader : MonoBehaviour
#endif

{
	[Space]
	[SerializeField] List<Subscene> subscenes = new();

	bool initialized = false;


	// ------------------------------------------------------------------------------

	private void Start()
	{
		if (initialized)
			return;
		if (subscenes.Count == 0)
			return;
		LocalLoadSubscene(subscenes[0].id);
	}


	// ------------------------------------------------------------------------------

	public void LoadSubscene(Subscene subscene)
	{
		if (subscenes.Contains(subscene) == false)
		{
			Debug.LogError("SubsceneLoader no tiene la subescena [" + subscene.name + "] en la lista.");
			return;
		}

#if VIROO
		Execute(subscene.id);
#else
		LocalLoadSubscene(subscene.id);
#endif
	}

	// -------------------------------------

#if VIROO

	protected override void LocalExecuteImplementation(string subsceneId)
	{
		LocalLoadSubscene(subsceneId);
	}

	public override void RestoreState(string subsceneId)
	{
		LocalLoadSubscene(subsceneId);
	}

#endif

	private void LocalLoadSubscene(string subsceneId)
	{
		initialized = true;

		foreach(var subscene in subscenes)
		{
			if (subscene.id == subsceneId)
				subscene.Load();
			else
				subscene.Unload();
		}
	}
}
