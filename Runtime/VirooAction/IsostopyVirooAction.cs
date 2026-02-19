using UnityEngine;

#if VIROO
using Viroo.Interactions;
#endif

namespace Isostopy.Viroo
{

	/// <summary>
	/// Clase intermediaria que permite hacer acciones de Viroo que luego van a funcionar tambien sin Viroo.
	/// </summary>

#if VIROO
	public abstract class IsostopyVirooAction : BroadcastObjectAction
#else
	public abstract class IsostopyVirooAction : MonoBehaviour
#endif
	{

#if !VIROO

		public void Execute()
		{
			LocalExecuteImplementation(string.Empty);
		}

		public virtual void Execute(string data)
		{
			LocalExecuteImplementation(data);
		}

		protected abstract void LocalExecuteImplementation(string data);

		public virtual void RestoreState(string data)
		{
			// No se llama nunca si no estamos en VIROO. Pero tiene que estar porque si se usa en VIROO.
		}

#endif

	}
}
