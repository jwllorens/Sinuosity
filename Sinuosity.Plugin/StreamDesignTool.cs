using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.Windows;
using System;
using System.IO;
using System.Windows.Media.Imaging;

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
            RibbonPanelSource smallButtonPanel = new RibbonPanelSource();
            smallButtonPanel.Title = "";
            RibbonPanel panel2 = new RibbonPanel();
            panel2.Source = smallButtonPanel;
            tab.Panels.Add(panel2);

            // Create panel
            RibbonPanelSource panelSource = new RibbonPanelSource();
            panelSource.Title = "Stream Design Tools";
            RibbonPanel panel1 = new RibbonPanel();
            panel1.Source = panelSource;
            tab.Panels.Add(panel1);

            // Create New File button
            RibbonButton newFileButton = new RibbonButton();
            newFileButton.Text = "New File";
            newFileButton.ShowText = true;
            newFileButton.ShowImage = true;
            newFileButton.Size = RibbonItemSize.Standard;
            newFileButton.Orientation = System.Windows.Controls.Orientation.Horizontal;
            newFileButton.Image = LoadPngImage("NewDocument");
            newFileButton.LargeImage = LoadPngImage("NewDocument");
            newFileButton.CommandHandler = new NewFileCommandHandler();
            
            // Create Open File button
            RibbonButton openFileButton = new RibbonButton();
            openFileButton.Text = "Open File";
            openFileButton.ShowText = true;
            openFileButton.ShowImage = true;
            openFileButton.Size = RibbonItemSize.Standard;
            openFileButton.Orientation = System.Windows.Controls.Orientation.Horizontal;
            openFileButton.Image = LoadPngImage("OpenFile");
            openFileButton.LargeImage = LoadPngImage("OpenFile");
            openFileButton.CommandHandler = new OpenFileCommandHandler();
            
            // Create Configuration button
            RibbonButton configButton = new RibbonButton();
            configButton.Text = "Configuration";
            configButton.ShowText = true;
            configButton.ShowImage = true;
            configButton.Size = RibbonItemSize.Standard;
            configButton.Orientation = System.Windows.Controls.Orientation.Horizontal;
            configButton.Image = LoadPngImage("Config");
            configButton.LargeImage = LoadPngImage("Config");
            configButton.CommandHandler = new ConfigCommandHandler();
            
            RibbonRowPanel rowPanel1 = new RibbonRowPanel();
            rowPanel1.Items.Add(newFileButton);
            RibbonRowPanel rowPanel2 = new RibbonRowPanel();
            rowPanel2.Items.Add(openFileButton);
            RibbonRowPanel rowPanel3 = new RibbonRowPanel();
            rowPanel3.Items.Add(configButton);
            smallButtonPanel.Items.Add(rowPanel1);
            smallButtonPanel.Items.Add(new RibbonRowBreak());
            smallButtonPanel.Items.Add(rowPanel2);
            smallButtonPanel.Items.Add(new RibbonRowBreak());
            smallButtonPanel.Items.Add(rowPanel3);
        }

        private BitmapImage LoadPngImage(string resourceName)
        {
            try
            {
                byte[] imageBytes = null;
                // Access image from Resources
                if (resourceName == "NewDocument")
                {
                    imageBytes = SinuosityPlugin.Properties.Resources.Icon_NewDocument;
                }
                else if (resourceName == "OpenFile")
                {
                    imageBytes = SinuosityPlugin.Properties.Resources.Icon_OpenDocument; // Adjust if resource name differs
                }
                else if (resourceName == "Config")
                {
                    imageBytes = SinuosityPlugin.Properties.Resources.Icon_Settings; // Adjust if resource name differs
                }

                if (imageBytes == null)
                {
                    Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor.WriteMessage(
                        $"\nResource {resourceName} not found in Resources");
                    return null;
                }

                // Convert byte[] to BitmapImage
                using (MemoryStream memory = new MemoryStream(imageBytes))
                {
                    BitmapImage bitmapImage = new BitmapImage();
                    bitmapImage.BeginInit();
                    bitmapImage.StreamSource = memory;
                    bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                    bitmapImage.EndInit();
                    bitmapImage.Freeze(); // Freeze to make it cross-thread safe
                    return bitmapImage;
                }
            }
            catch (System.Exception ex)
            {
                Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor.WriteMessage(
                    $"\nError loading image {resourceName}: {ex.Message}");
                return null;
            }
        }

        private void AddShowFormButton()
        {
            RibbonControl ribbon = ComponentManager.Ribbon;
            if (ribbon == null) return;

            // Find the Sinuosity tab
            RibbonTab tab = null;
            foreach (RibbonTab existingTab in ribbon.Tabs)
            {
                if (existingTab.Id == "Sinuosity_PLUGIN_TAB")
                {
                    tab = existingTab;
                    break;
                }
            }

            if (tab == null) return;

            // Find the Stream Design Tools panel
            RibbonPanel panel = null;
            foreach (RibbonPanel existingPanel in tab.Panels)
            {
                if (existingPanel.Source.Title == "Stream Design Tools")
                {
                    panel = existingPanel;
                    break;
                }
            }

            if (panel == null) return;

            // Check if Show Form button already exists to avoid duplicates
            foreach (RibbonItem item in panel.Source.Items)
            {
                if (item is RibbonButton button && button.Text == "Show Form")
                {
                    return; // Button already exists
                }
            }

            // Create Show Form button
            RibbonButton showFormButton = new RibbonButton();
            showFormButton.Text = "Show Form";
            showFormButton.ShowText = true;
            showFormButton.Size = RibbonItemSize.Large;
            showFormButton.Orientation = System.Windows.Controls.Orientation.Vertical;
            showFormButton.CommandHandler = new RibbonCommandHandler();
            panel.Source.Items.Add(showFormButton);
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

        [CommandMethod("SinuosityNEW")]
        public static void NewFileCommand()
        {
            try
            {
                ProjectManager.NewProject(); // Call to create a new project
                // Assuming project creation logic sets ProjectManager.Project
                Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor.WriteMessage(
                    "\nSinuosity: New File");

                // Check if ProjectManager.Project is not null
                if (ProjectManager.Project != null)
                {
                    new Main().AddShowFormButton();
                }
                else
                {
                    Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor.WriteMessage(
                        "\nProjectManager.Project is null, Show Form button not added");
                }
            }
            catch (System.Exception ex)
            {
                Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor.WriteMessage(
                    $"\nError in New File command: {ex.Message}");
            }
        }

        [CommandMethod("SinuosityOPENFILE")]
        public static void OpenFileCommand()
        {
            try
            {
                ProjectManager.OpenProject(); // Call to open an existing project
                // Assuming project loading logic sets ProjectManager.Project
                Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor.WriteMessage(
                    "\nOpen File command executed");

                // Check if ProjectManager.Project is not null
                if (ProjectManager.Project != null)
                {
                    new Main().AddShowFormButton();
                    Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor.WriteMessage(
                        "\nShow Form button added to ribbon");
                }
                else
                {
                    Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor.WriteMessage(
                        "\nProjectManager.Project is null, Show Form button not added");
                }
            }
            catch (System.Exception ex)
            {
                Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor.WriteMessage(
                    $"\nError in Open File command: {ex.Message}");
            }
        }

        [CommandMethod("SinuosityCONFIG")]
        public static void ConfigCommand()
        {
            try
            {
                // Implement Configuration logic here
                Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor.WriteMessage(
                    "\nConfiguration command executed");
            }
            catch (System.Exception ex)
            {
                Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor.WriteMessage(
                    $"\nError in Configuration command: {ex.Message}");
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

    public class NewFileCommandHandler : System.Windows.Input.ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            Main.NewFileCommand();
        }
    }

    public class OpenFileCommandHandler : System.Windows.Input.ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            Main.OpenFileCommand();
        }
    }

    public class ConfigCommandHandler : System.Windows.Input.ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            Main.ConfigCommand();
        }
    }
}