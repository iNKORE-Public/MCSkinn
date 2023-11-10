﻿using iNKORE.Coreworks.Localization;
using iNKORE.Coreworks.Windows.Helpers;
using MCSkinn.Dialogs;
using MCSkinn.Scripts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using iNKORE.Hub.Shared;
using iNKORE.UI.WPF.Modern.Controls;

namespace MCSkinn.Pages
{
    /// <summary>
    /// PageSettings.xaml 的交互逻辑
    /// </summary>
    public partial class PageSettings : System.Windows.Controls.Page
    {
        #region Initialization
        public PageSettings()
        {
            InitializeComponent();
        }

        private bool isLoading = true;

        public void RegisterLanguage()
        {
            LanguageWpf.Instance.Register(this, TabItem_Options, TabItem.HeaderProperty);
            LanguageWpf.Instance.Register(this, TabItem_Hotkeys, TabItem.HeaderProperty);

            LanguageWpf.Instance.Register(this, Button_Reset_Enabled, ContentProperty);
            LanguageWpf.Instance.Register(this, HyperlinkButton_ChangeSettings_Language, HyperlinkButton.ContentProperty);
            
            LanguageWpf.Instance.Register(this, TextBlock_Language, TextBlock.TextProperty);
            LanguageWpf.Instance.Register(this, TextBlock_Language_Description, TextBlock.TextProperty);
            LanguageWpf.Instance.Register(this, TextBlock_Language_Author, TextBlock.TextProperty);
            LanguageWpf.Instance.Register(this, TextBlock_Language_Version, TextBlock.TextProperty);
            LanguageWpf.Instance.Register(this, TextBlock_ThemeMode, TextBlock.TextProperty);
            LanguageWpf.Instance.Register(this, TextBlock_ThemeMode_Description, TextBlock.TextProperty);
            LanguageWpf.Instance.Register(this, TextBlock_Backdrop, TextBlock.TextProperty);
            LanguageWpf.Instance.Register(this, TextBlock_Backdrop_Description, TextBlock.TextProperty);
            LanguageWpf.Instance.Register(this, TextBlock_RenderScale, TextBlock.TextProperty);
            LanguageWpf.Instance.Register(this, TextBlock_RenderScale_Description, TextBlock.TextProperty);
            LanguageWpf.Instance.Register(this, TextBlock_UIScale, TextBlock.TextProperty);
            LanguageWpf.Instance.Register(this, TextBlock_UIScale_Description, TextBlock.TextProperty);
            LanguageWpf.Instance.Register(this, TextBlock_TextureOverlay, TextBlock.TextProperty);
            LanguageWpf.Instance.Register(this, TextBlock_TextureOverlay_Description, TextBlock.TextProperty);
            LanguageWpf.Instance.Register(this, TextBlock_TextureOverlay_LineColor, TextBlock.TextProperty);
            LanguageWpf.Instance.Register(this, TextBlock_TextureOverlay_LineSize, TextBlock.TextProperty);
            LanguageWpf.Instance.Register(this, TextBlock_TextureOverlay_TextColor, TextBlock.TextProperty);
            LanguageWpf.Instance.Register(this, TextBlock_TextureOverlay_TextSize, TextBlock.TextProperty);
            LanguageWpf.Instance.Register(this, TextBlock_PixelGrid, TextBlock.TextProperty);
            LanguageWpf.Instance.Register(this, TextBlock_PixelGrid_Description, TextBlock.TextProperty);
            LanguageWpf.Instance.Register(this, TextBlock_PixelGrid_Color, TextBlock.TextProperty);
            LanguageWpf.Instance.Register(this, TextBlock_RememberPrefers, TextBlock.TextProperty);
            LanguageWpf.Instance.Register(this, TextBlock_RememberPrefers_Description, TextBlock.TextProperty);
            LanguageWpf.Instance.Register(this, TextBlock_IsManipulationEnabled, TextBlock.TextProperty);
            LanguageWpf.Instance.Register(this, TextBlock_IsManipulationEnabled_Description, TextBlock.TextProperty);
            LanguageWpf.Instance.Register(this, TextBlock_StylusToDraw, TextBlock.TextProperty);
            LanguageWpf.Instance.Register(this, TextBlock_StylusToDraw_Description, TextBlock.TextProperty);
            LanguageWpf.Instance.Register(this, TextBlock_CompatibilityMode_RestartWarning, TextBlock.TextProperty);
            LanguageWpf.Instance.Register(this, TextBlock_Backdrop_UnavailableInCompatibilityMode, TextBlock.TextProperty);
            LanguageWpf.Instance.Register(this, TextBlock_CompatibilityMode, TextBlock.TextProperty);
            LanguageWpf.Instance.Register(this, TextBlock_CompatibilityMode_Description, TextBlock.TextProperty);
            LanguageWpf.Instance.Register(this, TextBlock_Reset, TextBlock.TextProperty);
            LanguageWpf.Instance.Register(this, TextBlock_Reset_Description, TextBlock.TextProperty);

            LanguageWpf.Instance.Register(this, TextBlock_Section_General, TextBlock.TextProperty);
            LanguageWpf.Instance.Register(this, TextBlock_Section_Appearance, TextBlock.TextProperty);
            LanguageWpf.Instance.Register(this, TextBlock_Section_Rendering, TextBlock.TextProperty);
            LanguageWpf.Instance.Register(this, TextBlock_Section_Advanced, TextBlock.TextProperty);

            LanguageWpf.Instance.Register(this, TextBlock_HotkeyCommand_0, TextBlock.TextProperty);
            LanguageWpf.Instance.Register(this, TextBlock_HotkeyCommand_1, TextBlock.TextProperty);
            LanguageWpf.Instance.Register(this, TextBlock_HotkeyCommand_2, TextBlock.TextProperty);
            LanguageWpf.Instance.Register(this, TextBlock_HotkeyCommand_3, TextBlock.TextProperty);
            LanguageWpf.Instance.Register(this, TextBlock_HotkeyCommand_4, TextBlock.TextProperty);
            LanguageWpf.Instance.Register(this, TextBlock_HotkeyCommand_5, TextBlock.TextProperty);
            LanguageWpf.Instance.Register(this, TextBlock_HotkeyCommand_6, TextBlock.TextProperty);
            LanguageWpf.Instance.Register(this, TextBlock_HotkeyCommand_7, TextBlock.TextProperty);
            LanguageWpf.Instance.Register(this, TextBlock_HotkeyCommand_8, TextBlock.TextProperty);
            LanguageWpf.Instance.Register(this, TextBlock_HotkeyCommand_9, TextBlock.TextProperty);
            LanguageWpf.Instance.Register(this, TextBlock_HotkeyCommand_10, TextBlock.TextProperty);
            LanguageWpf.Instance.Register(this, TextBlock_HotkeyCommand_11, TextBlock.TextProperty);
            LanguageWpf.Instance.Register(this, TextBlock_HotkeyCommand_12, TextBlock.TextProperty);
            LanguageWpf.Instance.Register(this, TextBlock_HotkeyCommand_13, TextBlock.TextProperty);
            LanguageWpf.Instance.Register(this, TextBlock_HotkeyCommand_14, TextBlock.TextProperty);
            LanguageWpf.Instance.Register(this, TextBlock_HotkeyCommand_15, TextBlock.TextProperty);
            LanguageWpf.Instance.Register(this, TextBlock_HotkeyCommand_16, TextBlock.TextProperty);
            LanguageWpf.Instance.Register(this, TextBlock_HotkeyCommand_17, TextBlock.TextProperty);
            LanguageWpf.Instance.Register(this, TextBlock_HotkeyCommand_18, TextBlock.TextProperty);
            LanguageWpf.Instance.Register(this, TextBlock_HotkeyCommand_19, TextBlock.TextProperty);
            LanguageWpf.Instance.Register(this, TextBlock_HotkeyCommand_20, TextBlock.TextProperty);
            LanguageWpf.Instance.Register(this, TextBlock_HotkeyCommand_21, TextBlock.TextProperty);
            
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            RegisterLanguage();

            LoadSettings();
        }

        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            LanguageWpf.Instance.UnregisterContainer(this);
        }

