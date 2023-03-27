
using UnityEngine;

public class LightEtti : MonoBehaviour
{
    public int m_ShakeInternal = 5;
    private int m_shakeframeCount = 1;

    [SerializeField] private float m_noiseRange = 2;
    public int m_MaxLineCount = 30;
    public int m_MaxnoiseRange = 1;

    /// <summary>
    /// 闪电节点数量
    /// </summary>
    private int m_linePointcount = 10;

    /// <summary>
    /// 闪电节点距离
    /// </summary>
    [SerializeField] private float m_pointDis = 0.5f;

    [SerializeField] private Transform m_targetts;
    private float m_timer = 0;
    private LineRenderer m_linerender;
    [SerializeField] private bool m_isLighting = false;


    // Start is called before the first frame update
    void Start()
    {
        m_linerender = this.GetComponent<LineRenderer>();
    }

    public void StartLight(Transform targetts)
    {
        m_targetts = targetts;
        this.m_isLighting = true;
        this.m_shakeframeCount = m_ShakeInternal;
    }


    // Update is called once per frame
    void Update()
    {
        if (this.m_shakeframeCount > 0)
        {
            m_shakeframeCount--;
            return;
        }

        if (!this.m_isLighting) return;
        this.m_shakeframeCount = m_ShakeInternal;
        float distance = Vector3.Distance(transform.position, m_targetts.position);
        int pointcount = Mathf.CeilToInt(distance / this.m_pointDis);
        this.m_linePointcount = pointcount > this.m_MaxLineCount ? this.m_MaxLineCount : pointcount;
        if (this.m_linePointcount >= this.m_MaxLineCount)
            m_pointDis = distance / this.m_MaxLineCount;
        this.m_linerender.positionCount = this.m_linePointcount + 1;
        Vector3 dir = (this.m_targetts.position - transform.position).normalized;
        for (int i = 0; i < this.m_linePointcount; i++)
        {
            Vector3 pos = this.transform.position + dir * m_pointDis * i;
            float newnoiseRange = this.m_noiseRange * distance;
            if (newnoiseRange > this.m_MaxnoiseRange) newnoiseRange = this.m_MaxnoiseRange;
            pos.x += Random.Range(-newnoiseRange, newnoiseRange);
            pos.y += Random.Range(-newnoiseRange, newnoiseRange);
            if (i == 0)
            {
                this.m_linerender.SetPosition(0, transform.position);
            }
            else
            {
                this.m_linerender.SetPosition(i, pos);
            }
        }

        if (this.m_linerender.positionCount - 1 != 0)
        {
            this.m_linerender.SetPosition(this.m_linerender.positionCount - 1, this.m_targetts.position);
        }
        else
        {
            this.m_linerender.SetPosition(0, transform.position);
        }
    }
}