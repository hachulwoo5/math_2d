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
        BackGruondManager backGroundManager;

       


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

        #region Color Setting
        public void SetMarkerRed()
        {

            Color c = new Color(213 / 255f, 1 / 255f, 0 / 255f);
            c.a = Transparency;
            SetMarkerColour(c);
            Drawable.drawable.SetPenBrush();
            Drawable.Pen_Width = 1;

        }
        public void SetMarkerGreen()
        {

            Color c = new Color(20 / 255f, 160 / 255f, 82 / 255f);
            c.a = Transparency;
            SetMarkerColour(c);
            Drawable.drawable.SetPenBrush();
            Drawable.Pen_Width = 1;
        }
        public void SetMarkerBlue()
        {

            Color c = new Color(2 / 255f, 46 / 255f, 117 / 255f);
            c.a = Transparency;
            SetMarkerColour(c);
            Drawable.drawable.SetPenBrush();
            Drawable.Pen_Width = 1;


        }
        public void SetMarkerCyan()
        {

            Color c = new Color(1 / 255f, 159 / 255f, 232 / 255f);
            c.a = Transparency;
            SetMarkerColour(c);
            Drawable.drawable.SetPenBrush();
            Drawable.Pen_Width = 1;
        }
        public void SetMarkerYellow()
        {

            Color c = new Color(255 / 255f, 211 / 255f, 7 / 255f);
            c.a = Transparency;
            SetMarkerColour(c);
            Drawable.drawable.SetPenBrush();
            Drawable.Pen_Width = 1;
        }
        public void SetMarkerOrange()
        {

            Color c = new Color(254 / 255f, 122 / 255f, 6 / 255f);
            c.a = Transparency;
            SetMarkerColour(c);
            Drawable.drawable.SetPenBrush();
            Drawable.Pen_Width = 1;
        }
        public void SetMarkerBrown()
        {

            Color c = new Color(112 / 255f, 64 / 255f, 15 / 255f);
            c.a = Transparency;
            SetMarkerColour(c);
            Drawable.drawable.SetPenBrush();
            Drawable.Pen_Width = 1;
        }
        public void SetMarkerPink()
        {

            Color c = new Color(233 / 255f, 104 / 255f, 161 / 255f);
            c.a = Transparency;
            SetMarkerColour(c);
            Drawable.drawable.SetPenBrush();
            Drawable.Pen_Width = 1;
        }
        #endregion
       

        public void SetEraser()
        {

            SetMarkerColour(new Color(0, 0, 0, 0));
            Drawable.Pen_Width = 12;

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
          
            backGroundManager = GameObject.Find("BackGround").GetComponent<BackGruondManager>();

            for (int i = backGroundManager.BackGroundList.Count - 1; i >= 0; i--)
            {
                Destroy(backGroundManager.BackGroundList[i]);
            }



        }
    }
}