        public void LoadSettings()
        {
            isLoading = true;

            TextBlock_Language_Author_Value.Text = LanguageManager.Instance.Current.Author;
            TextBlock_Language_Version_Value.Text = LanguageManager.Instance.Current.LangVersion;

            Slider_RenderScale.Value = GlobalSettings.RenderScale;
         
            ToggleSwitch_TextureOverlay_Enabled.IsOn = GlobalSettings.TextureOverlay;
            PortableColorPicker_TextureOverlay_LineColor.Color.Set(GlobalSettings.DynamicOverlayLineColor);
            NumberBox_TextureOverlay_LineSize.Value = GlobalSettings.DynamicOverlayLineSize;
            PortableColorPicker_PixelGrid_Color.Color.Set(GlobalSettings.DynamicOverlayGridColor);

            ToggleSwitch_PixelGrid_Enabled.IsOn = GlobalSettings.GridEnabled;
            PortableColorPicker_TextureOverlay_TextColor.Color.Set(GlobalSettings.DynamicOverlayTextColor);
            NumberBox_TextureOverlay_TextSize.Value = GlobalSettings.DynamicOverlayTextSize;

            ToggleSwitch_RememberPrefers_Enabled.IsOn = GlobalSettings.RememberPrefers;

            ToggleSwitch_IsManipulationEnabled_Enabled.IsOn=GlobalSettings.IsManipulationEnabled;
            ToggleSwitch_StylusToDraw_Enabled.IsOn = GlobalSettings.StylusToDraw;

            ToggleSwitch_CompatibilityMode_Enabled.IsOn = GlobalSettings.CompatibilityMode;

            isLoading = false;


        }

