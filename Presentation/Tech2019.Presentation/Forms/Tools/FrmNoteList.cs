using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Tech2019.DataAccessLayer.Context;
using Tech2019.EntityLayer.Enum;

namespace Tech2019.Presentation.Forms.Tools
{
    public partial class FrmNoteList : Form
    {
        public FrmNoteList()
        {
            InitializeComponent();
        }

        TechDBContext db = new TechDBContext();

        private void FrmNoteList_Load(object sender, EventArgs e)
        {
            NoteList();
            ClearNoteInfo();

            // Unread Notes GridView
            gvwUnreadNotes.Columns["NoteStatus"].OptionsColumn.AllowEdit = false;
            gvwUnreadNotes.Columns["NoteStatus"].OptionsColumn.AllowFocus = false;

            // Read Notes GridView
            gvwReadNotes.Columns["NoteStatus"].OptionsColumn.AllowEdit = false;
            gvwReadNotes.Columns["NoteStatus"].OptionsColumn.AllowFocus = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateNoteInfo())
                return;

            EntityLayer.Concrete.Note note = new EntityLayer.Concrete.Note();
            AssignNoteInfo(note);
            db.Notes.Add(note);
            db.SaveChanges();
            MessageBox.Show("Note Added Successfully", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            NoteList();
            ClearNoteInfo();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!ValidateNoteId())
                return;

            int id = int.Parse(txtNoteId.Text);
            var note = db.Notes.Find(id);
            db.Notes.Remove(note);
            db.SaveChanges();
            MessageBox.Show("Note Deleted", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            NoteList();
            ClearNoteInfo();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!ValidateNoteId())
                return;

            if (!ValidateNoteInfo())
                return;

            int id = int.Parse(txtNoteId.Text);
            var note = db.Notes.Find(id);

            if (note != null)
            {
                AssignNoteInfo(note);
                db.SaveChanges();
                MessageBox.Show("Note Updated", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Note Not Found", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            NoteList();
            ClearNoteInfo();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            NoteList();
            ClearNoteInfo();
        }

        private void gvwReadNotes_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gvwReadNotes.GetFocusedRowCellValue("NoteStatus") != null)
            {
                chkNoteStatus.CheckState = gvwReadNotes.GetFocusedRowCellValue("NoteStatus").ToString() == "Read"
                    ? CheckState.Checked
                    : CheckState.Unchecked;
            }
            txtNoteId.Text = gvwReadNotes.GetFocusedRowCellValue("NoteId")?.ToString();
            txtNoteTitle.Text = gvwReadNotes.GetFocusedRowCellValue("NoteTitle")?.ToString();
            txtNoteDescription.Text = gvwReadNotes.GetFocusedRowCellValue("NoteDescription")?.ToString();
        }

        private void gvwUnreadNotes_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gvwUnreadNotes.GetFocusedRowCellValue("NoteStatus") != null)
            {
                chkNoteStatus.CheckState = gvwUnreadNotes.GetFocusedRowCellValue("NoteStatus").ToString() == "Read"
                    ? CheckState.Checked
                    : CheckState.Unchecked;
            }
            txtNoteId.Text = gvwUnreadNotes.GetFocusedRowCellValue("NoteId")?.ToString();
            txtNoteTitle.Text = gvwUnreadNotes.GetFocusedRowCellValue("NoteTitle")?.ToString();
            txtNoteDescription.Text = gvwUnreadNotes.GetFocusedRowCellValue("NoteDescription")?.ToString();
        }


        #region Extracted Methods

        private void NoteList()
        {
            grcUnreadNotesList.DataSource = db.Notes
                .Where(x => x.NoteStatus == NoteStatus.Unread)
                .Select(x => new
                {
                    x.NoteId,
                    x.NoteTitle,
                    x.NoteDescription,
                    //NoteStatus = x.NoteStatus ? x.NoteStatus == NoteStatus.Read : x.NoteStatus == NoteStatus.Unread
                }).ToList();

            grcReadNotesList.DataSource = db.Notes
                .Where(x => x.NoteStatus == NoteStatus.Read)
                .Select(x => new
                {
                    x.NoteId,
                    x.NoteTitle,
                    x.NoteDescription,
                    //NoteStatus = x.NoteStatus ? "Read" : "Unread"
                }).ToList();
        }


        private void AssignNoteInfo(EntityLayer.Concrete.Note note)
        {
            note.NoteTitle = txtNoteTitle.Text;
            note.NoteDescription = txtNoteDescription.Text;
            //note.NoteStatus = chkNoteStatus.CheckState == CheckState.Checked;
        }

        private void ClearNoteInfo()
        {
            txtNoteTitle.Text = string.Empty;
            txtNoteDescription.Text = string.Empty;
            chkNoteStatus.CheckState = CheckState.Unchecked;
        }

        private bool ValidateNoteInfo()
        {
            if (string.IsNullOrWhiteSpace(txtNoteTitle.Text))
            {
                MessageBox.Show("Note title cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
