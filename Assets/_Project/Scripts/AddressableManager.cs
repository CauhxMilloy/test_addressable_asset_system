using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceLocations;

public class AddressableManager : MonoBehaviour
{
	#region VARIABLES

	[SerializeField] private AssetLabelReference assetLabelReference;
    [SerializeField] private GameObject animation;
    private List<IResourceLocation> cubes;

	#endregion

	#region MONOBEHAVIOUR_METHODS

	private void Start()
	{
		Addressables.LoadResourceLocationsAsync(assetLabelReference.labelString).Completed += AddressableManager_Completed;
	}

	#endregion


	#region PRIVATE_METHODS

	private void AddressableManager_Completed(AsyncOperationHandle<IList<IResourceLocation>> operation)
	{
		print("AddressableManager_Completed");
		animation.SetActive(false);
		cubes = new List<IResourceLocation>(operation.Result);

		print("cubes count:: " + cubes.Count);
		foreach (var cube in cubes)
		{
			Addressables.InstantiateAsync(cube);
		}
	}

	#endregion
}