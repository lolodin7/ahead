namespace Excel_Parse
{
    partial class ChangeQuestionView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChangeQuestionView));
            this.panel1 = new System.Windows.Forms.Panel();
            this.lb_AnswerTxt = new System.Windows.Forms.Label();
            this.tb_Answer = new System.Windows.Forms.TextBox();
            this.btn_NextAnswer = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_ChangeQuestion = new System.Windows.Forms.Button();
            this.lb_Panel2 = new System.Windows.Forms.Label();
            this.tb_NewQuestion = new System.Windows.Forms.TextBox();
            this.tb_NewAnswer = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_NextAnswer);
            this.panel1.Controls.Add(this.lb_AnswerTxt);
            this.panel1.Controls.Add(this.tb_Answer);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(559, 341);
            this.panel1.TabIndex = 1;
            this.panel1.Visible = false;
            // 
            // lb_AnswerTxt
            // 
            this.lb_AnswerTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lb_AnswerTxt.Location = new System.Drawing.Point(101, 68);
            this.lb_AnswerTxt.Name = "lb_AnswerTxt";
            this.lb_AnswerTxt.Size = new System.Drawing.Size(334, 62);
            this.lb_AnswerTxt.TabIndex = 9;
            this.lb_AnswerTxt.Text = "Для изменения ответа на вопрос, введите текущий ответ.";
            this.lb_AnswerTxt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tb_Answer
            // 
            this.tb_Answer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tb_Answer.Location = new System.Drawing.Point(158, 154);
            this.tb_Answer.Name = "tb_Answer";
            this.tb_Answer.Size = new System.Drawing.Size(227, 26);
            this.tb_Answer.TabIndex = 8;
            // 
            // btn_NextAnswer
            // 
            this.btn_NextAnswer.Location = new System.Drawing.Point(174, 226);
            this.btn_NextAnswer.Name = "btn_NextAnswer";
            this.btn_NextAnswer.Size = new System.Drawing.Size(196, 50);
            this.btn_NextAnswer.TabIndex = 10;
            this.btn_NextAnswer.Text = "Далее";
            this.btn_NextAnswer.UseVisualStyleBackColor = true;
            this.btn_NextAnswer.Click += new System.EventHandler(this.btn_Next_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.tb_NewAnswer);
            this.panel2.Controls.Add(this.btn_ChangeQuestion);
            this.panel2.Controls.Add(this.lb_Panel2);
            this.panel2.Controls.Add(this.tb_NewQuestion);
            this.panel2.Location = new System.Drawing.Point(14, 10);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(557, 341);
            this.panel2.TabIndex = 2;
            this.panel2.Visible = false;
            // 
            // btn_ChangeQuestion
            // 
            this.btn_ChangeQuestion.Location = new System.Drawing.Point(184, 224);
            this.btn_ChangeQuestion.Name = "btn_ChangeQuestion";
            this.btn_ChangeQuestion.Size = new System.Drawing.Size(196, 50);
            this.btn_ChangeQuestion.TabIndex = 15;
            this.btn_ChangeQuestion.Text = "Далее";
            this.btn_ChangeQuestion.UseVisualStyleBackColor = true;
            this.btn_ChangeQuestion.Click += new System.EventHandler(this.btn_ChangeQuestion_Click);
            // 
            // lb_Panel2
            // 
            this.lb_Panel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lb_Panel2.Location = new System.Drawing.Point(114, 37);
            this.lb_Panel2.Name = "lb_Panel2";
            this.lb_Panel2.Size = new System.Drawing.Size(334, 62);
            this.lb_Panel2.TabIndex = 12;
            this.lb_Panel2.Text = "Для изменения секретного вопроса, введите текущий ответ.";
            this.lb_Panel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tb_NewQuestion
            // 
            this.tb_NewQuestion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tb_NewQuestion.Location = new System.Drawing.Point(116, 124);
            this.tb_NewQuestion.Name = "tb_NewQuestion";
            this.tb_NewQuestion.Size = new System.Drawing.Size(343, 26);
            this.tb_NewQuestion.TabIndex = 13;
            this.tb_NewQuestion.Visible = false;
            // 
            // tb_NewAnswer
            // 
            this.tb_NewAnswer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tb_NewAnswer.Location = new System.Drawing.Point(116, 172);
            this.tb_NewAnswer.Name = "tb_NewAnswer";
            this.tb_NewAnswer.Size = new System.Drawing.Size(343, 26);
            this.tb_NewAnswer.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(60, 132);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Вопрос: ";
            this.label1.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(60, 180);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Ответ:";
            this.label2.Visible = false;
            // 
            // ChangeQuestionView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(583, 365);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ChangeQuestionView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ChangeQuestionView";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ChangeQuestionView_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lb_AnswerTxt;
        private System.Windows.Forms.TextBox tb_Answer;
        private System.Windows.Forms.Button btn_NextAnswer;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox tb_NewAnswer;
        private System.Windows.Forms.Button btn_ChangeQuestion;
        private System.Windows.Forms.Label lb_Panel2;
        private System.Windows.Forms.TextBox tb_NewQuestion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}