﻿using iNKORE.Coreworks.Localization;
using MCSkinn.Scripts.Models;
using MCSkinn.Scripts.Swatches;
using MCSkinn.Scripts;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.IO;
using System.Windows.Media.Animation;
using iNKORE.Hub.Shared;

namespace MCSkinn.Pages
{
    /// <summary>
    /// PageSplash.xaml 的交互逻辑
    /// </summary>
    public partial class PageSplash : Page
    {
        static Thread _loaderThread;
        public PageSplash()
        {
            InitializeComponent();

            if (GlobalSettings.CompatibilityMode)
                Border_AppTitlebar.Visibility = Visibility.Collapsed;
        }
        public static string LoadingValue = "(nothing?)";

        public void SetLoadingString(string s)
        {
            LoadingValue = s;

            this.Dispatcher.Invoke(new Action(() =>
            {
                TextBlock_Status.Text = s;
            }));


        }

        Language LoadLanguages()
        {
            LanguageManager.Instance.LoadLanguages(GlobalSettings.FullPath_Languages);

            Language useLanguage = null;
            try
            {
                useLanguage = LanguageManager.Instance.FindLanguage(Program.Settings_Shared.Language);

                // stage 1 (prelim): if no language, see if our languages contain it
                if (string.IsNullOrEmpty(Program.Settings_Shared.Language))
                {
                    useLanguage = LanguageManager.Instance.FindLanguage(CultureInfo.CurrentUICulture.Name);

                    if(useLanguage == null && !CultureInfo.CurrentUICulture.IsNeutralCulture)
                        useLanguage = LanguageManager.Instance.FindLanguage(CultureInfo.CurrentUICulture.Parent?.Name);
                }

                // stage 3: use English file, if it exists
                if (useLanguage == null)
                    useLanguage = LanguageManager.Instance.FindLanguage("en-us");
            }
            catch(Exception ex)
            {
                Program.Log(ex, true);
            }
            finally
            {
                //stage 4: fallback to built -in English file
                if (useLanguage == null)
                {
                    //Program.Context.SplashForm.Dispatcher.Invoke((Action)(() => MessageBox.Show(this, "For some reason, the default language files were missing or failed to load (did you extract?) - we'll supply you with a base language of English just so you know what you're doing!")));
                    useLanguage = LoadDefault();
                }
            }

            return useLanguage;
        }
        public static Language LoadDefault()
        {
            using (var reader = new StreamReader(new MemoryStream(Properties.Resources.English), Encoding.Unicode))
            {
                Language lang = iNKORE.Coreworks.Localization.Language.Parse(reader, "en-us.lang");
                LanguageManager.Instance.Languages.Add(lang);
                return lang;
            }
        }

        Action ErrorHandlerWrap(Action a)
        {
            return () =>
            {
                try
                {
                    a();
                }
                catch (Exception ex)
                {
                    if (ex is TaskCanceledException)
                        return;

                    Program.RaiseException(ex);
                }
            };
        }

        private void PerformLoading()
        {
            if (!Directory.Exists(InkoreStudios.Path_InkoreBaseDirectory) && !Program.IsDebugVersion)
            {
                MessageBox.Show("Invalid iNKORE Hub installation. Please check your installment.\r\n\r\n无效的 iNKORE Hub，请检查你的安装。");
                Environment.Exit(-5);
            }

            SetLoadingString("Loading Languages...");

            Program.Log(iNKORE.Coreworks.LogType.Info, "Loading languages from directory: " + GlobalSettings.FullPath_Languages, "PageSplash.PerformLoading()");

            var language = LoadLanguages();

            SetLoadingString("Initializing base forms...");

            Program.Page_Splash.Dispatcher.Invoke(ErrorHandlerWrap(() =>
            {
                Program.CurrentLanguage = language;

                Program.Editor.Initialize(language);
                Program.Page_Editor.RegisterLanguage();
                //LanguageWpf.Instance.Refresh();

            }));


            SetLoadingString("Loading swatches...");

            SwatchLoader.LoadSwatches();
            Program.Page_Splash.Dispatcher.Invoke(ErrorHandlerWrap(SwatchLoader.FinishedLoadingSwatches));

            SetLoadingString("Loading models...");

            Program.Log(iNKORE.Coreworks.LogType.Info, "Loading languages from directory: " + GlobalSettings.FullPath_Models, "PageSplash.PerformLoading()");

            ModelLoader.LoadModels();
            Program.Page_Splash.Dispatcher.Invoke(ErrorHandlerWrap(Program.Editor.FinishedLoadingModels));

            SetLoadingString("Loading skins...");

            SkinLoader.LoadSkins();

            Program.Page_Splash.Dispatcher.Invoke(ErrorHandlerWrap(Program.Context.DoneLoadingSplash));

            this.Dispatcher.Invoke(ErrorHandlerWrap(() =>
            {
                //Program.Context.SplashForm.Close();
                GC.Collect();
            }));

            new Thread(() =>
            {
                try
                {
                    iNKORE.Hub.Shared.UpdateHelper.CheckUpdate(Program.ProductID, true);
                }
                catch { }
            })
            { IsBackground = true, Name = "UpdateChecker" }.Start();
        }

        public static void BeginLoaderThread()
        {
            _loaderThread = new Thread(Program.Page_Splash.PerformLoading);
            _loaderThread.Start();
        }

        public void ShowFirstTimeWelcome()
        {

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            TextBlock_Version.Text = Program.Name + " v" + Program.Version.ToString();
            SetLoadingString("Doing nothing yet...");

            _loaderThread = new Thread(Program.Page_Splash.PerformLoading);
            _loaderThread.Start();

        }
    }
}
