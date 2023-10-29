using XnView.Markirator.Core;
using XnView.Markirator.Core.Common.Tools.OutputWriting;
using XnView.Markirator.Core.UseCases.EvaluateTags;
using XnView.Markirator.Core.UseCases.GetXnViewDbFolder;
using XnView.Markirator.Core.UseCases.InstallDeepDanbooru;
using XnView.Markirator.Core.UseCases.JsonImportTags;
using XnView.Markirator.Core.UseCases.UpdateSettings;
using XnView.Markirator.UI.Tools.OutputWriting;
using Microsoft.WindowsAPICodePack.Dialogs;
using System.ComponentModel;
using System.Diagnostics;
using XnView.Markirator.UI.Tools.Extensions;

namespace XnView.Markirator.UI
{
    public partial class MainForm : Form
    {
        private readonly IMarkiratorService _markiratorService;
        private readonly IOutputWriter _outputWriter;

        public MainForm(IMarkiratorService markiratorService, IOutputWriter outputWriter)
        {
            InitializeComponent();

            _markiratorService = markiratorService;
            _outputWriter = outputWriter;

            // SETUP OUTPUT
            (outputWriter as UiOutputWriter)!.Handler = (entry) =>
            {
                if (statusStrip.InvokeRequired)
                {
                    statusStrip.Invoke((MethodInvoker)delegate
                    {
                        lbProgress.Text = entry.Title;
                    });
                }
                else
                {
                    lbProgress.Text = entry.Title;
                }
            };

            // SETUP DEFAULT VALUES
            {
                var settings = _markiratorService.GetSettings(new GetSettings_Options());
                txtImagePath.Text = settings.XnViewImagesCatalogPath;
                txtXnViewDbFolder.Text = settings.XnViewDbFolder;
                txtXnViewImagesCatalogPath.Text = settings.XnViewImagesCatalogPath;
                lbProgress.Text = String.Empty;
            }
        }

        private void EvaluationBgWorker_RunWorkerCompleted(object? sender, RunWorkerCompletedEventArgs e)
        {
            progressBar1.Style = ProgressBarStyle.Continuous;
            progressBar1.MarqueeAnimationSpeed = 0;
            RefereshOutputView();
        }

        private void RefereshOutputView()
        {
            listViewOutput.Items.Clear();

            var entriesStack = _outputWriter.GetEntriesStack();
            while (entriesStack.Any())
            {
                var entry = entriesStack.Pop();
                var listViewItem = new ListViewItem(entry.Title);
                listViewItem.SubItems.Add(entry.Timestamp.ToString());
                listViewItem.Tag = entry;
                listViewOutput.Items.Add(listViewItem);
            }
        }

        private void EvaluationBgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            string projectPath = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "deepdanbooru-v3-20211112-sgd-e28");

