using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.Windows;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
//using Autodesk.AutoCAD.Customization;

[assembly: CommandClass(typeof(Sinuosity.Main))]
[assembly: ExtensionApplication(typeof(Sinuosity.Main))]

namespace Sinuosity
{
    using Sinuosity.Common;
    using Sinuosity.Forms;
    
    public class Main : IExtensionApplication
    {

        public void Initialize()
        {
            try
            {
                // Add ribbon button when plugin loads
                CreateProjectRibbonButton();
                Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor.WriteMessage("\nSinuosity Plugin Loaded");
            }
            catch (System.Exception ex)  // Explicitly using System.Exception
            {
                Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor.WriteMessage(
                    $"\nError initializing plugin: {ex.Message}");
            }
        }

        public void Terminate()
        {
            // Cleanup code if needed
        }

        private void CreateProjectRibbonButton()
        {
            RibbonControl ribbon = ComponentManager.Ribbon;
            if (ribbon == null) return;

            // Create or find tab
            RibbonTab tab = null;
            foreach (RibbonTab existingTab in ribbon.Tabs)
            {
                if (existingTab.Id == "Sinuosity_PLUGIN_TAB")
                {
                    tab = existingTab;
                    break;
                }
            }

            if (tab == null)
            {
                tab = new RibbonTab();
                tab.Title = "Sinuosity";
                tab.Id = "Sinuosity_PLUGIN_TAB";
                ribbon.Tabs.Add(tab);
            }

            // Create panel
            RibbonPanelSource panelSource = new RibbonPanelSource();
            panelSource.Title = "Stream Design Tools";
            RibbonPanel panel = new RibbonPanel();
            panel.Source = panelSource;
            tab.Panels.Add(panel);

            // Create button
            RibbonButton button = new RibbonButton();
            button.Text = "Show Form";
            button.ShowText = true;
            button.Size = RibbonItemSize.Large;
            button.Orientation = System.Windows.Controls.Orientation.Vertical;
            button.CommandHandler = new RibbonCommandHandler();
            panelSource.Items.Add(button);

            // Activate the tab - Not needed
            //tab.IsActive = true;
        }

        [CommandMethod("SinuosityOPEN")]
        public static void ShowFormCommand()
        {
            try
            {
                EditorMenu form = new EditorMenu();
                Autodesk.AutoCAD.ApplicationServices.Application.ShowModalDialog(form);
            }
            catch (System.Exception ex)  // Explicitly using System.Exception
            {
                Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor.WriteMessage(
                    $"\nError showing form: {ex.Message}");
            }
        }
        
    }

    public class RibbonCommandHandler : System.Windows.Input.ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            Main.ShowFormCommand();
        }
    }
}