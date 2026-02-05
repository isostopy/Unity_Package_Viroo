using UnityEngine;

/// <summary> Subsecena que instancia un prefab al cargarse. </summary>
public class Subscene_InstantiateObjects : Subscene
{
	[Space]
	[SerializeField] GameObject objectToInstantiate = null;
	GameObject instantiatedObject = null;


	protected override void OnLoad()
	{
		instantiatedObject = Instantiate(objectToInstantiate, transform);
		instantiatedObject.transform.SetPositionAndRotation(transform.position, transform.rotation);
	}

	protected override void OnUnload()
	{
		Destroy(instantiatedObject);
	}
}
