using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarlosSeptica
{
    public partial class InterfaceForm : Form
    {
        public InterfaceForm()
        {
            InitializeComponent();
        }

        private void pictureBox_Paint(object sender, PaintEventArgs e)
        {
            /*Pen pen = new Pen(Brushes.Black);
            e.Graphics.DrawLine(pen, 0, 0, 100, 100);
            Card c = new Card(CardNumber.CARD_7, CardType.CARD_CLUB);

            new Card(CardNumber.CARD_7, CardType.CARD_CLUB).Draw(e.Graphics, 0, 350, false);
            new Card(CardNumber.CARD_8, CardType.CARD_CLUB).Draw(e.Graphics, 100, 350, false);
            new Card(CardNumber.CARD_9, CardType.CARD_CLUB).Draw(e.Graphics, 200, 350, false);
            new Card(CardNumber.CARD_10, CardType.CARD_CLUB).Draw(e.Graphics, 300, 350, false);
            new Card(CardNumber.CARD_J, CardType.CARD_CLUB).Draw(e.Graphics, 400, 350, false);
            new Card(CardNumber.CARD_Q, CardType.CARD_CLUB).Draw(e.Graphics, 500, 350, false);
            new Card(CardNumber.CARD_K, CardType.CARD_CLUB).Draw(e.Graphics, 600, 350, false);
            new Card(CardNumber.CARD_A, CardType.CARD_CLUB).Draw(e.Graphics, 700, 350, false);

            new Card(CardNumber.CARD_7, CardType.CARD_HEART).Draw(e.Graphics, 0, 150, false);
            new Card(CardNumber.CARD_8, CardType.CARD_HEART).Draw(e.Graphics, 100, 150, false);
            new Card(CardNumber.CARD_9, CardType.CARD_HEART).Draw(e.Graphics, 200, 150, false);
            new Card(CardNumber.CARD_10, CardType.CARD_HEART).Draw(e.Graphics, 300, 150, false);
            new Card(CardNumber.CARD_J, CardType.CARD_HEART).Draw(e.Graphics, 400, 150, false);
            new Card(CardNumber.CARD_Q, CardType.CARD_HEART).Draw(e.Graphics, 500, 150, false);
            new Card(CardNumber.CARD_K, CardType.CARD_HEART).Draw(e.Graphics, 600, 150, true);
            new Card(CardNumber.CARD_A, CardType.CARD_HEART).Draw(e.Graphics, 700, 150, false);

            new Card(CardNumber.CARD_7, CardType.CARD_DIAMOND).Draw(e.Graphics, 0, 0, false);
            new Card(CardNumber.CARD_8, CardType.CARD_DIAMOND).Draw(e.Graphics, 100, 0, false);
            new Card(CardNumber.CARD_9, CardType.CARD_DIAMOND).Draw(e.Graphics, 200, 0, false);
            new Card(CardNumber.CARD_10, CardType.CARD_DIAMOND).Draw(e.Graphics, 300, 0, false);
            new Card(CardNumber.CARD_J, CardType.CARD_DIAMOND).Draw(e.Graphics, 400, 0, false);
            new Card(CardNumber.CARD_Q, CardType.CARD_DIAMOND).Draw(e.Graphics, 500, 0, false);
            new Card(CardNumber.CARD_K, CardType.CARD_DIAMOND).Draw(e.Graphics, 600, 0, false);
            new Card(CardNumber.CARD_A, CardType.CARD_DIAMOND).Draw(e.Graphics, 700, 0, false);

            new Card(CardNumber.CARD_7, CardType.CARD_SPADE).Draw(e.Graphics, 0, 500, false);
            new Card(CardNumber.CARD_8, CardType.CARD_SPADE).Draw(e.Graphics, 100, 500, false);
            new Card(CardNumber.CARD_9, CardType.CARD_SPADE).Draw(e.Graphics, 200, 500, false);
            new Card(CardNumber.CARD_10, CardType.CARD_SPADE).Draw(e.Graphics, 300, 500, false);
            new Card(CardNumber.CARD_J, CardType.CARD_SPADE).Draw(e.Graphics, 400, 500, false);
            new Card(CardNumber.CARD_Q, CardType.CARD_SPADE).Draw(e.Graphics, 500, 500, false);
            new Card(CardNumber.CARD_K, CardType.CARD_SPADE).Draw(e.Graphics, 600, 500, false);
            new Card(CardNumber.CARD_A, CardType.CARD_SPADE).Draw(e.Graphics, 700, 500, false);*/
            Player player = new Player(PlayerType.PLAYER_AI);

            player.GetCardsInHand()[0] = new Card(CardNumber.CARD_7, CardType.CARD_SPADE);
            player.GetCardsInHand()[1] = new Card(CardNumber.CARD_8, CardType.CARD_DIAMOND);
            //player.GetCardsInHand()[2] = new Card(CardNumber.CARD_K, CardType.CARD_CLUB);
            player.GetCardsInHand()[3] = new Card(CardNumber.CARD_A, CardType.CARD_DIAMOND);

            player.addCardToStack(new Card(CardNumber.CARD_A, CardType.CARD_DIAMOND));

            player.Draw(e.Graphics, 300, 100);

            player = new Player(PlayerType.PLAYER_HUMAN);

            player.GetCardsInHand()[0] = new Card(CardNumber.CARD_7, CardType.CARD_SPADE);
            player.GetCardsInHand()[1] = new Card(CardNumber.CARD_8, CardType.CARD_DIAMOND);
            player.GetCardsInHand()[2] = new Card(CardNumber.CARD_K, CardType.CARD_CLUB);
            player.GetCardsInHand()[3] = new Card(CardNumber.CARD_A, CardType.CARD_DIAMOND);

            player.addCardToStack(new Card(CardNumber.CARD_A, CardType.CARD_DIAMOND));
            player.addCardToStack(new Card(CardNumber.CARD_A, CardType.CARD_DIAMOND));
            player.addCardToStack(new Card(CardNumber.CARD_A, CardType.CARD_DIAMOND));
            player.addCardToStack(new Card(CardNumber.CARD_A, CardType.CARD_DIAMOND));
            player.addCardToStack(new Card(CardNumber.CARD_A, CardType.CARD_DIAMOND));
            player.addCardToStack(new Card(CardNumber.CARD_A, CardType.CARD_DIAMOND));
            player.addCardToStack(new Card(CardNumber.CARD_A, CardType.CARD_DIAMOND));
            player.addCardToStack(new Card(CardNumber.CARD_A, CardType.CARD_DIAMOND));
            player.addCardToStack(new Card(CardNumber.CARD_A, CardType.CARD_DIAMOND));
            player.addCardToStack(new Card(CardNumber.CARD_A, CardType.CARD_DIAMOND));
            player.addCardToStack(new Card(CardNumber.CARD_A, CardType.CARD_DIAMOND));
            player.addCardToStack(new Card(CardNumber.CARD_A, CardType.CARD_DIAMOND));
            player.addCardToStack(new Card(CardNumber.CARD_A, CardType.CARD_DIAMOND));
            player.addCardToStack(new Card(CardNumber.CARD_A, CardType.CARD_DIAMOND));
            player.addCardToStack(new Card(CardNumber.CARD_A, CardType.CARD_DIAMOND));
            player.addCardToStack(new Card(CardNumber.CARD_A, CardType.CARD_DIAMOND));
            player.addCardToStack(new Card(CardNumber.CARD_A, CardType.CARD_DIAMOND));
            player.addCardToStack(new Card(CardNumber.CARD_A, CardType.CARD_DIAMOND));
            player.addCardToStack(new Card(CardNumber.CARD_A, CardType.CARD_DIAMOND));
            player.addCardToStack(new Card(CardNumber.CARD_A, CardType.CARD_DIAMOND));
            player.addCardToStack(new Card(CardNumber.CARD_A, CardType.CARD_DIAMOND));
            player.addCardToStack(new Card(CardNumber.CARD_A, CardType.CARD_DIAMOND));
            player.addCardToStack(new Card(CardNumber.CARD_A, CardType.CARD_DIAMOND));
            player.addCardToStack(new Card(CardNumber.CARD_A, CardType.CARD_DIAMOND));
            player.addCardToStack(new Card(CardNumber.CARD_A, CardType.CARD_DIAMOND));
            player.addCardToStack(new Card(CardNumber.CARD_A, CardType.CARD_DIAMOND));
            player.addCardToStack(new Card(CardNumber.CARD_A, CardType.CARD_DIAMOND));
            player.addCardToStack(new Card(CardNumber.CARD_A, CardType.CARD_DIAMOND));
            player.addCardToStack(new Card(CardNumber.CARD_A, CardType.CARD_DIAMOND));
            player.addCardToStack(new Card(CardNumber.CARD_A, CardType.CARD_DIAMOND));
            player.addCardToStack(new Card(CardNumber.CARD_A, CardType.CARD_DIAMOND));
            player.addCardToStack(new Card(CardNumber.CARD_A, CardType.CARD_DIAMOND));
            player.addCardToStack(new Card(CardNumber.CARD_A, CardType.CARD_DIAMOND));
            player.addCardToStack(new Card(CardNumber.CARD_A, CardType.CARD_DIAMOND));
            player.addCardToStack(new Card(CardNumber.CARD_A, CardType.CARD_DIAMOND));
            player.addCardToStack(new Card(CardNumber.CARD_A, CardType.CARD_DIAMOND));
            player.addCardToStack(new Card(CardNumber.CARD_A, CardType.CARD_DIAMOND));
            player.addCardToStack(new Card(CardNumber.CARD_A, CardType.CARD_DIAMOND));
            player.addCardToStack(new Card(CardNumber.CARD_A, CardType.CARD_DIAMOND));
            player.addCardToStack(new Card(CardNumber.CARD_A, CardType.CARD_DIAMOND));
            player.addCardToStack(new Card(CardNumber.CARD_A, CardType.CARD_DIAMOND));
            player.addCardToStack(new Card(CardNumber.CARD_A, CardType.CARD_DIAMOND));
            player.addCardToStack(new Card(CardNumber.CARD_A, CardType.CARD_DIAMOND));
            player.addCardToStack(new Card(CardNumber.CARD_A, CardType.CARD_DIAMOND));
            player.addCardToStack(new Card(CardNumber.CARD_A, CardType.CARD_DIAMOND));
            player.addCardToStack(new Card(CardNumber.CARD_A, CardType.CARD_DIAMOND));
            player.addCardToStack(new Card(CardNumber.CARD_A, CardType.CARD_DIAMOND));
            player.addCardToStack(new Card(CardNumber.CARD_A, CardType.CARD_DIAMOND));
            player.addCardToStack(new Card(CardNumber.CARD_A, CardType.CARD_DIAMOND));
            player.addCardToStack(new Card(CardNumber.CARD_A, CardType.CARD_DIAMOND));
            player.addCardToStack(new Card(CardNumber.CARD_A, CardType.CARD_DIAMOND));
            player.addCardToStack(new Card(CardNumber.CARD_A, CardType.CARD_DIAMOND));
            player.addCardToStack(new Card(CardNumber.CARD_A, CardType.CARD_DIAMOND));
            player.addCardToStack(new Card(CardNumber.CARD_A, CardType.CARD_DIAMOND));
            player.addCardToStack(new Card(CardNumber.CARD_A, CardType.CARD_DIAMOND));
            player.addCardToStack(new Card(CardNumber.CARD_A, CardType.CARD_DIAMOND));
            player.addCardToStack(new Card(CardNumber.CARD_A, CardType.CARD_DIAMOND));
            player.addCardToStack(new Card(CardNumber.CARD_A, CardType.CARD_DIAMOND));
            player.addCardToStack(new Card(CardNumber.CARD_A, CardType.CARD_DIAMOND));
            player.addCardToStack(new Card(CardNumber.CARD_A, CardType.CARD_DIAMOND));
            player.addCardToStack(new Card(CardNumber.CARD_A, CardType.CARD_DIAMOND));
            player.addCardToStack(new Card(CardNumber.CARD_A, CardType.CARD_DIAMOND));
            player.addCardToStack(new Card(CardNumber.CARD_A, CardType.CARD_DIAMOND));
            player.addCardToStack(new Card(CardNumber.CARD_A, CardType.CARD_DIAMOND));
            player.addCardToStack(new Card(CardNumber.CARD_A, CardType.CARD_DIAMOND));
            player.addCardToStack(new Card(CardNumber.CARD_A, CardType.CARD_DIAMOND));
            player.addCardToStack(new Card(CardNumber.CARD_A, CardType.CARD_DIAMOND));
            player.addCardToStack(new Card(CardNumber.CARD_A, CardType.CARD_DIAMOND));
            player.addCardToStack(new Card(CardNumber.CARD_A, CardType.CARD_DIAMOND));

            player.Draw(e.Graphics, 300, 400);

            CardDealer cardDealer = new CardDealer();
            
            cardDealer.Draw(e.Graphics, 50, 200);
        }
    }
}