        #endregion


        #region UI Events
        private void ComboBox_Language_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ComboBox_ThemeMode_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ComboBox_Backdrop_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {


        }

        private void Slider_UIScale_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {


        }

        private void Slider_RenderScale_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            try
            {
                if (!isLoading)
                {
                    GlobalSettings.RenderScale = Slider_RenderScale.Value;

                    if (Program.Editor?.Renderer != null)
                        Program.Editor.Renderer.RenderScale = GlobalSettings.RenderScale;
                }
            }
            catch (Exception ex)
            {
                Program.RaiseException(ex);
            }

        }

        private void ToggleSwitch_TextureOverlay_Enabled_Toggled(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!isLoading)
                {
                    GlobalSettings.TextureOverlay = ToggleSwitch_TextureOverlay_Enabled.IsOn;
                }
            }
            catch (Exception ex)
            {
                Program.RaiseException(ex);
            }

        }

        private void PortableColorPicker_TextureOverlay_LineColor_ColorChanged(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!isLoading)
                {
                    GlobalSettings.DynamicOverlayLineColor = PortableColorPicker_TextureOverlay_LineColor.Color.N2D();
                }
            }
            catch (Exception ex)
            {
                Program.RaiseException(ex);
            }

        }

        private void NumberBox_TextureOverlay_LineSize_ValueChanged(iNKORE.UI.WPF.Modern.Controls.NumberBox sender, iNKORE.UI.WPF.Modern.Controls.NumberBoxValueChangedEventArgs args)
        {
            try
            {
                if (!isLoading)
                {
                    GlobalSettings.DynamicOverlayLineSize = (int)NumberBox_TextureOverlay_LineSize.Value;
                }
            }
            catch (Exception ex)
            {
                Program.RaiseException(ex);
            }

        }

        private void PortableColorPicker_TextureOverlay_TextColor_ColorChanged(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!isLoading)
                {
                    GlobalSettings.DynamicOverlayTextColor = PortableColorPicker_TextureOverlay_TextColor.Color.N2D();
                }
            }
            catch (Exception ex)
            {
                Program.RaiseException(ex);
            }

        }

        private void NumberBox_TextureOverlay_TextSize_ValueChanged(iNKORE.UI.WPF.Modern.Controls.NumberBox sender, iNKORE.UI.WPF.Modern.Controls.NumberBoxValueChangedEventArgs args)
        {
            try
            {
                if (!isLoading)
                {
                    GlobalSettings.DynamicOverlayTextSize = (int)NumberBox_TextureOverlay_TextSize.Value;
                }
            }
            catch (Exception ex)
            {
                Program.RaiseException(ex);
            }

        }

        private void ToggleSwitch_PixelGrid_Enabled_Toggled(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!isLoading)
                {
                    GlobalSettings.GridEnabled = ToggleSwitch_PixelGrid_Enabled.IsOn;
                }
            }
            catch (Exception ex)
            {
                Program.RaiseException(ex);
            }

        }

        private void PortableColorPicker_PixelGrid_Color_ColorChanged(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!isLoading)
                {
                    GlobalSettings.DynamicOverlayGridColor = PortableColorPicker_PixelGrid_Color.Color.N2D();
                }
            }
            catch (Exception ex)
            {
                Program.RaiseException(ex);
            }

        }

        private void ToggleSwitch_RememberPrefers_Enabled_Toggled(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!isLoading)
                {
                    GlobalSettings.RememberPrefers = ToggleSwitch_RememberPrefers_Enabled.IsOn;
                }
            }
            catch (Exception ex)
            {
                Program.RaiseException(ex);
            }

        }
        private void Button_UIScale_Apply_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_OpenKeyEditor_Click(object sender, RoutedEventArgs e)
        {
            Editor._shortcutEditor.ShowDialog();
        }

        #endregion

        private void ToggleSwitch_IsManipulationEnabled_Enabled_Toggled(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!isLoading)
                {
                    GlobalSettings.IsManipulationEnabled = ToggleSwitch_IsManipulationEnabled_Enabled.IsOn;
                }
            }
            catch (Exception ex)
            {
                Program.RaiseException(ex);
            }

        }

        private void ToggleSwitch_StylusToDraw_Enabled_Toggled(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!isLoading)
                {
                    GlobalSettings.StylusToDraw = ToggleSwitch_StylusToDraw_Enabled.IsOn;
                }
            }
            catch (Exception ex)
            {
                Program.RaiseException(ex);
            }

        }

        private void ToggleSwitch_CompatibilityMode_Enabled_Toggled(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!isLoading)
                {
                    GlobalSettings.CompatibilityMode = ToggleSwitch_CompatibilityMode_Enabled.IsOn;
                }

                if (Program.Editor?.IsCompatibilityModeOn != GlobalSettings.CompatibilityMode)
                    Grid_CompatibilityMode_RestartWarning.Visibility = Visibility.Visible;
                else
                    Grid_CompatibilityMode_RestartWarning.Visibility = Visibility.Collapsed;

                //if (GlobalSettings.CompatibilityMode)
                //{
                //    Grid_Backdrop_UnavailableInCompatibilityMode.Visibility = Visibility.Visible;
                //}
                //else
                //{
                //    Grid_Backdrop_UnavailableInCompatibilityMode.Visibility = Visibility.Collapsed;

                //}
            }
            catch (Exception ex)
            {
                Program.RaiseException(ex);
            }


        }

        private async void Button_Reset_Enabled_Click(object sender, RoutedEventArgs e)
        {
            GeneralQuestionDialog dialog = new GeneralQuestionDialog()
            {
                Title = Program.GetLanguageString("M_RESET"),
                Content = Program.GetLanguageString("M_RESETALLSETTINGS_DESCRIPTION"),
                PrimaryButtonText = Program.GetLanguageString("M_RESET"),
                CloseButtonText = Program.GetLanguageString("C_CANCEL"),
                DefaultButton = iNKORE.UI.WPF.Modern.Controls.ContentDialogButton.Close,
            };

            iNKORE.UI.WPF.Modern.Controls.ContentDialogResult result = await dialog.ShowAsync();

            if (result == iNKORE.UI.WPF.Modern.Controls.ContentDialogResult.Primary)
            {
                try
                {
                    Program._saveConfig = false;

                    string config1 = System.IO.Path.Combine(Program.Dir_AssemblyParentCurrent, GlobalSettings.ConfigFilename);
                    string config2 = System.IO.Path.Combine(Program.Dir_AppdataCurrent, GlobalSettings.ConfigFilename);
                    string config3 = System.IO.Path.Combine(Program.Dir_WorkdirCurrent, GlobalSettings.ConfigFilename);

                    if(System.IO.File.Exists(config1))
                    {
                        try { System.IO.File.Delete(config1); }
                        catch (Exception ex) { Program.RaiseException(ex); }
                    }
                    if (System.IO.File.Exists(config2))
                    {
                        try { System.IO.File.Delete(config2); }
                        catch (Exception ex) { Program.RaiseException(ex); }
                    }
                    if (System.IO.File.Exists(config3))
                    {
                        try { System.IO.File.Delete(config3); }
                        catch (Exception ex) { Program.RaiseException(ex); }
                    }

                    Program.Restart();
                }
                catch (Exception ex) { Program.RaiseException(ex); }

            }
        }

        private void HyperlinkButton_ChangeSettings_Language_Click(object sender, RoutedEventArgs e)
        {
            HubStarter.NavigateSettings();
        }
    }
}
