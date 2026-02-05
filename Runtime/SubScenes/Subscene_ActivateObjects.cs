using UnityEngine;

/// <summary> Subescena que activa una lista de game objects al cargarse. </summary>
public class Subscene_ActivateObjects : Subscene
{
	[Space]
	[SerializeField] GameObject[] objectToActivate = null;


	protected override void OnLoad()
	{
		foreach(var obj in objectToActivate)
		{
			obj.SetActive(true);
		}
	}

	protected override void OnUnload()
	{
		foreach (var obj in objectToActivate)
		{
			obj.SetActive(false);
		}
	}
}
