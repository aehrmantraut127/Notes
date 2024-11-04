
using System.Collections.Generic;

namespace Notes
{
    partial class NewNoteForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewNoteForm));
            this.fluentDesignFormContainer1 = new DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormContainer();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.txtMessage = new DevExpress.XtraRichEdit.RichEditControl();
            this.fluentFormDefaultManager1 = new DevExpress.XtraBars.FluentDesignSystem.FluentFormDefaultManager(this.components);
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.btnDelete = new DevExpress.XtraBars.BarButtonItem();
            this.btnHelp = new DevExpress.XtraBars.BarButtonItem();
            this.btnUpdateNote = new DevExpress.XtraBars.BarButtonItem();
            this.skinDropDownButtonItem1 = new DevExpress.XtraBars.SkinDropDownButtonItem();
            this.btnNewNote = new DevExpress.XtraBars.BarButtonItem();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.lblDate = new DevExpress.XtraEditors.LabelControl();
            this.btnComplete = new DevExpress.XtraEditors.SimpleButton();
            this.txtTitle = new DevExpress.XtraEditors.TextEdit();
            this.accordionCtlNotes = new DevExpress.XtraBars.Navigation.AccordionControl();
            this.accordionControlElementNewNote = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.mnuNotebook = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuNewNotebook = new System.Windows.Forms.ToolStripMenuItem();
            this.txtNewNotebook = new System.Windows.Forms.ToolStripTextBox();
            this.mnuDeleteNotebook = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuUpdateNotebook = new System.Windows.Forms.ToolStripMenuItem();
            this.txtUpdateNotebook = new System.Windows.Forms.ToolStripTextBox();
            this.notebookModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.fluentDesignFormControl1 = new DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.mnuNote = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuNewNote = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDeleteNote = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuArchiveNote = new System.Windows.Forms.ToolStripMenuItem();
            this.fluentDesignFormContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fluentFormDefaultManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTitle.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.accordionCtlNotes)).BeginInit();
            this.mnuNotebook.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.notebookModelBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fluentDesignFormControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            this.mnuNote.SuspendLayout();
            this.SuspendLayout();
            // 
            // fluentDesignFormContainer1
            // 
            this.fluentDesignFormContainer1.Controls.Add(this.panelControl2);
            this.fluentDesignFormContainer1.Controls.Add(this.panelControl1);
            this.fluentDesignFormContainer1.Controls.Add(this.accordionCtlNotes);
            this.fluentDesignFormContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fluentDesignFormContainer1.Location = new System.Drawing.Point(0, 31);
            this.fluentDesignFormContainer1.Name = "fluentDesignFormContainer1";
            this.fluentDesignFormContainer1.Size = new System.Drawing.Size(1117, 583);
            this.fluentDesignFormContainer1.TabIndex = 0;
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.txtMessage);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(250, 58);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Padding = new System.Windows.Forms.Padding(10);
            this.panelControl2.Size = new System.Drawing.Size(867, 525);
            this.panelControl2.TabIndex = 3;
            // 
            // txtMessage
            // 
            this.txtMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMessage.Location = new System.Drawing.Point(12, 12);
            this.txtMessage.MenuManager = this.fluentFormDefaultManager1;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Options.DocumentSaveOptions.CurrentFormat = DevExpress.XtraRichEdit.DocumentFormat.PlainText;
            this.txtMessage.Size = new System.Drawing.Size(843, 501);
            this.txtMessage.TabIndex = 0;
            // 
            // fluentFormDefaultManager1
            // 
            this.fluentFormDefaultManager1.Form = this;
            this.fluentFormDefaultManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barButtonItem1,
            this.btnDelete,
            this.btnHelp,
            this.btnUpdateNote,
            this.skinDropDownButtonItem1,
            this.btnNewNote});
            this.fluentFormDefaultManager1.MaxItemId = 7;
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "New";
            this.barButtonItem1.Id = 0;
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // btnDelete
            // 
            this.btnDelete.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.btnDelete.Border = DevExpress.XtraEditors.Controls.BorderStyles.Default;
            this.btnDelete.Caption = "Delete Current Note";
            this.btnDelete.Id = 1;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDelete_ItemClick);
            // 
            // btnHelp
            // 
            this.btnHelp.Caption = "Help";
            this.btnHelp.Id = 2;
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnHelp_ItemClick);
            // 
            // btnUpdateNote
            // 
            this.btnUpdateNote.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.btnUpdateNote.Caption = "Update Current Note";
            this.btnUpdateNote.Id = 4;
            this.btnUpdateNote.Name = "btnUpdateNote";
            this.btnUpdateNote.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnUpdateNote_ItemClick);
            // 
            // skinDropDownButtonItem1
            // 
            this.skinDropDownButtonItem1.Id = 5;
            this.skinDropDownButtonItem1.Name = "skinDropDownButtonItem1";
            // 
            // btnNewNote
            // 
            this.btnNewNote.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.btnNewNote.Caption = "Start New Note";
            this.btnNewNote.Id = 6;
            this.btnNewNote.Name = "btnNewNote";
            this.btnNewNote.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnNewNote_ItemClick);
            // 
            // panelControl1
            // 
            this.panelControl1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelControl1.Controls.Add(this.panelControl3);
            this.panelControl1.Controls.Add(this.btnComplete);
            this.panelControl1.Controls.Add(this.txtTitle);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(250, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Padding = new System.Windows.Forms.Padding(10);
            this.panelControl1.Size = new System.Drawing.Size(867, 58);
            this.panelControl1.TabIndex = 2;
            // 
            // panelControl3
            // 
            this.panelControl3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl3.Controls.Add(this.lblDate);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelControl3.Location = new System.Drawing.Point(673, 12);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(82, 34);
            this.panelControl3.TabIndex = 2;
            // 
            // lblDate
            // 
            this.lblDate.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblDate.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lblDate.Appearance.Options.UseFont = true;
            this.lblDate.Location = new System.Drawing.Point(3, 8);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(66, 16);
            this.lblDate.TabIndex = 0;
            this.lblDate.Text = "2024-06-07";
            // 
            // btnComplete
            // 
            this.btnComplete.AutoSize = true;
            this.btnComplete.AutoWidthInLayoutControl = true;
            this.btnComplete.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnComplete.Location = new System.Drawing.Point(755, 12);
            this.btnComplete.MaximumSize = new System.Drawing.Size(100, 32);
            this.btnComplete.MinimumSize = new System.Drawing.Size(100, 32);
            this.btnComplete.Name = "btnComplete";
            this.btnComplete.Size = new System.Drawing.Size(100, 32);
            this.btnComplete.TabIndex = 1;
            this.btnComplete.Text = "Add New Note";
            this.btnComplete.Click += new System.EventHandler(this.btnComplete_Click);
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(12, 12);
            this.txtTitle.MenuManager = this.fluentFormDefaultManager1;
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 16F);
            this.txtTitle.Properties.Appearance.Options.UseFont = true;
            this.txtTitle.Size = new System.Drawing.Size(655, 32);
            this.txtTitle.TabIndex = 0;
            // 
            // accordionCtlNotes
            // 
            this.accordionCtlNotes.AllowDrop = true;
            this.accordionCtlNotes.AllowElementDragging = true;
            this.accordionCtlNotes.Dock = System.Windows.Forms.DockStyle.Left;
            this.accordionCtlNotes.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.accordionControlElementNewNote});
            this.accordionCtlNotes.Location = new System.Drawing.Point(0, 0);
            this.accordionCtlNotes.Name = "accordionCtlNotes";
            this.accordionCtlNotes.ScrollBarMode = DevExpress.XtraBars.Navigation.ScrollBarMode.AutoCollapse;
            this.accordionCtlNotes.ShowFilterControl = DevExpress.XtraBars.Navigation.ShowFilterControl.Always;
            this.accordionCtlNotes.Size = new System.Drawing.Size(250, 583);
            this.accordionCtlNotes.TabIndex = 1;
            this.accordionCtlNotes.ViewType = DevExpress.XtraBars.Navigation.AccordionControlViewType.HamburgerMenu;
            this.accordionCtlNotes.FilterContent += new DevExpress.XtraBars.Navigation.FilterContentEventHandler(this.accordionCtlNotes_FilterContent);
            this.accordionCtlNotes.DragDrop += new System.Windows.Forms.DragEventHandler(this.accordionCtlNotes_DragDrop);
            this.accordionCtlNotes.MouseClick += new System.Windows.Forms.MouseEventHandler(this.accordionCtlNotes_MouseClick);
            // 
            // accordionControlElementNewNote
            // 
            this.accordionControlElementNewNote.Appearance.Default.Font = new System.Drawing.Font("Tahoma", 12F);
            this.accordionControlElementNewNote.Appearance.Default.Options.UseFont = true;
            this.accordionControlElementNewNote.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("accordionControlElementNewNote.ImageOptions.Image")));
            this.accordionControlElementNewNote.Name = "accordionControlElementNewNote";
            this.accordionControlElementNewNote.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.accordionControlElementNewNote.Text = "New Note";
            this.accordionControlElementNewNote.Click += new System.EventHandler(this.ACTLNewNote_ItemClick);
            // 
            // mnuNotebook
            // 
            this.mnuNotebook.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuNewNotebook,
            this.mnuDeleteNotebook,
            this.mnuUpdateNotebook});
            this.mnuNotebook.Name = "contextMenuStrip1";
            this.mnuNotebook.Size = new System.Drawing.Size(174, 70);
            // 
            // mnuNewNotebook
            // 
            this.mnuNewNotebook.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.txtNewNotebook});
            this.mnuNewNotebook.Name = "mnuNewNotebook";
            this.mnuNewNotebook.Size = new System.Drawing.Size(173, 22);
            this.mnuNewNotebook.Text = "New Notebook";
            // 
            // txtNewNotebook
            // 
            this.txtNewNotebook.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtNewNotebook.Name = "txtNewNotebook";
            this.txtNewNotebook.Size = new System.Drawing.Size(100, 23);
            this.txtNewNotebook.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNewNotebook_KeyDown);
            // 
            // mnuDeleteNotebook
            // 
            this.mnuDeleteNotebook.Name = "mnuDeleteNotebook";
            this.mnuDeleteNotebook.Size = new System.Drawing.Size(173, 22);
            this.mnuDeleteNotebook.Text = "Delete Notebook";
            this.mnuDeleteNotebook.Click += new System.EventHandler(this.mnuDeleteNotebook_Click);
            // 
            // mnuUpdateNotebook
            // 
            this.mnuUpdateNotebook.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.txtUpdateNotebook});
            this.mnuUpdateNotebook.Name = "mnuUpdateNotebook";
            this.mnuUpdateNotebook.Size = new System.Drawing.Size(173, 22);
            this.mnuUpdateNotebook.Text = "Rename Notebook";
            // 
            // txtUpdateNotebook
            // 
            this.txtUpdateNotebook.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtUpdateNotebook.Name = "txtUpdateNotebook";
            this.txtUpdateNotebook.Size = new System.Drawing.Size(100, 23);
            this.txtUpdateNotebook.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtUpdateNotebook_KeyDown);
            // 
            // notebookModelBindingSource
            // 
            this.notebookModelBindingSource.DataSource = typeof(Notes.NotebookModel);
            // 
            // fluentDesignFormControl1
            // 
            this.fluentDesignFormControl1.FluentDesignForm = this;
            this.fluentDesignFormControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barButtonItem1,
            this.btnDelete,
            this.btnHelp,
            this.btnUpdateNote,
            this.skinDropDownButtonItem1,
            this.btnNewNote});
            this.fluentDesignFormControl1.Location = new System.Drawing.Point(0, 0);
            this.fluentDesignFormControl1.Manager = this.fluentFormDefaultManager1;
            this.fluentDesignFormControl1.Name = "fluentDesignFormControl1";
            this.fluentDesignFormControl1.Size = new System.Drawing.Size(1117, 31);
            this.fluentDesignFormControl1.TabIndex = 2;
            this.fluentDesignFormControl1.TabStop = false;
            this.fluentDesignFormControl1.TitleItemLinks.Add(this.btnDelete, true);
            this.fluentDesignFormControl1.TitleItemLinks.Add(this.btnHelp, true);
            this.fluentDesignFormControl1.TitleItemLinks.Add(this.btnUpdateNote, true);
            this.fluentDesignFormControl1.TitleItemLinks.Add(this.skinDropDownButtonItem1, true);
            this.fluentDesignFormControl1.TitleItemLinks.Add(this.btnNewNote);
            // 
            // barManager1
            // 
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 31);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(1117, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 614);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(1117, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 31);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 583);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1117, 31);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 583);
            // 
            // bar3
            // 
            this.bar3.BarName = "Status bar";
            this.bar3.DockCol = 0;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar3.Text = "Status bar";
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.Text = "Main menu";
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.Text = "Tools";
            // 
            // mnuNote
            // 
            this.mnuNote.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuNewNote,
            this.mnuDeleteNote,
            this.mnuArchiveNote});
            this.mnuNote.Name = "mnuNote";
            this.mnuNote.Size = new System.Drawing.Size(144, 70);
            // 
            // mnuNewNote
            // 
            this.mnuNewNote.Name = "mnuNewNote";
            this.mnuNewNote.Size = new System.Drawing.Size(143, 22);
            this.mnuNewNote.Text = "New Note";
            this.mnuNewNote.Click += new System.EventHandler(this.mnuNewNote_Click);
            // 
            // mnuDeleteNote
            // 
            this.mnuDeleteNote.Name = "mnuDeleteNote";
            this.mnuDeleteNote.Size = new System.Drawing.Size(143, 22);
            this.mnuDeleteNote.Text = "Delete Note";
            this.mnuDeleteNote.Click += new System.EventHandler(this.mnuDeleteNote_Click);
            // 
            // mnuArchiveNote
            // 
            this.mnuArchiveNote.Name = "mnuArchiveNote";
            this.mnuArchiveNote.Size = new System.Drawing.Size(143, 22);
            this.mnuArchiveNote.Text = "Archive Note";
            this.mnuArchiveNote.Click += new System.EventHandler(this.mnuArchiveNote_Click);
            // 
            // NewNoteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1117, 614);
            this.ControlContainer = this.fluentDesignFormContainer1;
            this.Controls.Add(this.fluentDesignFormContainer1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Controls.Add(this.fluentDesignFormControl1);
            this.FluentDesignFormControl = this.fluentDesignFormControl1;
            this.IconOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("NewNoteForm.IconOptions.LargeImage")));
            this.Name = "NewNoteForm";
            this.Text = "Notes";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.NewNoteForm_FormClosing);
            this.fluentDesignFormContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fluentFormDefaultManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            this.panelControl3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTitle.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.accordionCtlNotes)).EndInit();
            this.mnuNotebook.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.notebookModelBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fluentDesignFormControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            this.mnuNote.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormContainer fluentDesignFormContainer1;
        private DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl fluentDesignFormControl1;
        private DevExpress.XtraBars.FluentDesignSystem.FluentFormDefaultManager fluentFormDefaultManager1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.Navigation.AccordionControl accordionCtlNotes;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElementNewNote;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btnComplete;
        private DevExpress.XtraEditors.TextEdit txtTitle;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraRichEdit.RichEditControl txtMessage;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraEditors.LabelControl lblDate;
        private DevExpress.XtraBars.BarButtonItem btnDelete;
        private DevExpress.XtraBars.BarButtonItem btnHelp;
        private DevExpress.XtraBars.BarButtonItem btnUpdateNote;
        private DevExpress.XtraBars.SkinDropDownButtonItem skinDropDownButtonItem1;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.Bar bar1;
        private System.Windows.Forms.ContextMenuStrip mnuNotebook;
        private System.Windows.Forms.ToolStripMenuItem mnuNewNotebook;
        private System.Windows.Forms.ToolStripTextBox txtNewNotebook;
        private System.Windows.Forms.BindingSource notebookModelBindingSource;
        private DevExpress.XtraBars.BarButtonItem btnNewNote;
        private System.Windows.Forms.ToolStripMenuItem mnuDeleteNotebook;
        private System.Windows.Forms.ToolStripMenuItem mnuUpdateNotebook;
        private System.Windows.Forms.ToolStripTextBox txtUpdateNotebook;
        private System.Windows.Forms.ContextMenuStrip mnuNote;
        private System.Windows.Forms.ToolStripMenuItem mnuNewNote;
        private System.Windows.Forms.ToolStripMenuItem mnuDeleteNote;
        private System.Windows.Forms.ToolStripMenuItem mnuArchiveNote;
    }
}