using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace WinClient
{
    class MessagesBox : Panel
    {

        List<SingleMessage> listaWiadomosci = new List<SingleMessage>();    //lista przechowujaca wszystkie wstawione pola z wiadomosciami
        public MessagesBox(Panel _parent)
        {
            Parent = _parent;   //przypisanie glownego pola wszystkich wiadomosci do dowolnego panala
            Width = _parent.ClientSize.Width;   //ustawienie szeroksci na szerokosc panelu w ktorym jest to umieszczone
            Height = _parent.ClientSize.Height; //to samo co wyzej tylko wysokosc
            Location = new Point(0, 0); //ustawienie w lewym gornym rogu
            BackColor = Color.Red;      //ustawienie koloru tla na czerwony na porzeby testow - do usuniecia/zmienienia

            AddMessage("haloo");    //testowe, reczene wstawienie wiadomosci
            AddMessage("siema");    //
            AddMessage("trzecia wiadomosc");
        }

        public void AddMessage(string _text)
        {
            //funkcja dodajaca pojedyncza wiadomosc


            int horizontalLocation = GetNextMessageHorizontalLocalization();    //lokalizacja nowej wiadomosci

           
            SingleMessage m = new SingleMessage(this, _text, horizontalLocation);   //stworzenie nowej pojedynczej wiadomosci
            listaWiadomosci.Add(m);     //dodanie wiadomosci do listy
        }

        private int GetNextMessageHorizontalLocalization()
        {
            //funkcja wyliczajaca pozycje dla nowej pojedynczej wiadomosci

            int margin = 5;     //tymczasowy margines gorny wiadomosci  //przerobic na globalne marginesy   //dodac marginesy prawy i lewy

            if (listaWiadomosci.Count <= 0)
            {
                //jezeli to jest pierwsza wiadomosc to tylko margines
                return margin;
            }
            else
            {
                Panel lastMessage = listaWiadomosci[listaWiadomosci.Count - 1]; //chwycenie ostatniej wiadomosci

                int lastElementHorizontalLocalization = lastMessage.Location.Y; //chwycenie pozycji ostatniej wiadomosci
                int lastElementBottomLocalization = lastElementHorizontalLocalization + lastMessage.Height; //chwycenie pozycji dolu ostatniej wiadomosci
                return lastElementBottomLocalization + margin; //lokalizacja nowej wiadomosci jako lokalizacja dolu ostatniej i margines
            }
        }
    }
}
