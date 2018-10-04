using UnityEngine;

/* 
 * Title: Outline Effect
 * Author: Josue Lopes
 * Date: October 2nd, 2018
*/

public class OutlineEffect : MonoBehaviour
{
    private Camera m_Camera;
    private Camera m_TempCamera;
    private Shader m_DrawWhiteShader;
    private Shader m_OutlineShader;
    private Material m_PostProcessMaterial;

    void Start ()
    {
        m_Camera = GetComponent<Camera>();
        m_OutlineShader = Shader.Find("Custom/PP_Outline");
        m_DrawWhiteShader = Shader.Find("Unlit/DrawWhite");
        m_PostProcessMaterial = new Material(m_OutlineShader);

        m_TempCamera = new GameObject().AddComponent<Camera>();
        m_TempCamera.enabled = false;
	}

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        // set up temporary camera
        m_TempCamera.CopyFrom(m_Camera);
        m_TempCamera.clearFlags = CameraClearFlags.Color;
        m_TempCamera.backgroundColor = Color.black;

        // cull layers that don't have outline
        m_TempCamera.cullingMask = 1 << LayerMask.NameToLayer("Outline");

        // create render texture
        RenderTexture tempRTexture = RenderTexture.GetTemporary(source.width, source.height, 0, RenderTextureFormat.R8);    
        
        // set camera render texture
        m_TempCamera.targetTexture = tempRTexture;

        // render all objects on specific layer with white shader
        m_TempCamera.RenderWithShader(m_DrawWhiteShader, "");

        // input scene texture and blit with outline material
        m_PostProcessMaterial.SetTexture("_SceneTex", source);
        Graphics.Blit(tempRTexture, destination, m_PostProcessMaterial);

        RenderTexture.ReleaseTemporary(tempRTexture);
    }
}
