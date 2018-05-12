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

        bool scrollMeDown = false;

        

        Timer timer;

        public List<SingleMessage> listaWiadomosci = new List<SingleMessage>();    //lista przechowujaca wszystkie wstawione pola z wiadomosciami
        public MessagesBox(Control _parent)
        {
            Parent = _parent;   //przypisanie glownego pola wszystkich wiadomosci do dowolnego panala

            

            Width = _parent.ClientSize.Width;   //ustawienie szeroksci na szerokosc panelu w ktorym jest to umieszczone
            Height = _parent.ClientSize.Height; //to samo co wyzej tylko wysokosc
            Location = new Point(0, 0); //ustawienie w lewym gornym rogu
            BackColor = Color.Red;      //ustawienie koloru tla na czerwony na porzeby testow - do usuniecia/zmienienia


            AutoScroll = true;

            timer = new Timer();
            timer.Interval = 10;
            timer.Tick += new EventHandler(Timer_tick);
            

            

        }

        

        public delegate void NewMessage(string _message, MessagesBox _messageBox);

        public NewMessage NM = new NewMessage(AddMessage);

        private static void AddMessage(string _text, MessagesBox _messagesBox)
        {
            //funkcja dodajaca pojedyncza wiadomosc

            _messagesBox.InsertMessage(_text);
            
        }

        public void InsertMessage(string _text)
        {
            int horizontalLocation = GetNextMessageHorizontalLocalization();    //lokalizacja nowej wiadomosci


            SingleMessage m;

               
            m = new SingleMessage(this, _text, horizontalLocation, 20);   //stworzenie nowej pojedynczej wiadomosci
                
            
            listaWiadomosci.Add(m);     //dodanie wiadomosci do listy

            
            scrollMeDown = true;
            timer.Enabled = true;
        }

        public void ScrollDown()
        {
            //ScrollControlIntoView(this);

            if (!VerticalScroll.Visible) return;
            if (!scrollMeDown) return;

            int currentValue = VerticalScroll.Value;
            int maxValue = VerticalScroll.Maximum;
            int change = 10;
            int newValue = currentValue;

            

            if (currentValue >= maxValue - VerticalScroll.LargeChange - 1)
            {
                scrollMeDown = false;
                timer.Enabled = false;
            } 

            

            if (currentValue < maxValue)
            {
                if (currentValue + change > maxValue)
                {
                    newValue = maxValue;
                }
                else
                {
                    newValue = currentValue + change;
                }

                VerticalScroll.Value = newValue;
            }
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

        int GetMessagesHight()
        {
            int sum;

            if (listaWiadomosci.Count > 0)
            {
                sum = listaWiadomosci[0].margin;
            }
            else
            {
                sum = 0;
            }
            foreach (SingleMessage SM in listaWiadomosci)
            {
                sum += SM.Height + SM.margin;
            }

            return sum;
        }

        private void Timer_tick(object sender, EventArgs e)
        {
            ScrollDown();
        }
    }
}
