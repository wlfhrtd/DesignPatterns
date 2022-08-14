using System;
using System.Windows.Forms;

namespace LocationProximity
{
    public partial class Form1 : Form
    {
        private MarkerMediator mediator = new();

        private Button btnAdd;


        public Form1()
        {
            InitializeComponent();
            btnAdd = new();
            btnAdd.Click += OnAddClick;
            btnAdd.Text = "Add Marker";
            btnAdd.Dock = DockStyle.Bottom;
            Controls.Add(btnAdd);
        }

        private void OnAddClick(object sender, EventArgs e)
        {
            var m = mediator.CreateMarker();
            Controls.Add(m);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
