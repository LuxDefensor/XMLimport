namespace XMLimport
{
    partial class formCheck
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtXML = new System.Windows.Forms.TextBox();
            this.btnOpen = new System.Windows.Forms.Button();
            this.dgvPoints = new System.Windows.Forms.DataGridView();
            this.XMLCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PointName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSender = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtINN = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtFileSize = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPointsCount = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtPointsInDB = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtChannelsCount = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtChannelsInDB = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtDate = new System.Windows.Forms.TextBox();
            this.dgvChannels = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ObjectCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChannelCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChannelName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label11 = new System.Windows.Forms.Label();
            this.txtPointsListCount = new System.Windows.Forms.TextBox();
            this.txtChannelsListCount = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPoints)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChannels)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Выберите XML для проверки";
            // 
            // txtXML
            // 
            this.txtXML.Location = new System.Drawing.Point(12, 40);
            this.txtXML.Name = "txtXML";
            this.txtXML.Size = new System.Drawing.Size(628, 20);
            this.txtXML.TabIndex = 1;
            // 
            // btnOpen
            // 
            this.btnOpen.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnOpen.Location = new System.Drawing.Point(646, 38);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(33, 23);
            this.btnOpen.TabIndex = 2;
            this.btnOpen.Text = "...";
            this.btnOpen.UseVisualStyleBackColor = true;
            // 
            // dgvPoints
            // 
            this.dgvPoints.AllowUserToAddRows = false;
            this.dgvPoints.AllowUserToDeleteRows = false;
            this.dgvPoints.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPoints.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.XMLCode,
            this.PointName});
            this.dgvPoints.Location = new System.Drawing.Point(12, 105);
            this.dgvPoints.Name = "dgvPoints";
            this.dgvPoints.RowHeadersVisible = false;
            this.dgvPoints.Size = new System.Drawing.Size(489, 202);
            this.dgvPoints.TabIndex = 5;
            // 
            // XMLCode
            // 
            this.XMLCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.XMLCode.Frozen = true;
            this.XMLCode.HeaderText = "Код XML";
            this.XMLCode.Name = "XMLCode";
            this.XMLCode.ReadOnly = true;
            this.XMLCode.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.XMLCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.XMLCode.Width = 57;
            // 
            // PointName
            // 
            this.PointName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.PointName.HeaderText = "Название";
            this.PointName.Name = "PointName";
            this.PointName.ReadOnly = true;
            this.PointName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(245, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "В АИИС КУЭ нет следующих точек измерения:";
            // 
            // btnStart
            // 
            this.btnStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnStart.Location = new System.Drawing.Point(695, 32);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 33);
            this.btnStart.TabIndex = 3;
            this.btnStart.Text = "ПУСК";
            this.btnStart.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(567, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Отправитель";
            // 
            // txtSender
            // 
            this.txtSender.Location = new System.Drawing.Point(646, 105);
            this.txtSender.Name = "txtSender";
            this.txtSender.Size = new System.Drawing.Size(192, 20);
            this.txtSender.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(609, 134);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "ИНН";
            // 
            // txtINN
            // 
            this.txtINN.Location = new System.Drawing.Point(646, 131);
            this.txtINN.Name = "txtINN";
            this.txtINN.Size = new System.Drawing.Size(136, 20);
            this.txtINN.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(594, 160);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Размер";
            // 
            // txtFileSize
            // 
            this.txtFileSize.Location = new System.Drawing.Point(646, 157);
            this.txtFileSize.Name = "txtFileSize";
            this.txtFileSize.Size = new System.Drawing.Size(100, 20);
            this.txtFileSize.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(556, 212);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Количество ТИ";
            // 
            // txtPointsCount
            // 
            this.txtPointsCount.Location = new System.Drawing.Point(646, 209);
            this.txtPointsCount.Name = "txtPointsCount";
            this.txtPointsCount.Size = new System.Drawing.Size(100, 20);
            this.txtPointsCount.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(531, 238);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(109, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Из них есть в АИИС";
            // 
            // txtPointsInDB
            // 
            this.txtPointsInDB.Location = new System.Drawing.Point(646, 235);
            this.txtPointsInDB.Name = "txtPointsInDB";
            this.txtPointsInDB.Size = new System.Drawing.Size(100, 20);
            this.txtPointsInDB.TabIndex = 17;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(529, 264);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(111, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = "Количество каналов";
            // 
            // txtChannelsCount
            // 
            this.txtChannelsCount.Location = new System.Drawing.Point(646, 261);
            this.txtChannelsCount.Name = "txtChannelsCount";
            this.txtChannelsCount.Size = new System.Drawing.Size(100, 20);
            this.txtChannelsCount.TabIndex = 19;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(531, 290);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(109, 13);
            this.label9.TabIndex = 20;
            this.label9.Text = "Из них есть в АИИС";
            // 
            // txtChannelsInDB
            // 
            this.txtChannelsInDB.Location = new System.Drawing.Point(646, 287);
            this.txtChannelsInDB.Name = "txtChannelsInDB";
            this.txtChannelsInDB.Size = new System.Drawing.Size(100, 20);
            this.txtChannelsInDB.TabIndex = 21;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(607, 186);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(33, 13);
            this.label10.TabIndex = 12;
            this.label10.Text = "Дата";
            // 
            // txtDate
            // 
            this.txtDate.Location = new System.Drawing.Point(646, 183);
            this.txtDate.Name = "txtDate";
            this.txtDate.Size = new System.Drawing.Size(100, 20);
            this.txtDate.TabIndex = 13;
            // 
            // dgvChannels
            // 
            this.dgvChannels.AllowUserToAddRows = false;
            this.dgvChannels.AllowUserToDeleteRows = false;
            this.dgvChannels.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChannels.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.ObjectCode,
            this.dataGridViewTextBoxColumn2,
            this.ChannelCode,
            this.ChannelName});
            this.dgvChannels.Location = new System.Drawing.Point(12, 336);
            this.dgvChannels.Name = "dgvChannels";
            this.dgvChannels.Size = new System.Drawing.Size(826, 262);
            this.dgvChannels.TabIndex = 22;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn1.HeaderText = "Код ТИ в XML";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 75;
            // 
            // ObjectCode
            // 
            this.ObjectCode.HeaderText = "Код ТИ в АИИС";
            this.ObjectCode.Name = "ObjectCode";
            this.ObjectCode.ReadOnly = true;
            this.ObjectCode.Width = 75;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Название ТИ в XML";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 220;
            // 
            // ChannelCode
            // 
            this.ChannelCode.HeaderText = "Код канала в XML";
            this.ChannelCode.Name = "ChannelCode";
            this.ChannelCode.ReadOnly = true;
            // 
            // ChannelName
            // 
            this.ChannelName.HeaderText = "Название канала";
            this.ChannelName.Name = "ChannelName";
            this.ChannelName.ReadOnly = true;
            this.ChannelName.Width = 200;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(26, 320);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(283, 13);
            this.label11.TabIndex = 23;
            this.label11.Text = "В АИИС КУЭ нет следующих измерительных каналов:";
            // 
            // txtPointsListCount
            // 
            this.txtPointsListCount.BackColor = System.Drawing.SystemColors.Control;
            this.txtPointsListCount.Location = new System.Drawing.Point(430, 82);
            this.txtPointsListCount.Name = "txtPointsListCount";
            this.txtPointsListCount.Size = new System.Drawing.Size(71, 20);
            this.txtPointsListCount.TabIndex = 24;
            // 
            // txtChannelsListCount
            // 
            this.txtChannelsListCount.BackColor = System.Drawing.SystemColors.Control;
            this.txtChannelsListCount.Location = new System.Drawing.Point(767, 313);
            this.txtChannelsListCount.Name = "txtChannelsListCount";
            this.txtChannelsListCount.Size = new System.Drawing.Size(71, 20);
            this.txtChannelsListCount.TabIndex = 25;
            // 
            // formCheck
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(858, 610);
            this.Controls.Add(this.txtChannelsListCount);
            this.Controls.Add(this.txtPointsListCount);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.dgvChannels);
            this.Controls.Add(this.txtDate);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtChannelsInDB);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtChannelsCount);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtPointsInDB);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtPointsCount);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtFileSize);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtINN);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtSender);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvPoints);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.txtXML);
            this.Controls.Add(this.label1);
            this.Name = "formCheck";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Проверка XML";
            ((System.ComponentModel.ISupportInitialize)(this.dgvPoints)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChannels)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtXML;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.DataGridView dgvPoints;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSender;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtINN;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtFileSize;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtPointsCount;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtPointsInDB;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtChannelsCount;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtChannelsInDB;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtDate;
        private System.Windows.Forms.DataGridView dgvChannels;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DataGridViewTextBoxColumn XMLCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn PointName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ObjectCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChannelCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChannelName;
        private System.Windows.Forms.TextBox txtPointsListCount;
        private System.Windows.Forms.TextBox txtChannelsListCount;
    }
}