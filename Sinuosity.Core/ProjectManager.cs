using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Sinuosity
{
    public static class ProjectManager
    {

        public static Xmanager Project { get; set; }
        public static Xmanager Configuration { get; }
        public static Xmanager RegionalCurves { get; }
        static ProjectManager()
        {
            string configFilePath = Path.Combine(Path.GetDirectoryName(typeof(GDALclient).Assembly.Location), "Configuration.xml");
            Configuration = new Xmanager(0, "Configuration");
            bool loadSuccess = Configuration.SilentLoad(configFilePath);
            if (!loadSuccess)
            {
                Configuration.New("Configuration");
                foreach (KeyValuePair<string, object> kvp in DefaultConfiguration.Values)
                {
                    Configuration.SetValue((string)kvp.Value, kvp.Key);
                }
                bool saveSuccess = Configuration.SilentSaveAs(configFilePath);
                if (!saveSuccess)
                    MessageBox.Show("Save Config File Failed");
            }
        }
        public static bool NewProject()
        {
            if (Project != null) // Check if there's an existing project
            {
                DialogResult saveResult = MessageBox.Show(
                    "Do you want to save the current project before creating a new one?",
                    "Save Current Project",
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Question);

                if (saveResult == DialogResult.Cancel)
                    return false; // User canceled, exit

                if (saveResult == DialogResult.Yes)
                {
                    try
                    {
                        bool saveSuccess = Project.SaveFile();
                        if (!saveSuccess)
                            return false; // Save failed, exit
                    }
                    catch (System.Exception ex)
                    {
                        MessageBox.Show($"Error saving current project: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false; // Exit if save fails
                    }
                }
            }
            string projectName = Sinuosity.Common.Utilities.PromptForString("Enter a project name:"); // Prompt for new project name
            if (string.IsNullOrWhiteSpace(projectName))
                return false; // User canceled or entered nothing
            Project = null; // Reset and create new Xmanager
            Project = new Xmanager(100, "Project");
            Project.New(projectName);
            Project.SetAttribute("formClass", "Project", "");
            Project.Sprout(new TS_ProjectStreams(), "");
            Project.Sprout(new TS_ProjectInfo(), "");
            try
            {
                bool saveSuccess = Project.SaveFile(true);
                if (!saveSuccess)
                {
                    Project = null;
                    return false; // user calceled, exit
                }
                return true;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show($"Error creating new project: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Project = null; // Reset on failure
                return false;
            }
        }
        public static bool OpenProject()
        {
            if (Project != null) // Check if there's an existing project
            {
                DialogResult saveResult = MessageBox.Show(
                    "Do you want to save the current project before creating a new one?",
                    "Save Current Project",
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Question);

                if (saveResult == DialogResult.Cancel)
                    return false; // User canceled, exit

                if (saveResult == DialogResult.Yes)
                {
                    try
                    {
                        Project.SaveFile();
                    }
                    catch (System.Exception ex)
                    {
                        MessageBox.Show($"Error saving current project: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false; // Exit if save fails
                    }
                }
            }
            bool projectFileWasActive; //Due to Xmanager initializing with a root node, we need to check if it is null first
            if (Project == null)
            {
                projectFileWasActive = false;
                Project = new Xmanager(100, "Project"); //Xmanager needs to be initialized before calling XMLload.  May change this in the future. 
            }
            else
                projectFileWasActive = true;

            try
            {
                bool loadSuccess = Project.LoadFile();
                if (loadSuccess)
                {
                    MessageBox.Show($"Project loaded from '{Project.GetAttribute("filePath", "")}'", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (!projectFileWasActive) //Should be triggered if the user exits the "load" OFD and the initialized Xmanager instance is just a placeholder.  
                        Project = null; //Destroy the Xmanager so that we don't get promted to save it if we try again to open a file
                    return false; //failed to load, exit
                }
                return true; //success, exit
            }
            catch (System.Exception ex)
            {
                MessageBox.Show($"Error loading project: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Project = null;
                return false; //some sort of error when loading, exit
            }
        }
        public static void SaveProject()
        {
            if (Project != null)
                Project.SaveFile();
            else
            {
                MessageBox.Show("No project file loaded.  Please load a project file or create a new project file before saving.");
            }
        }
        public static void SaveProjectAs()
        {
            if (Project != null)
                Project.SaveFile(true);
            else
            {
                MessageBox.Show("No project file loaded.  Please load a project file or create a new project file before saving.");
            }
        }
    }
}
