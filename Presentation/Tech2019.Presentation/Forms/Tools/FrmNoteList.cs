using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Tech2019.DataAccessLayer.Context;

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
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            EntityLayer.Concrete.Note note = new EntityLayer.Concrete.Note();
            AssignNoteInfo(note);
            db.Notes.Add(note);
            db.SaveChanges();
            MessageBox.Show("Note Added Successfully", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearNoteInfo();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtNoteId.Text);
            var note = db.Notes.Find(id);
            db.Notes.Remove(note);
            db.SaveChanges();
            MessageBox.Show("Note Deleted", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            ClearNoteInfo();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
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
            ClearNoteInfo();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            NoteList();
            ClearNoteInfo();
        }

        private void gvwReadNotes_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            txtNoteId.Text = gvwReadNotes.GetFocusedRowCellValue("NoteId").ToString();
            txtNoteDescription.Text = gvwReadNotes.GetFocusedRowCellValue("NoteDescription").ToString();
            txtNoteTitle.Text = gvwReadNotes.GetFocusedRowCellValue("NoteTitle").ToString();
            chkNoteStatus.CheckState = (bool)gvwReadNotes.GetFocusedRowCellValue("NoteStatus")
                ? CheckState.Checked
                : CheckState.Unchecked;
        }

        private void gvwUnreadNotes_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            txtNoteId.Text = gvwUnreadNotes.GetFocusedRowCellValue("NoteId").ToString();
            txtNoteDescription.Text = gvwUnreadNotes.GetFocusedRowCellValue("NoteDescription").ToString();
            txtNoteTitle.Text = gvwUnreadNotes.GetFocusedRowCellValue("NoteTitle").ToString();
            chkNoteStatus.CheckState = (bool)gvwUnreadNotes.GetFocusedRowCellValue("NoteStatus")
                ? CheckState.Checked
                : CheckState.Unchecked;
        }

        #region Extracted Methods

        private void NoteList()
        {
            grcUnreadNotesList.DataSource = db.Notes.Where(x => x.NoteStatus == false).ToList();
            grcReadNotesList.DataSource = db.Notes.Where(x => x.NoteStatus == true).ToList();
        }

        private void AssignNoteInfo(EntityLayer.Concrete.Note note)
        {
            note.NoteTitle = txtNoteTitle.Text;
            note.NoteDescription = txtNoteDescription.Text;
            note.NoteStatus = chkNoteStatus.CheckState == CheckState.Checked;
        }

        private void ClearNoteInfo()
        {
            txtNoteTitle.Text = string.Empty;
            txtNoteDescription.Text = string.Empty;
            chkNoteStatus.CheckState = CheckState.Unchecked;
        }

        #endregion
    }
}
