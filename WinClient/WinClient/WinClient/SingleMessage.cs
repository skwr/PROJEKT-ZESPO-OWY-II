using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace WinClient
{
    class SingleMessage : Panel
    {
        public int margin = 5;
        public SingleMessage(Control _parent, string _text, int loc, int rightMargin)
        {
            Parent = _parent;       //dodanie pojedynczej wiadomosci do MessagesBox
            Location = new Point(margin, loc);  //ustawienie pozycji nowej wiadomosci na podstawie parametru konstruktora
            Width = _parent.Width - 2 * margin - rightMargin;  //ustawienie szerokosci pojedynczej wiadomosci z uwzglednieniem marginesu //przerobic na margines globalny //zrobic marginesy prawy i lewy
            Height = 50;    //ustawienie wysokosci pojedynczej wiadomosci   //przerobic na wysokosc uzalezniona od tresci wiadomosci
            BackColor = Color.Yellow;       //ustawienie koloru tla na potrzeby testow // do usuniecia

            Label text = new Label();   //stworzenie labela przechowujacego tresc
            text.Text = _text;  //wpisanie tresci do labela
            text.Width = ClientSize.Width;  //ustawienie szerokosci pojedynczej wiadomosci na max //ew przerobic
            text.Height = 30;   //ustawienie stalej wysokosci labela, przerobic!
            text.Parent = this; //przypisanie labela do pojedynczej wiadomosci
            text.Location = new Point(0, 0);    //ustawienie pozycji labela na 0,0; do przerobienia

            
        }
    }
}
