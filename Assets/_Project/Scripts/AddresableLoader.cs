using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public static class AddressableLoader
{
    public static IEnumerator Initialize<T>(string assetLabel, List<T> assets)
    {
        yield return Addressables.LoadAssetsAsync<T>(assetLabel, op =>
        {
            assets.Add(op);
        });
    }

    public static IEnumerator InitCreate<T>(string assetLabel, List<T> assets) where T : Object
    {
        yield return Addressables.LoadAssetsAsync<T>(assetLabel, op =>
        {
            assets.Add(Object.Instantiate(op));
        });
    }

    public static IEnumerator InitCreateDeactivate<T>(string assetLabel, List<T> assets) where T : Object
    {
        yield return Addressables.LoadAssetsAsync<T>(assetLabel, op =>
        {
            assets.Add(Object.Instantiate(op));
        });

        foreach (var asset in assets)
        {
            GameObject.Find(asset.name).gameObject.SetActive(false);
        }
    }
}