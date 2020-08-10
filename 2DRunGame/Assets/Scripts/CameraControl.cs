using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [Header("目標：要追蹤的物件")]
    public Transform target;
    [Header("追蹤速度"), Range(0, 100)]
    public float speed = 1;
    [Header("攝影機拍攝的上限與下限")]
    public Vector2 limit = new Vector2(0, 0.7f);

    // 下限 0 上限 0.7

    /// <summary>
    /// 追蹤
    /// </summary>
    private void Track()
    {
        Vector3 posA = transform.position;  // A 點：攝影機座標
        Vector3 posB = target.position;     // B 點：目標  座標

        posB.z = -10;                       // 攝影機 Z 軸固定 -10
        posB.y = Mathf.Clamp(posB.y, limit.x, limit.y);       // Y 軸 = 數學.夾住(Y軸，限制.X，限制.Y)


        // A 點　= 差值(A點，B點，百分比)
        posA = Vector3.Lerp(posA, posB, speed * Time.deltaTime);

        transform.position = posA;  // 攝影機.座標 = A 點
    }

    // Late Updete 在 Updete 後執行，攝影機追蹤
    private void LateUpdate()
    {
        Track();
    }
}
