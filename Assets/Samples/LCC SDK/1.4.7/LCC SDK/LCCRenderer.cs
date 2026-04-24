using System;
using UnityEngine;
using LCCCore;

[ExecuteInEditMode]
public class LCCRenderer : MonoBehaviour
{
    public LCCManager m_manager;
    public string m_FilePath;
    //public GameObject m_clipBox;
    private LCCCore.Renderer m_renderer;


    void Start()
    {
        
        m_renderer = m_manager.GetRender(this.transform);
        
        m_renderer.Load(m_FilePath, PlatformType.PC, onLoadCallback);
        m_renderer.SetDebugMode(true);
        m_renderer.SetColliderEnable(true);


        //m_renderer.SetZDepth(true);

        //transform.rotation = Quaternion.identity;
        //transform.Rotate(Vector3.right, -90);
        //transform.localScale = new Vector3(-1, 1, 1);
        //Camera.main.gameObject.transform.rotation = Quaternion.identity;
        //Camera.main.gameObject.transform.position = new Vector3(0.0f, 1.6f, 0.0f);
        //Camera.main.gameObject.transform.Rotate(Vector3.up, 180);

    }

    /*private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 _mousePosition = Input.mousePosition;
            if (m_manager.Raycast(_mousePosition, out HitResult _result))
            {
                GameObject _sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                _sphere.transform.position = _result.hitPos;
                _sphere.transform.rotation = Quaternion.identity;
                _sphere.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            }
        }
    }*/

    private void onLoadCallback()
    {
        Debug.Log("data loaded !!!");
    }

    [ContextMenu("Render (need a little time to load data)")]
    public void Render()
    {    
        if(m_renderer == null)
            m_renderer = m_manager.GetRender(this.transform);
        m_renderer.Load(m_FilePath, PlatformType.PC, onLoadCallback);
    }

    [ContextMenu("unRender")]
    public void unRender()
    {
        m_renderer?.Dispose();
    }

    public void onRenderPointClick()
    {
        Texture2D rainbow = Resources.Load<Texture2D>("rainbow");
        m_renderer.SwitchRenderMode(LCCCore.RenderMode.PointCloud, rainbow);

    }
    public void onRender3DGSClick()
    {
        m_renderer.SwitchRenderMode(LCCCore.RenderMode.LCCGS);
    }

    public void onAlphaClick()
    {
        m_renderer.SetAlpha(0.3f);
    }

    public void onClipBox()
    {        
        //var _mat = m_clipBox.transform.worldToLocalMatrix;
        //m_renderer.SetClip(ClipType.PreBox, _mat);
    }

    public void onFov()
    {
        int _w = Camera.main.pixelWidth;
        int _h = Camera.main.pixelHeight;
        float _fov = Camera.main.fieldOfView;
        float _aspect = Camera.main.aspect;
        m_manager.SetFOV(_w, _h, _fov, _aspect);
    }
}
