using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace FreeDraw
{
    // Helper methods used to set drawing settings
    public class DrawingSettings : MonoBehaviour
    {

        public static bool isCursorOverUI = false;
        public float Transparency = 1f;
        BGmanager1 bgmanager1;
        BGmanager2 bgmanager2;
        BGmanager3 bgmanager3;
        BGmanager4 bgmanager4;
        BGmanager5 bgmanager5;
        BGmanager6 bgmanager6;


        // Changing pen settings is easy as changing the static properties Drawable.Pen_Colour and Drawable.Pen_Width
        public void SetMarkerColour(Color new_color)
        {

            Drawable.Pen_Colour = new_color;

        }
        // new_width is radius in pixels
        public void SetMarkerWidth(int new_width)
        {

            Drawable.Pen_Width = new_width;

        }
        public void SetMarkerWidth(float new_width)
        {

            SetMarkerWidth((int)new_width);

        }

        public void SetTransparency(float amount)
        {

            Transparency = amount;
            Color c = Drawable.Pen_Colour;
            c.a = amount;
            Drawable.Pen_Colour = c;

        }


        // Call these these to change the pen settings
        public void SetMarkerRed()
        {

            Color c = new Color(213 / 255f, 1 / 255f, 0 / 255f);
            c.a = Transparency;
            SetMarkerColour(c);
            Drawable.drawable.SetPenBrush();
            Drawable.Pen_Width = 2;

        }
        public void SetMarkerGreen()
        {

            Color c = new Color(20 / 255f, 160 / 255f, 82 / 255f);
            c.a = Transparency;
            SetMarkerColour(c);
            Drawable.drawable.SetPenBrush();
            Drawable.Pen_Width = 2;
        }
        public void SetMarkerBlue()
        {

            Color c = new Color(2 / 255f, 46 / 255f, 117 / 255f);
            c.a = Transparency;
            SetMarkerColour(c);
            Drawable.drawable.SetPenBrush();
            Drawable.Pen_Width = 2;


        }

        public void SetMarkerCyan()
        {

            Color c = new Color(1/255f,159 / 255f, 232 / 255f);
            c.a = Transparency;
            SetMarkerColour(c);
            Drawable.drawable.SetPenBrush();
            Drawable.Pen_Width = 2;
        }
        public void SetMarkerYellow()
        {

            Color c = new Color(255 / 255f, 211 / 255f, 7 / 255f);
            c.a = Transparency;
            SetMarkerColour(c);
            Drawable.drawable.SetPenBrush();
            Drawable.Pen_Width = 2;
        }
        public void SetMarkerOrange()
        {

            Color c = new Color(254 / 255f, 122/ 255f, 6 / 255f);
            c.a = Transparency;
            SetMarkerColour(c);
            Drawable.drawable.SetPenBrush();
            Drawable.Pen_Width = 2;
        }
        public void SetMarkerBrown()
        {

            Color c = new Color(112 / 255f, 64 / 255f, 15 / 255f);
            c.a = Transparency;
            SetMarkerColour(c);
            Drawable.drawable.SetPenBrush();
            Drawable.Pen_Width = 2;
        }
        public void SetMarkerPink()
        {

            Color c = new Color(233 / 255f, 104 / 255f, 161 / 255f);
            c.a = Transparency;
            SetMarkerColour(c);
            Drawable.drawable.SetPenBrush();
            Drawable.Pen_Width = 2;
        }
        public void SetEraser()
        {

            SetMarkerColour(new Color(0, 0, 0, 0));
            Drawable.Pen_Width = 6;

        }

        public void PartialSetEraser()
        {

            SetMarkerColour(new Color(255f, 255f, 255f, 0.5f));

        }

        public void ResetCan()
        {
            Drawable.drawable.ResetCanvas();
            

            

        }

        public void ResetAllCan()
        {
            Drawable.drawable.ResetCanvas();
          
            bgmanager1 = GameObject.Find("BackGround_1").GetComponent<BGmanager1>();
            bgmanager2 = GameObject.Find("BackGround_2").GetComponent<BGmanager2>();
            //bgmanager3 = GameObject.Find("BackGround_3").GetComponent<BGmanager3>();
           // bgmanager4 = GameObject.Find("BackGround_4").GetComponent<BGmanager4>();
          



            for (int i = bgmanager1.BoxList.Count - 1; i >= 0; i--)
            {
                Destroy(bgmanager1.BoxList[i]);
            }
            for (int i = bgmanager2.BoxList.Count - 1; i >= 0; i--)
            {
                Destroy(bgmanager2.BoxList[i]);
            }
           /* for (int i = bgmanager3.BoxList.Count - 1; i >= 0; i--)
            {
                Destroy(bgmanager3.BoxList[i]);
            }
            for (int i = bgmanager4.BoxList.Count - 1; i >= 0; i--)
            {
                Destroy(bgmanager4.BoxList[i]);
            }
            for (int i = bgmanager5.BoxList.Count - 1; i >= 0; i--)
            {
                Destroy(bgmanager5.BoxList[i]);
            }

            for (int i = bgmanager6.BoxList.Count - 1; i >= 0; i--)
            {
                Destroy(bgmanager6.BoxList[i]);
            }*/



        }
    }
}