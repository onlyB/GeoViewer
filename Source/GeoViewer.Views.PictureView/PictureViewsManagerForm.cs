using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Objects;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GeoViewer.Business;
using GeoViewer.Models;
using GeoViewer.Utils;
using GeoViewer.Views.PictureView.Properties;

namespace GeoViewer.Views.PictureView
{
    public partial class PictureViewsManagerForm : BaseWindowForm
    {
        private int _addEditState = 0;
        private Models.PictureView _editingPictureView = null;

        #region private methods
        public PictureViewsManagerForm()
        {
            InitializeComponent();
            LoadPictures();
        }

        private void LoadPictures()
        {
            try
            {
                pictureDataGrid.DataSource = entityConntext.PictureViews.Where(ent => ent.ProjectID == AppContext.Current.OpenProject.ProjectID).Select(ent => new { ent.PictureViewID, ent.Name, ent.Description, ent.CreatedDate, ent.CreatedUser, ent.LastEditedDate, ent.LastEditedUser }).ToList();
            }
            catch (Exception exception)
            {
                ShowErrorMessage(exception.Message);
            }
        }

        private void prepareToAdd()
        {
            _addEditState = 0;
            _editingPictureView = null;

            nameTextBox.Focus();
            addEditBox.Enabled = true;
            nameTextBox.Text = descriptionTextBox.Text = "";
        }

        private void prepareToEdit()
        {
            if (pictureDataGrid.SelectedRows.Count == 0)
            {
                ShowWarningMessage(Resources.Warning_NoRecordSelected);
                return;
            }
            _editingPictureView = PictureViewBLL.Current.GetByID(pictureDataGrid.SelectedRows[0].Cells["PictureViewID"].Value.ToInt32TryParse());
            if (_editingPictureView != null)
            {
                _addEditState = 1;
                addEditBox.Enabled = true;

                nameTextBox.Focus();
                nameTextBox.Text = _editingPictureView.Name;
                descriptionTextBox.Text = _editingPictureView.Description;
            }
        }

        private void viewPicture()
        {
            try
            {
                if (pictureDataGrid.SelectedRows.Count > 0)
                {
                    // Get picture ID where clicked
                    int pictureId = pictureDataGrid.SelectedRows[0].Cells["PictureViewID"].Value.ToInt32TryParse();
                    var pictureView = PictureViewBLL.Current.GetByID(pictureId);
                    // Open picture
                    PictureViewDetailForm f = new PictureViewDetailForm(pictureView);

                    f.Show();

                }
            }
            catch (Exception exception)
            {
                ShowErrorMessage(exception.Message);
            }
        }

        private void addEdit()
        {
            try
            {
                if (_addEditState == 0 || _editingPictureView == null)
                {
                    _editingPictureView = new Models.PictureView();
                }

                _editingPictureView.Name = nameTextBox.Text;
                _editingPictureView.Description = descriptionTextBox.Text;

                if (_addEditState == 0)
                {
                    if (PictureViewBLL.Current.Insert(_editingPictureView))
                    {
                        ShowSuccessMessage(Resources.Message_AddPictureViewSuccess);
                    }
                    prepareToAdd();
                }
                else if (_addEditState == 1)
                {
                    if (PictureViewBLL.Current.Update(_editingPictureView))
                    {
                        ShowSuccessMessage(Resources.Message_EditPictureViewSuccess);
                    }
                }
                LoadPictures();
            }
            catch (Exception exception)
            {
                ShowErrorMessage(exception.Message);
                //if (_addEditState == 1)
                //    entityConntext.Refresh(RefreshMode.StoreWins, _editingPictureView);
            }
        }
        #endregion

        #region private event
        private void newPictureButton_Click(object sender, EventArgs e)
        {
            try
            {
                prepareToAdd();
            }
            catch (Exception exception)
            {
                ShowErrorMessage(exception.Message);
            }
        }

        private void pictureDataGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            viewPicture();
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            prepareToEdit();
        }


        private void deleteButton_Click(object sender, EventArgs e)
        {

            if (pictureDataGrid.SelectedRows.Count == 0)
            {
                ShowWarningMessage(Resources.Warning_NoRecordSelected);
                return;
            }
            var id = pictureDataGrid.SelectedRows[0].Cells["PictureViewID"].Value.ToInt32TryParse();
            if (ShowConfirmMessage(string.Format(Resources.Confirm_DeletePictureView, id)) == DialogResult.OK)
            {
                try
                {
                    if (PictureViewBLL.Current.Delete(id))
                    {
                        ShowSuccessMessage(Resources.Message_DeletePcitureViewSuccess);
                        prepareToAdd();
                        LoadPictures();
                    }
                }
                catch (Exception exception)
                {
                    ShowErrorMessage(exception.Message);
                }
            }
        }

        private void reloadButton_Click(object sender, EventArgs e)
        {
            LoadPictures();
        }

        private void viewButton_Click(object sender, EventArgs e)
        {
            viewPicture();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            addEdit();
        }
        #endregion

        private void PictureViewsManagerForm_Load(object sender, EventArgs e)
        {
            CheckRoleForView(SecurityBLL.ROLE_VIEWS_VIEW);

        }
    }
}
