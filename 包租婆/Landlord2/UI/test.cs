using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Landlord2
{
    public partial class test : Form
    {
        public test()
        {
            InitializeComponent();
        }
    }
}

//============================
/*using ComponentFactory.Krypton.Toolkit;
using JZBen;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

public class cw : UserControl
{
    private cg a;
    private IContainer b;
    private KryptonDataGridView c;
    private KryptonPanel d;
    private KryptonButton e;
    private KryptonButton f;
    private KryptonButton g;
    private ContextMenuStrip h;
    private ToolStripMenuItem i;
    private ToolStripMenuItem j;
    private KryptonButton k;
    private KryptonButton l;
    private KryptonDataGridViewTextBoxColumn m;
    private KryptonDataGridViewTextBoxColumn n;
    private KryptonDataGridViewTextBoxColumn o;
    private KryptonDataGridViewTextBoxColumn p;
    private KryptonDataGridViewTextBoxColumn q;
    private KryptonDataGridViewTextBoxColumn r;
    private KryptonDataGridViewTextBoxColumn s;
    private DataGridViewTextBoxColumn t;
    private DataGridViewTextBoxColumn u;
    private DataGridViewTextBoxColumn v;
    private DataGridViewTextBoxColumn w;
    private KryptonDataGridViewTextBoxColumn x;
    private DataGridViewTextBoxColumn y;

    public cw(cg A_0)
    {
        this.a();
        this.a = A_0;
    }

    private void a()
    {
        this.b = new Container();
        this.c = new KryptonDataGridView();
        this.h = new ContextMenuStrip(this.b);
        this.i = new ToolStripMenuItem();
        this.j = new ToolStripMenuItem();
        this.d = new KryptonPanel();
        this.k = new KryptonButton();
        this.l = new KryptonButton();
        this.g = new KryptonButton();
        this.e = new KryptonButton();
        this.f = new KryptonButton();
        this.m = new KryptonDataGridViewTextBoxColumn();
        this.n = new KryptonDataGridViewTextBoxColumn();
        this.o = new KryptonDataGridViewTextBoxColumn();
        this.p = new KryptonDataGridViewTextBoxColumn();
        this.q = new KryptonDataGridViewTextBoxColumn();
        this.r = new KryptonDataGridViewTextBoxColumn();
        this.s = new KryptonDataGridViewTextBoxColumn();
        this.t = new DataGridViewTextBoxColumn();
        this.u = new DataGridViewTextBoxColumn();
        this.v = new DataGridViewTextBoxColumn();
        this.w = new DataGridViewTextBoxColumn();
        this.x = new KryptonDataGridViewTextBoxColumn();
        this.y = new DataGridViewTextBoxColumn();
        ((ISupportInitialize) this.c).BeginInit();
        this.h.SuspendLayout();
        this.d.BeginInit();
        this.d.SuspendLayout();
        base.SuspendLayout();
        this.c.AllowUserToAddRows = false;
        this.c.AllowUserToDeleteRows = false;
        this.c.AllowUserToOrderColumns = true;
        this.c.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Top;
        this.c.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
        this.c.Columns.AddRange(new DataGridViewColumn[] { this.m, this.n, this.o, this.p, this.q, this.r, this.s, this.t, this.u, this.v, this.w, this.x, this.y });
        this.c.ContextMenuStrip = this.h;
        this.c.EditMode = DataGridViewEditMode.EditProgrammatically;
        this.c.Location = new Point(0, 30);
        this.c.Name = "dgvAccountView";
        this.c.RowHeadersVisible = false;
        this.c.RowTemplate.Height = 0x17;
        this.c.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        this.c.Size = new Size(0x323, 0xd4);
        this.c.TabIndex = 1;
        this.c.CellClick += new DataGridViewCellEventHandler(this.a);
        this.c.CellMouseDoubleClick += new DataGridViewCellMouseEventHandler(this.a);
        this.h.Font = new Font("Segoe UI", 9f);
        this.h.Items.AddRange(new ToolStripItem[] { this.i, this.j });
        this.h.Name = "contextMenuStrip1";
        this.h.Size = new Size(0x63, 0x30);
        this.i.Name = "tsmiModify";
        this.i.Size = new Size(0x62, 0x16);
        this.i.Text = "修改";
        this.i.Click += new EventHandler(this.c);
        this.j.Name = "tsmiDelete";
        this.j.Size = new Size(0x62, 0x16);
        this.j.Text = "删除";
        this.j.Click += new EventHandler(this.b);
        this.d.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top;
        this.d.Controls.Add(this.k);
        this.d.Controls.Add(this.l);
        this.d.Controls.Add(this.g);
        this.d.Controls.Add(this.e);
        this.d.Controls.Add(this.f);
        this.d.Location = new Point(0, 0);
        this.d.Name = "kryptonPanel1";
        this.d.PanelBackStyle = PaletteBackStyle.HeaderPrimary;
        this.d.Size = new Size(0x323, 0x1d);
        this.d.TabIndex = 10;
        this.k.Anchor = AnchorStyles.Right | AnchorStyles.Top;
        this.k.AutoSize = true;
        this.k.Enabled = false;
        this.k.Location = new Point(750, 2);
        this.k.Name = "btnDown";
        this.k.Size = new Size(50, 0x19);
        this.k.TabIndex = 14;
        this.k.Values.Text = "下移";
        this.k.Click += new EventHandler(this.a);
        this.l.Anchor = AnchorStyles.Right | AnchorStyles.Top;
        this.l.AutoSize = true;
        this.l.Enabled = false;
        this.l.Location = new Point(0x2b6, 2);
        this.l.Name = "btnUp";
        this.l.Size = new Size(50, 0x19);
        this.l.TabIndex = 13;
        this.l.Values.Text = "上移";
        this.l.Click += new EventHandler(this.a);
        this.g.AutoSize = true;
        this.g.Location = new Point(0x73, 2);
        this.g.Name = "btnDelete";
        this.g.Size = new Size(50, 0x19);
        this.g.TabIndex = 5;
        this.g.Values.Text = "删除";
        this.g.Click += new EventHandler(this.d);
        this.e.AutoSize = true;
        this.e.Location = new Point(3, 2);
        this.e.Name = "btnAdd";
        this.e.Size = new Size(50, 0x19);
        this.e.TabIndex = 1;
        this.e.Values.Text = "新建";
        this.e.Click += new EventHandler(this.f);
        this.f.AutoSize = true;
        this.f.Location = new Point(0x3b, 2);
        this.f.Name = "btnModify";
        this.f.Size = new Size(50, 0x19);
        this.f.TabIndex = 4;
        this.f.Values.Text = "修改";
        this.f.Click += new EventHandler(this.e);
        this.m.FillWeight = 100.2181f;
        this.m.HeaderText = "名称";
        this.m.MinimumWidth = 100;
        this.m.Name = "Column1";
        this.m.SortMode = DataGridViewColumnSortMode.NotSortable;
        this.m.Width = 100;
        this.n.FillWeight = 40.69027f;
        this.n.HeaderText = "类型";
        this.n.MinimumWidth = 50;
        this.n.Name = "Column2";
        this.n.SortMode = DataGridViewColumnSortMode.NotSortable;
        this.n.Width = 50;
        this.o.FillWeight = 40.69027f;
        this.o.HeaderText = "初始额";
        this.o.MinimumWidth = 50;
        this.o.Name = "Column3";
        this.o.SortMode = DataGridViewColumnSortMode.NotSortable;
        this.o.Width = 0x35;
        this.p.FillWeight = 40.69027f;
        this.p.HeaderText = "收入";
        this.p.MinimumWidth = 50;
        this.p.Name = "Column4";
        this.p.SortMode = DataGridViewColumnSortMode.NotSortable;
        this.p.Width = 50;
        this.q.FillWeight = 40.69027f;
        this.q.HeaderText = "支出";
        this.q.MinimumWidth = 50;
        this.q.Name = "Column5";
        this.q.SortMode = DataGridViewColumnSortMode.NotSortable;
        this.q.Width = 50;
        this.r.FillWeight = 40.69027f;
        this.r.HeaderText = "转入";
        this.r.MinimumWidth = 50;
        this.r.Name = "Column6";
        this.r.SortMode = DataGridViewColumnSortMode.NotSortable;
        this.r.Width = 50;
        this.s.FillWeight = 40.69027f;
        this.s.HeaderText = "转出";
        this.s.MinimumWidth = 50;
        this.s.Name = "Column7";
        this.s.SortMode = DataGridViewColumnSortMode.NotSortable;
        this.s.Width = 50;
        this.t.FillWeight = 40.69027f;
        this.t.HeaderText = "借入";
        this.t.MinimumWidth = 50;
        this.t.Name = "Column10";
        this.t.SortMode = DataGridViewColumnSortMode.NotSortable;
        this.t.Width = 50;
        this.u.FillWeight = 40.69027f;
        this.u.HeaderText = "借出";
        this.u.MinimumWidth = 50;
        this.u.Name = "Column9";
        this.u.SortMode = DataGridViewColumnSortMode.NotSortable;
        this.u.Width = 50;
        this.v.FillWeight = 40.69027f;
        this.v.HeaderText = "还入";
        this.v.MinimumWidth = 50;
        this.v.Name = "Column11";
        this.v.SortMode = DataGridViewColumnSortMode.NotSortable;
        this.v.Width = 50;
        this.w.FillWeight = 40.69027f;
        this.w.HeaderText = "还出";
        this.w.MinimumWidth = 50;
        this.w.Name = "Column12";
        this.w.SortMode = DataGridViewColumnSortMode.NotSortable;
        this.w.Width = 50;
        this.x.FillWeight = 40.69027f;
        this.x.HeaderText = "余额";
        this.x.MinimumWidth = 50;
        this.x.Name = "Column8";
        this.x.SortMode = DataGridViewColumnSortMode.NotSortable;
        this.x.Width = 50;
        this.y.FillWeight = 70.93877f;
        this.y.HeaderText = "说明";
        this.y.MinimumWidth = 80;
        this.y.Name = "Column15";
        this.y.SortMode = DataGridViewColumnSortMode.NotSortable;
        this.y.Width = 80;
        base.AutoScaleDimensions = new SizeF(6f, 12f);
        base.AutoScaleMode = AutoScaleMode.Font;
        base.Controls.Add(this.d);
        base.Controls.Add(this.c);
        base.Name = "ucAccountView";
        base.Size = new Size(0x323, 0xf2);
        ((ISupportInitialize) this.c).EndInit();
        this.h.ResumeLayout(false);
        this.d.EndInit();
        this.d.ResumeLayout(false);
        this.d.PerformLayout();
        base.ResumeLayout(false);
    }

    private void a(object A_0, EventArgs A_1)
    {
        DataGridView c = this.c;
        int index = c.SelectedRows[0].Index;
        DataGridViewRow dataGridViewRow = c.Rows[index];
        c.Rows.RemoveAt(index);
        if (((KryptonButton) A_0) == this.l)
        {
            c.Rows.Insert(index - 1, dataGridViewRow);
        }
        else
        {
            c.Rows.Insert(index + 1, dataGridViewRow);
        }
        for (int i = 0; i < c.Rows.Count; i++)
        {
            c.Rows[i].Selected = false;
            if (i != (c.Rows.Count - 1))
            {
                ((Account) c.Rows[i].Tag).a(i);
            }
        }
        dataGridViewRow.Selected = true;
        this.b();
    }

    private void a(object A_0, DataGridViewCellEventArgs A_1)
    {
        this.b();
    }

    private void a(object A_0, DataGridViewCellMouseEventArgs A_1)
    {
        this.d();
    }

    private void b()
    {
        DataGridView c = this.c;
        if (c.SelectedRows.Count == 1)
        {
            this.l.Enabled = true;
            this.k.Enabled = true;
            int index = c.SelectedRows[0].Index;
            if (index == (c.Rows.Count - 1))
            {
                this.l.Enabled = false;
                this.k.Enabled = false;
            }
            if (index == 0)
            {
                this.l.Enabled = false;
            }
            if (index == (c.Rows.Count - 2))
            {
                this.k.Enabled = false;
            }
        }
        else
        {
            this.l.Enabled = false;
            this.k.Enabled = false;
        }
    }

    private void b(object A_0, EventArgs A_1)
    {
        this.c();
    }

    private void c()
    {
        if ((this.c.SelectedRows.Count > 1) || ((this.c.SelectedRows.Count == 1) && (this.c.SelectedRows[0].Index != (this.c.Rows.Count - 1))))
        {
            foreach (DataGridViewRow row in this.c.SelectedRows)
            {
                if (row.Index != (this.c.Rows.Count - 1))
                {
                    Account tag = (Account) row.Tag;
                    if (tag.e())
                    {
                        MessageBox.Show("有账目属于账户 " + tag.n() + "。如果您确实需要删除此账户，请先删除相关账目。");
                    }
                    else
                    {
                        tag.v();
                        this.c.Rows.Remove(row);
                    }
                }
            }
        }
        else
        {
            MessageBox.Show("您没有选择需要删除的账户。");
        }
    }

    private void c(object A_0, EventArgs A_1)
    {
        this.d();
    }

    private void d()
    {
        if ((this.c.SelectedRows.Count > 0) && (this.c.SelectedRows[0].Index != (this.c.Rows.Count - 1)))
        {
            int index = this.c.SelectedRows[0].Index;
            new da((Account) this.c.SelectedRows[0].Tag).ShowDialog();
            this.e();
            this.c.CurrentCell = this.c.Rows[index].Cells[0];
        }
        else
        {
            MessageBox.Show("您没有选择需要修改的账户。");
        }
    }

    private void d(object A_0, EventArgs A_1)
    {
        if (DialogResult.Yes == MessageBox.Show("您确定需要删除吗？", "删除？", MessageBoxButtons.YesNo))
        {
            this.c();
        }
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing && (this.b != null))
        {
            this.b.Dispose();
        }
        base.Dispose(disposing);
    }

    public void e()
    {
        this.c.Rows.Clear();
        double num = 0.0;
        double num2 = 0.0;
        double num3 = 0.0;
        double num4 = 0.0;
        double num5 = 0.0;
        double num6 = 0.0;
        double num7 = 0.0;
        double num8 = 0.0;
        double num9 = 0.0;
        double num10 = 0.0;
        foreach (Account account in Account.a(false))
        {
            DataGridViewRow row = (DataGridViewRow) this.c.RowTemplate.Clone();
            row.CreateCells(this.c, new object[] { account.n(), e8.a().a(account.j()), account.c(), account.d(), account.l(), account.s(), account.u(), account.t(), account.h(), account.i(), account.f(), account.q(), account.k() });
            this.c.Rows.Add(row);
            row.Tag = account;
            num += account.c();
            num2 += account.d();
            num3 += account.l();
            num4 += account.s();
            num5 += account.u();
            num7 += account.t();
            num8 += account.h();
            num9 += account.i();
            num10 += account.f();
            num6 += account.q();
        }
        DataGridViewRow dataGridViewRow = (DataGridViewRow) this.c.RowTemplate.Clone();
        dataGridViewRow.CreateCells(this.c, new object[] { "合计", "", num, num2, num3, num4, num5, num7, num8, num9, num10, num6, "" });
        this.c.Rows.Add(dataGridViewRow);
        this.a.l();
    }

    private void e(object A_0, EventArgs A_1)
    {
        this.d();
    }

    private void f(object A_0, EventArgs A_1)
    {
        new da().ShowDialog();
        this.e();
    }

    private void g(object A_0, EventArgs A_1)
    {
        this.e();
    }
}

*/