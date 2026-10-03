namespace ИС_Склад
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.учетToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.приемкаТоваровToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отгрузкаТоваровToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.перемещениеТоваровToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.инвентаризацияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отчетыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.оСкладскихОстаткахToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сервисToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.оПрограммеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.категорииТоваровBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.kurse26ip212DataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.kurse_26ip212DataSet = new ИС_Склад.kurse_26ip212DataSet();
            this.категорииТоваровTableAdapter = new ИС_Склад.kurse_26ip212DataSetTableAdapters.КатегорииТоваровTableAdapter();
            this.label1 = new System.Windows.Forms.Label();
            this.СкладыButton = new System.Windows.Forms.Button();
            this.ПоставщикиButton = new System.Windows.Forms.Button();
            this.ТоварыButton = new System.Windows.Forms.Button();
            this.ClientsMenuItem = new System.Windows.Forms.Button();
            this.menuStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.категорииТоваровBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kurse26ip212DataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kurse_26ip212DataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Location = new System.Drawing.Point(0, 24);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(551, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuStrip2
            // 
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.учетToolStripMenuItem,
            this.отчетыToolStripMenuItem,
            this.сервисToolStripMenuItem});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(551, 24);
            this.menuStrip2.TabIndex = 1;
            this.menuStrip2.Text = "menuStrip2";
            this.menuStrip2.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip2_ItemClicked);
            // 
            // учетToolStripMenuItem
            // 
            this.учетToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.приемкаТоваровToolStripMenuItem,
            this.отгрузкаТоваровToolStripMenuItem,
            this.перемещениеТоваровToolStripMenuItem,
            this.инвентаризацияToolStripMenuItem});
            this.учетToolStripMenuItem.Name = "учетToolStripMenuItem";
            this.учетToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.учетToolStripMenuItem.Text = "Учет";
            // 
            // приемкаТоваровToolStripMenuItem
            // 
            this.приемкаТоваровToolStripMenuItem.Name = "приемкаТоваровToolStripMenuItem";
            this.приемкаТоваровToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.приемкаТоваровToolStripMenuItem.Text = "Приемка";
            this.приемкаТоваровToolStripMenuItem.Click += new System.EventHandler(this.приемкаТоваровToolStripMenuItem_Click);
            // 
            // отгрузкаТоваровToolStripMenuItem
            // 
            this.отгрузкаТоваровToolStripMenuItem.Name = "отгрузкаТоваровToolStripMenuItem";
            this.отгрузкаТоваровToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.отгрузкаТоваровToolStripMenuItem.Text = "Отгрузка";
            this.отгрузкаТоваровToolStripMenuItem.Click += new System.EventHandler(this.отгрузкаТоваровToolStripMenuItem_Click);
            // 
            // перемещениеТоваровToolStripMenuItem
            // 
            this.перемещениеТоваровToolStripMenuItem.Name = "перемещениеТоваровToolStripMenuItem";
            this.перемещениеТоваровToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.перемещениеТоваровToolStripMenuItem.Text = "Перемещение";
            this.перемещениеТоваровToolStripMenuItem.Click += new System.EventHandler(this.перемещениеТоваровToolStripMenuItem_Click);
            // 
            // инвентаризацияToolStripMenuItem
            // 
            this.инвентаризацияToolStripMenuItem.Name = "инвентаризацияToolStripMenuItem";
            this.инвентаризацияToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.инвентаризацияToolStripMenuItem.Text = "Инвентаризация";
            this.инвентаризацияToolStripMenuItem.Click += new System.EventHandler(this.инвентаризацияToolStripMenuItem_Click);
            // 
            // отчетыToolStripMenuItem
            // 
            this.отчетыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.оСкладскихОстаткахToolStripMenuItem});
            this.отчетыToolStripMenuItem.Name = "отчетыToolStripMenuItem";
            this.отчетыToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.отчетыToolStripMenuItem.Text = "Отчеты";
            // 
            // оСкладскихОстаткахToolStripMenuItem
            // 
            this.оСкладскихОстаткахToolStripMenuItem.Name = "оСкладскихОстаткахToolStripMenuItem";
            this.оСкладскихОстаткахToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.оСкладскихОстаткахToolStripMenuItem.Text = "Складские остатки";
            this.оСкладскихОстаткахToolStripMenuItem.Click += new System.EventHandler(this.оСкладскихОстаткахToolStripMenuItem_Click);
            // 
            // сервисToolStripMenuItem
            // 
            this.сервисToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.оПрограммеToolStripMenuItem});
            this.сервисToolStripMenuItem.Name = "сервисToolStripMenuItem";
            this.сервисToolStripMenuItem.Size = new System.Drawing.Size(84, 20);
            this.сервисToolStripMenuItem.Text = "Программа";
            // 
            // оПрограммеToolStripMenuItem
            // 
            this.оПрограммеToolStripMenuItem.Name = "оПрограммеToolStripMenuItem";
            this.оПрограммеToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.оПрограммеToolStripMenuItem.Text = "О программе";
            this.оПрограммеToolStripMenuItem.Click += new System.EventHandler(this.оПрограммеToolStripMenuItem_Click);
            // 
            // категорииТоваровBindingSource
            // 
            this.категорииТоваровBindingSource.DataMember = "КатегорииТоваров";
            this.категорииТоваровBindingSource.DataSource = this.kurse26ip212DataSetBindingSource;
            // 
            // kurse26ip212DataSetBindingSource
            // 
            this.kurse26ip212DataSetBindingSource.DataSource = this.kurse_26ip212DataSet;
            this.kurse26ip212DataSetBindingSource.Position = 0;
            // 
            // kurse_26ip212DataSet
            // 
            this.kurse_26ip212DataSet.DataSetName = "kurse_26ip212DataSet";
            this.kurse_26ip212DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // категорииТоваровTableAdapter
            // 
            this.категорииТоваровTableAdapter.ClearBeforeFill = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(188, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(180, 25);
            this.label1.TabIndex = 6;
            this.label1.Text = "Компания Оникс";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // СкладыButton
            // 
            this.СкладыButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("СкладыButton.BackgroundImage")));
            this.СкладыButton.Location = new System.Drawing.Point(162, 230);
            this.СкладыButton.Name = "СкладыButton";
            this.СкладыButton.Size = new System.Drawing.Size(228, 46);
            this.СкладыButton.TabIndex = 4;
            this.СкладыButton.Text = "Склады";
            this.СкладыButton.UseVisualStyleBackColor = true;
            this.СкладыButton.Click += new System.EventHandler(this.СкладыButton_Click);
            // 
            // ПоставщикиButton
            // 
            this.ПоставщикиButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ПоставщикиButton.BackgroundImage")));
            this.ПоставщикиButton.Location = new System.Drawing.Point(162, 141);
            this.ПоставщикиButton.Name = "ПоставщикиButton";
            this.ПоставщикиButton.Size = new System.Drawing.Size(228, 46);
            this.ПоставщикиButton.TabIndex = 3;
            this.ПоставщикиButton.Text = "Поставщики";
            this.ПоставщикиButton.UseVisualStyleBackColor = true;
            this.ПоставщикиButton.Click += new System.EventHandler(this.ПоставщикиButton_Click);
            // 
            // ТоварыButton
            // 
            this.ТоварыButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ТоварыButton.BackgroundImage")));
            this.ТоварыButton.Location = new System.Drawing.Point(162, 68);
            this.ТоварыButton.Name = "ТоварыButton";
            this.ТоварыButton.Size = new System.Drawing.Size(228, 46);
            this.ТоварыButton.TabIndex = 2;
            this.ТоварыButton.Text = "Оборудование";
            this.ТоварыButton.UseVisualStyleBackColor = true;
            this.ТоварыButton.Click += new System.EventHandler(this.ТоварыButton_Click);
            // 
            // ClientsMenuItem
            // 
            this.ClientsMenuItem.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ClientsMenuItem.BackgroundImage")));
            this.ClientsMenuItem.Location = new System.Drawing.Point(162, 313);
            this.ClientsMenuItem.Name = "ClientsMenuItem";
            this.ClientsMenuItem.Size = new System.Drawing.Size(228, 46);
            this.ClientsMenuItem.TabIndex = 7;
            this.ClientsMenuItem.Text = "Монтажники";
            this.ClientsMenuItem.UseVisualStyleBackColor = true;
            this.ClientsMenuItem.Click += new System.EventHandler(this.ClientsMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(551, 383);
            this.Controls.Add(this.ClientsMenuItem);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.СкладыButton);
            this.Controls.Add(this.ПоставщикиButton);
            this.Controls.Add(this.ТоварыButton);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.menuStrip2);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Text = "ОниксСклад";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.категорииТоваровBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kurse26ip212DataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kurse_26ip212DataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem учетToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem отчетыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сервисToolStripMenuItem;
        private System.Windows.Forms.BindingSource kurse26ip212DataSetBindingSource;
        private kurse_26ip212DataSet kurse_26ip212DataSet;
        private System.Windows.Forms.BindingSource категорииТоваровBindingSource;
        private kurse_26ip212DataSetTableAdapters.КатегорииТоваровTableAdapter категорииТоваровTableAdapter;
        private System.Windows.Forms.ToolStripMenuItem приемкаТоваровToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem отгрузкаТоваровToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem перемещениеТоваровToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem инвентаризацияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem оСкладскихОстаткахToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem оПрограммеToolStripMenuItem;
        private System.Windows.Forms.Button ТоварыButton;
        private System.Windows.Forms.Button ПоставщикиButton;
        private System.Windows.Forms.Button СкладыButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ClientsMenuItem;
    }
}