            var options = new EvaluateTags_Options()
            {
                ImagePath = txtImagePath.Text,
                ProjectPath = projectPath,
            };
            _markiratorService.EvaluateTags(options);
        }

        private void BtStartEvaluation_Click(object sender, EventArgs e)
        {
            // TODO: Validate that file or folder existed

            progressBar1.Style = ProgressBarStyle.Marquee;
            progressBar1.MarqueeAnimationSpeed = 300;
            evaluationBgWorker.RunWorkerAsync();
        }

        private void BtInstallDeepDanbooru_Click(object sender, EventArgs e)
        {
            var options = new InstallDeepDanbooru_Options();
            _markiratorService.InstallDeepDanbooru(options);
        }

        private void BtImportTags_Click(object sender, EventArgs e)
        {
            try
            {
                // VALIDATION
                {
                    var settings = _markiratorService.GetSettings(new GetSettings_Options());

                    bool checkXnViewDbFolder =
                        !string.IsNullOrEmpty(settings.XnViewDbFolder) &&
                        File.Exists(settings.XnViewDbFolder);

                    if (!checkXnViewDbFolder)
                    {
                        throw new ApplicationException(
                            "Check that the \"Folder for Catalog\" setting filled correctly");
                    }

                    bool checkXnViewImagesCatalogPath =
                        !string.IsNullOrEmpty(settings.XnViewImagesCatalogPath) &&
                        File.Exists(settings.XnViewDbFolder);

                    if (!checkXnViewImagesCatalogPath)
                    {
                        throw new ApplicationException(
                            "Check that the \"Base path of your pictures\" setting filled correctly");
                    }
                }

                var options = new JsonImportTags_Options()
                {
                    JsonPath = txtImportTagsFile.Text,
                };
                _markiratorService.JsonImportTags(options);
            }
            catch (ApplicationException ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                _outputWriter.WriteLine(0, "Unexpected error", ex.ToString());
                MessageBox.Show(
                    "Unexpected error! Check 'Output' for more details.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }

            RefereshOutputView();
        }

        private void ListViewOutput_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            txtOutputEntry.Text = (e.Item.Tag as OutputEntry)?.Description;
        }

        private void BtOpenTagsFile_Click(object sender, EventArgs e)
        {
            var settings = _markiratorService.GetSettings(new GetSettings_Options());
            var ofd = new OpenFileDialog
            {
                InitialDirectory = settings.EvaluatedTagsFolderPath,
                Filter = "Json files (*.json)|*.json|Text files (*.txt)|*.txt"
            };
            var dlgResult = ofd.ShowDialog();

            if (dlgResult == DialogResult.OK)
            {
                txtImportTagsFile.Text = ofd.FileName;
            }

            lbProgress.Text = String.Empty;
        }

        private void BtSelectFolderForEvaluation_Click(object sender, EventArgs e)
        {
            var settings = _markiratorService.GetSettings(new GetSettings_Options());

            var dialog = new CommonOpenFileDialog
            {
                InitialDirectory = settings.XnViewImagesCatalogPath,
                IsFolderPicker = true,
            };

            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                txtImagePath.Text = dialog.FileName;
            }

            lbProgress.Text = String.Empty;
        }

        private void BtSelectImageForEvaluation_Click(object sender, EventArgs e)
        {
            var settings = _markiratorService.GetSettings(new GetSettings_Options());

            var dialog = new CommonOpenFileDialog
            {
                InitialDirectory = settings.XnViewImagesCatalogPath,
                IsFolderPicker = false,
            };

            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                txtImagePath.Text = dialog.FileName;
            }

            lbProgress.Text = String.Empty;
        }

        // SETTINGS
        private void BtSelectXnViewDb_Click(object sender, EventArgs e)
        {
            var settings = _markiratorService.GetSettings(new GetSettings_Options());

            var dialog = new CommonOpenFileDialog
            {
                InitialDirectory = settings.XnViewDbFolder,
                IsFolderPicker = true,
            };

            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                txtXnViewDbFolder.Text = dialog.FileName;
            }

            lbProgress.Text = String.Empty;
        }
        private void BtSelectXnViewImagesCatalogPath_Click(object sender, EventArgs e)
        {
            var settings = _markiratorService.GetSettings(new GetSettings_Options());

            var dialog = new CommonOpenFileDialog
            {
                InitialDirectory = settings.XnViewImagesCatalogPath,
                IsFolderPicker = true,
            };

            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                txtXnViewImagesCatalogPath.Text = dialog.FileName;
            }

            lbProgress.Text = String.Empty;
        }
        private void BtSaveSettings_Click(object sender, EventArgs e)
        {
            var options = new UpdateSettings_Options(txtXnViewDbFolder.Text, txtXnViewImagesCatalogPath.Text);
            _markiratorService.UpdateSettings(options);
            lbProgress.Text = String.Empty;
        }

        // --- LINKS ---

        private void LinkLabel0_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
            => ProcessExtensions.LaunchBrowser(linkLabel0.Text);

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
            => ProcessExtensions.LaunchBrowser(linkLabel1.Text);

        private void LinkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
            => ProcessExtensions.LaunchBrowser(linkLabel2.Text);

        private void LinkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
            => ProcessExtensions.LaunchBrowser(linkLabel2.Text);
    }
}