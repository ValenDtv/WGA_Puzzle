namespace Puzzle
{
    partial class MineForm
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
            this.game1 = new Puzzle.Game();
            this.SuspendLayout();
            // 
            // game1
            // 
            this.game1.Location = new System.Drawing.Point(3, 2);
            this.game1.Name = "game1";
            this.game1.Size = new System.Drawing.Size(618, 516);
            this.game1.TabIndex = 1;
            // 
            // MineForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(618, 521);
            this.Controls.Add(this.game1);
            this.IsMdiContainer = true;
            this.Name = "MineForm";
            this.Text = "Puzzle";
            this.ResumeLayout(false);

        }

        #endregion

        private Game game1;
    }
}

