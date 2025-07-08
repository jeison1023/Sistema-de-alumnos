namespace Sistema_de_alumno
{
    partial class FormEliminarAlumno
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
            this.txtMatriculaEliminar = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.dgvAlumnoEncontrado = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlumnoEncontrado)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(91, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Matrícula del Alumno";
            // 
            // txtMatriculaEliminar
            // 
            this.txtMatriculaEliminar.Location = new System.Drawing.Point(256, 80);
            this.txtMatriculaEliminar.Multiline = true;
            this.txtMatriculaEliminar.Name = "txtMatriculaEliminar";
            this.txtMatriculaEliminar.Size = new System.Drawing.Size(186, 43);
            this.txtMatriculaEliminar.TabIndex = 1;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(594, 32);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(173, 53);
            this.btnBuscar.TabIndex = 2;
            this.btnBuscar.Text = "Buscar Alumno";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(594, 118);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(173, 53);
            this.btnEliminar.TabIndex = 3;
            this.btnEliminar.Text = "Eliminar Alumno";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // dgvAlumnoEncontrado
            // 
            this.dgvAlumnoEncontrado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAlumnoEncontrado.Location = new System.Drawing.Point(23, 199);
            this.dgvAlumnoEncontrado.Name = "dgvAlumnoEncontrado";
            this.dgvAlumnoEncontrado.RowHeadersWidth = 51;
            this.dgvAlumnoEncontrado.RowTemplate.Height = 24;
            this.dgvAlumnoEncontrado.Size = new System.Drawing.Size(585, 244);
            this.dgvAlumnoEncontrado.TabIndex = 4;
            this.dgvAlumnoEncontrado.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAlumnoEncontrado_CellContentClick);
            // 
            // FormEliminarAlumno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(803, 455);
            this.Controls.Add(this.dgvAlumnoEncontrado);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.txtMatriculaEliminar);
            this.Controls.Add(this.label1);
            this.Name = "FormEliminarAlumno";
            this.Text = "FormEliminarAlumno";
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlumnoEncontrado)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMatriculaEliminar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.DataGridView dgvAlumnoEncontrado;
    }
}