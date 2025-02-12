using System;
using System.Windows.Forms;
using Tech2019.BusinessLayer.AbstractServices;
using Tech2019.EntityLayer.Concrete;
using Tech2019.EntityLayer.Enum;

namespace Tech2019.Presentation.Forms.Tools
{
    public partial class FrmNoteList : Form
    {
        private readonly INoteService _noteService;
        public FrmNoteList(INoteService noteService)
        {
            _noteService = noteService;
            InitializeComponent();
        }

        private void FrmNoteList_Load(object sender, EventArgs e)
        {
            LoadNoteList();
            ClearNoteInfo();
            gvwUnreadNotes.OptionsBehavior.Editable = false;
            gvwReadNotes.OptionsBehavior.Editable = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateNoteInfo())
                return;

            Note note = new Note();
            AssignNoteInfo(note);
            _noteService.Create(note);
            MessageBox.Show("Note Added Successfully", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadNoteList();
            ClearNoteInfo();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!ValidateNoteId())
                return;

            int id = int.Parse(txtNoteId.Text);
            var note = _noteService.GetById(id);
            _noteService.Delete(note);
            MessageBox.Show("Note Deleted", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            LoadNoteList();
            ClearNoteInfo();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!ValidateNoteId())
                return;

            if (!ValidateNoteInfo())
                return;

            int id = int.Parse(txtNoteId.Text);
            var note = _noteService.GetById(id);
            AssignNoteInfo(note);
            _noteService.Update(note);
            MessageBox.Show("Note Updated", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadNoteList();
            ClearNoteInfo();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadNoteList();
            ClearNoteInfo();
        }

        private void gvwReadNotes_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            txtNoteId.Text = gvwReadNotes.GetFocusedRowCellValue("NoteId")?.ToString();
            txtNoteTitle.Text = gvwReadNotes.GetFocusedRowCellValue("NoteTitle")?.ToString();
            txtNoteDescription.Text = gvwReadNotes.GetFocusedRowCellValue("NoteDescription")?.ToString();
            txtDueDate.Text = gvwReadNotes.GetFocusedRowCellValue("DueDate")?.ToString();
            chkNoteStatus.CheckState = gvwReadNotes.GetFocusedRowCellValue("NoteStatus")?.ToString() == "Read"
                ? CheckState.Checked
                : CheckState.Unchecked;
        }

        private void gvwUnreadNotes_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            txtNoteId.Text = gvwUnreadNotes.GetFocusedRowCellValue("NoteId")?.ToString();
            txtNoteTitle.Text = gvwUnreadNotes.GetFocusedRowCellValue("NoteTitle")?.ToString();
            txtNoteDescription.Text = gvwUnreadNotes.GetFocusedRowCellValue("NoteDescription")?.ToString();
            txtDueDate.Text = gvwReadNotes.GetFocusedRowCellValue("DueDate")?.ToString();
            chkNoteStatus.CheckState = gvwUnreadNotes.GetFocusedRowCellValue("NoteStatus")?.ToString() == "Read"
                ? CheckState.Checked
                : CheckState.Unchecked;
        }

        #region Extracted Methods

        private void LoadNoteList()
        {
            grcUnreadNotesList.DataSource = _noteService.GetUnreadNotes();
            grcReadNotesList.DataSource = _noteService.GetReadNotes();
        }

        private void AssignNoteInfo(Note note)
        {
            note.NoteTitle = txtNoteTitle.Text;
            note.NoteDescription = txtNoteDescription.Text;
            note.NoteStatus = chkNoteStatus.CheckState == CheckState.Checked ? NoteStatus.Read : NoteStatus.Unread;
            note.DueDate = DateTime.Parse(txtDueDate.Text);
        }

        private void ClearNoteInfo()
        {
            txtNoteId.Text = string.Empty;
            txtNoteTitle.Text = string.Empty;
            txtNoteDescription.Text = string.Empty;
            txtDueDate.Text = string.Empty;
            chkNoteStatus.CheckState = CheckState.Unchecked;
        }

        private bool ValidateNoteInfo()
        {
            if (string.IsNullOrWhiteSpace(txtNoteTitle.Text))
            {
                MessageBox.Show("Note title cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtDueDate.Text) || !DateTime.TryParse(txtDueDate.Text, out _))
            {
                MessageBox.Show("Please provide a valid date in dd-MM-yyyy format.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtNoteDescription.Text))
            {
                MessageBox.Show("Note description cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private bool ValidateNoteId()
        {
            if (string.IsNullOrWhiteSpace(txtNoteId.Text))
            {
                MessageBox.Show("Note ID cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (!int.TryParse(txtNoteId.Text, out _))
            {
                MessageBox.Show("Note ID must be a valid number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        #endregion
    }
}
