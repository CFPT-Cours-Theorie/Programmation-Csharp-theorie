using Solitaire.Controllers;

namespace Solitaire
{
    public partial class Frm_Game : Form
    {
        private GameRound gameRound;
        
        /// <summary>
        /// Constructeur de la classe...
        /// </summary>
        public Frm_Game()
        {
            InitializeComponent();
            gameRound = new GameRound(this);
        }

        /// <summary>
        /// Au chargement de la fenêtre...
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Frm_Game_Load(object sender, EventArgs e)
        {
            // Config
            Text = "Jeu du solitaire";
            SetWindowSize(690, 4.0 / 5.0);
            BackgroundImage = Properties.Resources.Background_Green_Felt;

            // Play
            Start();
        }

        /// <summary>
        /// Redimensionne la fenêtre
        /// </summary>
        /// <param name="width">La largeur</param>
        /// <param name="ratio">Ratio de la fenêtre</param>
        private void SetWindowSize(int width, double ratio)
        {
            // Size
            Width = width;
            Height = ((int)((double)width * ratio));

            // Location
            int x = (Screen.PrimaryScreen.WorkingArea.Width - Width) / 2;
            int y = (Screen.PrimaryScreen.WorkingArea.Height - Height) / 2;
            Location = new Point(x, y);
        }

        /// <summary>
        /// Affiche le background
        /// </summary>
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            const int SCALE = 7;

            if (BackgroundImage != null)
            {
                using var textureBrush = new TextureBrush(BackgroundImage);
                textureBrush.ScaleTransform(SCALE, SCALE);
                e.Graphics.FillRectangle(textureBrush, ClientRectangle);
            }
        }

        /// <summary>
        /// Lance la partie
        /// </summary>
        public void Start()
        {
            gameRound.Start();
        }
    }
}
