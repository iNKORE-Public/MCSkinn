﻿//
//    MCSkinn, A modern Minecraft 3D skin manager/editor for Windows by NotYoojun.!
//    Copyright © iNKORE! 2023
//
//    The copy of source (only the public part) can be used anywhere with a credit to MCSkinn page at your own risk
//    https://github.com/InkoreStudios/MCSkinn
//

using System.Drawing;
using WinForms = System.Windows.Forms;
using WPF = System.Windows;
using iNKORE.Coreworks.Windows.Helpers;
using MCSkinn.Scripts.Paril.OpenGL;

namespace MCSkinn.Scripts.Tools
{
    public class CameraTool : ITool
    {
        private WinForms.Screen _clickedScreen;
        private Point _oldMouse;

        #region ITool Members

        public void BeginClick(SkinNode skin, Point p, WPF.Input.MouseButton e)
        {
            _oldMouse = p;
            _clickedScreen = WinForms.Screen.FromPoint(WinForms.Cursor.Position);
        }

        public void SelectedBrushChanged()
        {
        }

        public void MouseMove(SkinNode skin, Point p)
        {
            var delta = new Point(p.X - _oldMouse.X, p.Y - _oldMouse.Y);
            Point position = WinForms.Cursor.Position;

            if(_clickedScreen == null)
                _clickedScreen = WinForms.Screen.FromPoint(WinForms.Cursor.Position);

            if (GlobalSettings.InfiniteMouse)
            {
                Rectangle screenBounds = _clickedScreen.Bounds;
                bool wasWrapped = false;
                Point oldMouseOnScreen = Program.Editor.IsCompatibilityModeOn ? Program.Editor.RendererControl.PointToScreen(_oldMouse) : Program.Editor.Renderer.PointToScreen(_oldMouse.ToWpfRect()).ToDrawingRectangle();

                if (position.X <= screenBounds.X && oldMouseOnScreen.X > screenBounds.X)
                {
                    WinForms.Cursor.Position = new Point(screenBounds.X + screenBounds.Width, position.Y);
                    wasWrapped = true;
                }
                else if (position.X >= screenBounds.X + screenBounds.Width - 1 &&
                         oldMouseOnScreen.X < screenBounds.X + screenBounds.Width - 1)
                {
                    WinForms.Cursor.Position = new Point(screenBounds.X, position.Y);
                    wasWrapped = true;
                }

                if (position.Y <= screenBounds.Y && oldMouseOnScreen.Y > screenBounds.Y)
                {
                    WinForms.Cursor.Position = new Point(position.X, screenBounds.Y + screenBounds.Height);
                    wasWrapped = true;
                }
                else if (position.Y >= screenBounds.Y + screenBounds.Height - 1 &&
                         oldMouseOnScreen.Y < screenBounds.Y + screenBounds.Height - 1)
                {
                    WinForms.Cursor.Position = new Point(position.X, screenBounds.Y);
                    wasWrapped = true;
                }

                if (wasWrapped)
                    _oldMouse = Program.Editor.GetRenderCursorPos();
                else
                    _oldMouse = p;
            }
            else
                _oldMouse = p;

            if (GetChangedButton() == Program.Editor.CameraZoom)
                Program.Editor.ScaleView(delta, 1);
            else if (GetChangedButton() == Program.Editor.CameraTranslate)
                Program.Editor.TranslateView(delta, 1);
            else
                Program.Editor.RotateView(delta, 1);

        }

        public static WinForms.MouseButtons GetChangedButton(WPF.Input.MouseButtonState state = WPF.Input.MouseButtonState.Pressed)
        {
            if (WPF.Input.Mouse.LeftButton == state || WinForms.Control.MouseButtons.HasFlag(WinForms.MouseButtons.Left))
                return WinForms.MouseButtons.Left;
            else if (WPF.Input.Mouse.MiddleButton == state || WinForms.Control.MouseButtons.HasFlag(WinForms.MouseButtons.Middle))
                return WinForms.MouseButtons.Middle;
            else if (WPF.Input.Mouse.RightButton == state || WinForms.Control.MouseButtons.HasFlag(WinForms.MouseButtons.Right))
                return WinForms.MouseButtons.Right;
            else
                return WinForms.MouseButtons.None;
        }

        public bool MouseMoveOnSkin(ColorGrabber pixels, SkinNode skin, int x, int y)
        {
            return false;
        }

        public bool RequestPreview(ColorGrabber pixels, SkinNode skin, int x, int y)
        {
            return false;
        }

        public bool EndClick(ColorGrabber pixels, SkinNode skin, Point p, WPF.Input.MouseButton button)
        {
            return false;
        }

        public string GetStatusLabelText()
        {
            return Editor.GetLanguageString("T_CAMERA");
        }

        #endregion
    }
}