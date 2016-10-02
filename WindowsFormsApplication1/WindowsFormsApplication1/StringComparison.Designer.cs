namespace StringSimilarity
{
    partial class StringComparison
    {
        /// <summary>
        /// Требуется переменная конструктора.
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
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_Similarity = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_Similarity
            // 
            this.btn_Similarity.Location = new System.Drawing.Point(73, 60);
            this.btn_Similarity.Name = "btn_Similarity";
            this.btn_Similarity.Size = new System.Drawing.Size(139, 75);
            this.btn_Similarity.TabIndex = 2;
            this.btn_Similarity.Text = "Сравнить";
            this.btn_Similarity.UseVisualStyleBackColor = true;
            this.btn_Similarity.Click += new System.EventHandler(this.btn_Similarity_Click);
            // 
            // StringComparison
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(286, 214);
            this.Controls.Add(this.btn_Similarity);
            this.Name = "StringComparison";
            this.Text = "Сравнение строк";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_Similarity;
    }
}

