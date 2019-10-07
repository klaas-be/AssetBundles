using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Windows;
/// <summary>
/// Create a new shortcut for the assset dropdown: Build AssetBundles
/// </summary>
public class CreateAssetBundles
{
   [MenuItem("Assets/Build AssetBundles")]
   static void BuildAllAssetBundles()
   {
      string assetBundleDirectory = "Assets/StreamingAssets";

      if (!Directory.Exists(Application.streamingAssetsPath))
      {
         Directory.CreateDirectory(assetBundleDirectory);
      }

      BuildPipeline.BuildAssetBundles(assetBundleDirectory, BuildAssetBundleOptions.None,
         EditorUserBuildSettings.activeBuildTarget);
   }
}
