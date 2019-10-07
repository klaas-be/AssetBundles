
using System.Collections;
using System.IO;
using UnityEngine;

public class BundleObjectLoader : MonoBehaviour
{

    [SerializeField] private string assetName = "testCompainionCube";
    [SerializeField] private string bundleName = "testbundle";
    // Start is called before the first frame update
    
    IEnumerator Start()
    {
        AssetBundleCreateRequest asyncBundleRequest =
            AssetBundle.LoadFromFileAsync(Path.Combine(Application.streamingAssetsPath, bundleName));
        yield return asyncBundleRequest;

        AssetBundle localAssetBundle = asyncBundleRequest.assetBundle;
        
        if (localAssetBundle == null)
        {
            Debug.LogError("Failed to load AssetBundle!");
            yield break;
        }

        var assetRequest = localAssetBundle.LoadAssetAsync<GameObject>(assetName);
        yield return assetRequest;
        
        var prefab = assetRequest.asset as GameObject;
        Instantiate(prefab);
        
        localAssetBundle.Unload(false);
    }
}
