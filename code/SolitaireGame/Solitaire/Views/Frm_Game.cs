namespace Solitaire
{
    public partial class Frm_Game : Form
    {
        public Frm_Game()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Au chargement de la fenêtre...
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Frm_Game_Load(object sender, EventArgs e)
        {
            Text = "Jeu du solitaire";
        }
    }
}
