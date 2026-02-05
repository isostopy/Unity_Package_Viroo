using UnityEngine;
using UnityEngine.Events;

/// <summary> Para cargar "escenas" sin tener que cambiar de escena de Unity. Es para Viroo, basicamente. </summary>
public abstract class Subscene : MonoBehaviour
{
	[Space]
	public string id = "";

	[HideInInspector] public UnityEvent<Subscene> onLoaded = new();
	[HideInInspector] public UnityEvent<Subscene> onUnloaded = new();


	// ------------------------------------------------------------------------------ 

	private void Reset()
	{
		id = gameObject.name.ToLower().Replace(" ", "-");
	}


	// ------------------------------------------------------------------------------

	/// <summary> Carga esta subescena. </summary>
	public void Load()
	{
		OnLoad();
		onLoaded.Invoke(this);
	}
	protected abstract void OnLoad();

	/// <summary> Descarga esta subescena. </summary>
	public void Unload()
	{
		OnUnload();
		onUnloaded.Invoke(this);
	}
	protected abstract void OnUnload();
}
