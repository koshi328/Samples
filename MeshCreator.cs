using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * RequireComponent
 * 必須コンポーネント（アタッチされていなければ自動でアタッチされる）
 */
[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(MeshFilter))]
public class MeshCreator : MonoBehaviour
{
    void Start()
    {
        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
        MeshFilter meshFilter = GetComponent<MeshFilter>();

        // ビルトインのマテリアルを取得
        // EditorはAssetDatabaseからしか取得できない
#if UNITY_EDITOR
        Material material = UnityEditor.AssetDatabase.GetBuiltinExtraResource<Material>("Default-Material.mat");
#else
        Material material = Resources.GetBuiltinResource<Material>("Default-Material.mat");
#endif

        // 頂点座標
        Vector3[] verteies = new Vector3[]
        {
            new Vector3(-1, 1, 0), // 左上
            new Vector3( 1, 1, 0), // 右上
            new Vector3(-1,-1, 0), // 左下
            new Vector3( 1,-1, 0)  // 右下
        };

        // 頂点をつなぐ順番
        // 時計回りに3点をつなぐ
        int[] triangles = new int[]
        {
            0,1,2,
            2,1,3,
        };

        // メッシュを生成
        Mesh mesh = new Mesh();
        mesh.vertices = verteies;
        mesh.triangles = triangles;

        // メッシュを表示する為の設定
        meshFilter.sharedMesh = mesh;
        meshRenderer.material = material;
    }
}
