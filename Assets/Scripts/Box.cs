using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
[CustomEditor(typeof(Box))]
public class BoxEditor : Editor
{
    //グリッドの幅
    public const float GRID = 1.0f;

    void OnSceneGUI()
    {
        Box box = target as Box;

        //グリッドの色
        Color color = Color.cyan * 0.7f;

        //グリッドの中心座標
        Vector3 orig = Vector3.zero;

        const int num = 50;
        const float size = GRID * num;

        //グリッド描画
        for (int x = -num; x <= num; x++)
        {
            Vector3 pos = orig + Vector3.right * x * GRID;
            Debug.DrawLine(pos + Vector3.forward * size, pos + Vector3.back * size, color);
        }
        for (int y = -num; y <= num; y++)
        {
            Vector3 pos = orig + Vector3.forward * y * GRID;
            Debug.DrawLine(pos + Vector3.left * size, pos + Vector3.right * size, color);
        }

        //グリッドの位置にそろえる
        Vector3 position = box.transform.position;

		if(!box._isCenter)
        {
            position.x = Mathf.Floor(position.x / GRID) * GRID;
            position.y = Mathf.Floor(position.y / GRID) * GRID;
            position.z = Mathf.Floor(position.z / GRID) * GRID;
        }
        else
        {
            position.x = Mathf.Floor(position.x / GRID) * GRID + (GRID * 0.5f);
            position.y = Mathf.Floor(position.y / GRID) * GRID + (GRID * 0.5f);
            position.z = Mathf.Floor(position.z / GRID) * GRID + (GRID * 0.5f);
        }

        box.transform.position = position;
        //Sceneビュー更新
        EditorUtility.SetDirty(target);
    }

    //フォーカスが外れたときに実行
    void OnDisable()
    {
        //Sceneビュー更新
        EditorUtility.SetDirty(target);
    }
}
#endif //UNITY_EDITOR

public class Box : MonoBehaviour
{
	public bool _isCenter = true;
}